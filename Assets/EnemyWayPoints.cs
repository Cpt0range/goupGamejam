using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWayPoints : MonoBehaviour
{
    public Transform[] WayPoints;
    private int ActiveWayPointIndex;


    public void NextWayPoint()
    {

        ActiveWayPointIndex = (ActiveWayPointIndex+1) % WayPoints.Length;

    }

    public Vector2 GetActiveWayPoint()
    {

        Vector3 wp = WayPoints[ActiveWayPointIndex].position;
        Vector2 wp2 = new Vector2(wp.x, wp.y);
        return wp2;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
