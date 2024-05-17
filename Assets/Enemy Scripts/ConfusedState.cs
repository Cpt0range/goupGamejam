using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class confusedstate : MonoBehaviour
{   
    public static Vector2 WalkInRandomDirection(Vector2 enemypos,float walkdistance,float wallavoidence,LayerMask walllayer)
    {
        Vector2 avoiddist = new Vector2 (wallavoidence,wallavoidence);
        Vector2 heading = Random.insideUnitCircle.normalized;
        RaycastHit2D walkray = Physics2D.Raycast(enemypos, heading, walkdistance, walllayer);
        Vector2 walkpos = walkray.point - enemypos / 2 - avoiddist;
        return walkpos;
    }
}