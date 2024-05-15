using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;


public class LoS : MonoBehaviour
{
    public GameObject Player;

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
    [SerializeField] private int rayCount = 250;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float fov = 45f;
    private Mesh mesh;

    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }
    private void FixedUpdate()
    {
        transform.position = Player.transform.position;
        var worldMousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var dir = worldMousePosition - Player.transform.position;

        // Calculate angle from player to mouse position
        var anglo1 = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        Quaternion quaternion = Quaternion.AngleAxis(anglo1 - 90, Vector3.forward);

        // Extract yaw angle from the quaternion
        Vector3 euler = quaternion.eulerAngles;
        float yaw = euler.z;

        float angle = 90+fov/2+yaw;
        float angleIncrease = fov / rayCount;
        float viewdistance = 250f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount *3];

        vertices[0] = Vector3.zero;

        int vertexIndex = 1;
        int TriangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {

            Vector3 vertex;
            RaycastHit2D raycastHit2d = Physics2D.Raycast(transform.position, GetVectorFromAngle(angle), viewdistance, layerMask);
            if(raycastHit2d.collider == null)
            {
                vertex =  GetVectorFromAngle(angle) * viewdistance;
            }
            else
            {
                vertex = transform.InverseTransformPoint(raycastHit2d.point);
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
}
