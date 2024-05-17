using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRotator : MonoBehaviour
{
    public Animator animator;
    public NavMeshAgent agent;
    public GameObject Player;
    public 

    // Start is called before the first frame update
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {

        if (animator.GetBool("angeregt") == false)
        {
            var vel = agent.velocity;
            vel.z = 0;

            if (vel != Vector3.zero)
            {
                transform.rotation = Quaternion.LookRotation(Vector3.forward, vel);
            }
        }
        else if (animator.GetBool("angeregt") == true)
        {
            var dir = agent.transform.position - Player.transform.position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 30, Vector3.forward);
        }

            



    }
}
