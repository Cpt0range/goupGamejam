using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class FieldOfView : MonoBehaviour
{
    public GameObject Enemy1;
    public GameObject Player;
    public Animator animator;
    public NavMeshAgent navMeshAgent;
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
    private float viewDistance;
    private Vector3 origin;
    private float startingAngle;

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        
        viewDistance = 16f;
        origin = Vector3.zero;

        animator.SetBool("angeregt", false);

    }
    private void Update()
    {

        bool Aktueller_angeregt = animator.GetBool("angeregt");
        Debug.Log(Aktueller_angeregt);

        if (navMeshAgent.velocity.magnitude != 0)
            lastKnownAgentVector = navMeshAgent.velocity;
        //if (CheckLineOfSight()) Debug.Log("Gesichted");
        CheckLineOfSight();
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

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewDistance, layerMask);
            if (raycastHit2D.collider == null)
            {
                // No hit
                vertex = origin + GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                // Hit object
                vertex = raycastHit2D.point;
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
        mesh.bounds = new Bounds(origin, Vector3.one * 1000f);
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

    /* private void OnTriggerEnter2D(Collider2D collision) //fürt auß wenn das Collider einen anderen berührt
    {

        
            

            if (collision.gameObject.CompareTag("Player"))
            {
            Debug.Log("Spotted");
            animator.SetBool("angeregt",true);
            }
        
    } */

    public bool CheckLineOfSight()
    {
        Vector3 richtungZumSpieler = Player.transform.position - origin;
        richtungZumSpieler.z = 0;
        lastKnownAgentVector.z = 0;
        float winkel = Vector3.Angle(lastKnownAgentVector, richtungZumSpieler); // Angenommen, die Vorwärtsrichtung des NPCs zeigt entlang der positiven x-Achse
        
        Debug.Log(winkel);
        Debug.DrawLine(origin, origin + richtungZumSpieler, Color.red);
        Debug.DrawLine(origin, origin + lastKnownAgentVector, Color.blue);

        

        if (Mathf.Abs(winkel) < fov / 2f)
        {
            RaycastHit2D hit = Physics2D.Raycast(origin, richtungZumSpieler, viewDistance, layerMask);
            if (hit.collider != null)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    //Debug.Log("Spieler erkannt!");
                    //bool currentValue = animator.GetBool("angeregt");

                    
                    animator.SetBool("angeregt", true);
                    
                    return true;
                }
                //Debug.Log("Hindernis erkannt!");
                return false;
            }
            //Debug.Log("Außerhalb der Sichtweite");
            return false;
        }
        //Debug.Log("Außerhalb des Sichtfeldes");
        return false;
    }
}