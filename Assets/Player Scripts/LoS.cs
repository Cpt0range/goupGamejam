using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class LoS : MonoBehaviour
{
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
    private Vector3 origin;
    private float startingAngle;
    private float fov;
    private Mesh mesh;
    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        fov = 360f;
        origin = Vector3.zero;
    }
    private void Update()
    {
        int rayCount = 1000;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewdistance = 50f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount *3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int TriangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {

            Vector3 vertex;
            RaycastHit2D raycastHit2d = Physics2D.Raycast(origin, GetVectorFromAngle(angle), viewdistance, layerMask);
            if(raycastHit2d.collider == null)
            {
                vertex = origin + GetVectorFromAngle(angle) * viewdistance;
            }
            else
            {
                vertex = raycastHit2d.point;
            }
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[TriangleIndex + 0] = 0;
                triangles[TriangleIndex + 1] = vertexIndex - 1;
                triangles[TriangleIndex + 2] = vertexIndex;

                TriangleIndex += 3;
            }

            vertexIndex++;
            angle -= angleIncrease;

        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }
    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;   
    }
    public void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = GetAngleFromVectorFloat(aimDirection) - (fov / 2f);
    }

}
