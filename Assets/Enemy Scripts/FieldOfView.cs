using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class FieldOfView : MonoBehaviour
{
    public Vector3 lastKnownPlayerPosition;
    private Vector3 SpawnOffset;

    private GameObject Player;
    private Animator animator;
    private NavMeshAgent navMeshAgent;
    private Vector3 lastKnownAgentVector;

    static Vector3 GetVectorFromAngle(float angle)
    {
        float angleRad = angle * (Mathf.PI / 180);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    static float GetAngleFromVectorFloat(Vector3 dir)
    {

        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;

        return n;
    }

    [SerializeField] private LayerMask layerMask;
    

    private Mesh mesh;
    public float fov;
    private float viewDistance = 8f;
    private Vector3 origin;
    private float startingAngle;

    private void Start()
    {

        SpawnOffset = transform.parent.position;

        animator = transform.parent.Find("Enemy").GetComponent<Animator>();
        navMeshAgent = transform.parent.Find("Enemy").GetComponent<NavMeshAgent>();
        Player = GameObject.FindGameObjectWithTag("Player");

        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        
        
        origin = Vector3.zero;

        animator.SetBool("angeregt", false);

    }
    private void Update()
    {

        

        bool Aktueller_angeregt = animator.GetBool("angeregt");
        //Debug.Log(Aktueller_angeregt);

        if (navMeshAgent.velocity.magnitude != 0)
            lastKnownAgentVector = navMeshAgent.velocity;
        //if (CheckLineOfSight()) Debug.Log("Gesichted");
        CheckLineOfSight();

        startingAngle = GetAngleFromVectorFloat(lastKnownAgentVector) + fov / 2f;
    }
    public void LateUpdate()
    {
        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];
        mesh.RecalculateBounds();

        vertices[0] = origin - SpawnOffset;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);
            if (raycastHit2D.collider == null)
            {
                // No hit
                vertex = origin + GetVectorFromAngle(angle) * viewDistance - SpawnOffset;
            }
            else
            {
                // Hit object
                vertex = (Vector3)raycastHit2D.point - SpawnOffset;
            }
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;
        }


        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        //mesh.bounds = new Bounds(origin, Vector3.one * viewDistance);

        mesh.RecalculateBounds();
    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = GetAngleFromVectorFloat(aimDirection) + fov / 2f;
    }

    public void SetFoV(float fov)
    {
        this.fov = fov;
    }

    public void SetViewDistance(float viewDistance)
    {
        this.viewDistance = viewDistance;
    }


    public bool CheckLineOfSight()
    {
        Vector3 richtungZumSpieler = Player.transform.position - origin;
        richtungZumSpieler.z = 0;
        lastKnownAgentVector.z = 0;
        float winkel = Vector3.Angle(lastKnownAgentVector, richtungZumSpieler); // Angenommen, die Vorwärtsrichtung des NPCs zeigt entlang der positiven x-Achse
        
        //Debug.Log(winkel);
        Debug.DrawLine(origin, origin + richtungZumSpieler, Color.red);
        Debug.DrawLine(origin, origin + lastKnownAgentVector, Color.blue);
        //Debug.Log(animator.GetBool("siehtSpieler"));


        if (Mathf.Abs(winkel) < fov / 2f)
        {
            RaycastHit2D hit = Physics2D.Raycast(origin, richtungZumSpieler, viewDistance, layerMask);
            if (hit.collider != null)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    //Debug.Log("Spieler erkannt!");
                    //bool currentValue = animator.GetBool("angeregt");
                    lastKnownPlayerPosition = hit.transform.position;
                    animator.SetBool("siehtSpieler", true);
                    animator.SetBool("angeregt", true);
                    
                    return true;
                }
                
            }
            
        }
        
        
        animator.SetBool("siehtSpieler", false);
        return false;
    }
    
}