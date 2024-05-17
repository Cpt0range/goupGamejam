using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Beweger : MonoBehaviour
{
    private Animator animator;
    private GameObject Player;
    private FieldOfView fieldOfView;

    private GameObject Enemy;
    private NavMeshAgent navMeshAgent;
    private Vector3 lastKnownAgentVector;

    void Start()
    {
        fieldOfView = transform.parent.GetComponentInChildren<FieldOfView>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Enemy = transform.parent.Find("Enemy").gameObject;
        animator = Enemy.GetComponent<Animator>();
        navMeshAgent = Enemy.GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        if (navMeshAgent.velocity.magnitude != 0)
            lastKnownAgentVector = navMeshAgent.velocity;

        transform.position = Enemy.transform.position;
        
        fieldOfView.SetOrigin(transform.position);

        if (animator.GetBool("angeregt") == true)
            
        fieldOfView.SetAimDirection(Player.transform.position - transform.position);
     //   fieldOfView.SetAimDirection(Player.transform.position - Enemy.transform.position);
        else if (animator.GetBool("angeregt") == false)
        {
            fieldOfView.SetAimDirection(lastKnownAgentVector);
        }



    }
    private void OnTriggerEnter2D(Collider2D collision) //f�rt au� wenn das Collider einen anderen ber�hrt
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
