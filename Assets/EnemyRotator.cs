using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRotator : MonoBehaviour
{
    private FieldOfView fieldOfView;
    private Animator animator;
    private NavMeshAgent agent;
    private GameObject Player;
    

    // Start is called before the first frame update
    void Start()
    {
        fieldOfView = transform.parent.GetComponentInChildren<FieldOfView>();
        Player = GameObject.FindGameObjectWithTag("Player");
        GameObject Enemy = transform.parent.Find("Enemy").gameObject;
        animator = Enemy.GetComponent<Animator>();
        agent = Enemy.GetComponent<NavMeshAgent>();
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
            var dir = agent.transform.position - fieldOfView.lastKnownPlayerPosition;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle - 30, Vector3.forward);
        }

            



    }
}
