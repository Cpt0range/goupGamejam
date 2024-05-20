using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using System.Runtime.CompilerServices;


public class SoldierFoVScript : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private Mesh mesh;
    private Vector3 originVertex;
    private float startingAngle;

    private void start()
    {
        Mesh mesh = new Mesh(); 
        GetComponent<MeshFilter>().mesh = mesh;
        originVertex = Vector3.zero;
    }

    private void Update()
    {
        originVertex = Vector3.zero; //der ursprungsortsvektor, von dem aus der startray und die restlichen rays gecastet werden. ich vermute relativ zur position des tragenden gameobjects oder zum weltursprung. was davon wird sich beim testen zeigen.
        float fov = 90f; // breite des sichtfelds in grad
        float angle = startingAngle; // der winkel, des startstrahls, von dem aus die restlichen strahlen im uhrzeigersinn erzeugt werden.   
        int rayCount = 51; // anzahl der strahlen, mittels derer auf dem startstrahl aufbauend, das feld erzeugt wird
        float angleIncrease = fov / rayCount; // der winkel zwischen den rays, bzw. der winkelbetrag, der sukzessiv auf den startwinkel addiert wird, um die restlichen rays aufeinanderfolgend zu casten
        float viewDistance = 50f; // der abstand, bis zu dem die rays gecastet werden

        Vector3[] vertices = new Vector3[2+rayCount]; // da der ursprungsvertex(ursprungsortsvektor) und der startvertext(startortsvektor) nicht in den rayCount inbegriffen sind, müssen sie bezüglich ihrer anzahl zusätzlich addiert werden. diese line erzeugt ein array von ortsvektoren, zwischen denen rays gecastet werden. das ziel ist, einen startpunkt zu geben, von dem aus die rays in einem sukzessiv radial gecastet werden (also als fächer). bzw. im resultat als ein kreisausschnitt aus diskreten kanten.
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = originVertex;

        int vertexIndex = 1; // wir starten bei 1, da vektor0 der ursprungsortsvektor ist
        int triangleIndex = 0;
        for (int i = 0; i < rayCount; i++)  {
            Vector3 vertex;
            RaycastHit2D rayCastHit2D = Physics2D.Raycast(originVertex, UtilsClass.GetVectorFromAngle(angle), viewDistance, layerMask); // castet einen ray von einem ursprungsortsvektor aus in richtung eines vektors, der aus einem winkel berechnet wird (startwinkel von startvertex von startray und restliche rays), der eine festgelegte länge(viewDistance)hat
            if (rayCastHit2D.collider == null) // bedingung dafür ob ray bis viewDistance geührt wird oder nicht
            {
                // no hit
                vertex = originVertex + UtilsClass.GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                // hit object
                vertex = rayCastHit2D.point;
            }

                vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1; // dieser block spannt dreiecke auf flächen
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }

            vertexIndex ++;
            angle -= angleIncrease; // -= bedeutet den winkel im uhrzeigersinn zu erhöhen. +=  bedeutet den winkel gegen den uhrzeigersinn zu erhöhen, da unitys rotation positiv ist, wenn sie gegen den uhrzeigersinn geht.
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
 


    }

    //Methoden___________________________________________________________________________________________________________________________________________________________

}
