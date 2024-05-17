using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Beweger : MonoBehaviour
{
    public Animator animator;
    public GameObject Player;
    [SerializeField] private FieldOfView fieldOfView;

    public GameObject Enemy;
    public NavMeshAgent navMeshAgent;
    private Vector3 lastKnownAgentVector;

    void Start()
    {
        navMeshAgent = Enemy.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        if (navMeshAgent.velocity.magnitude != 0)
            lastKnownAgentVector = navMeshAgent.velocity;

        transform.localPosition = Enemy.transform.localPosition;
        
        fieldOfView.SetOrigin(transform.localPosition);

        if (animator.GetBool("angeregt") == true)
            
        fieldOfView.SetAimDirection(Player.transform.position - transform.localPosition);
     //   fieldOfView.SetAimDirection(Player.transform.position - Enemy.transform.position);
        else if (animator.GetBool("angeregt") == false)
        {
            fieldOfView.SetAimDirection(lastKnownAgentVector);
        }



    }
    private void OnTriggerEnter2D(Collider2D collision) //fürt auß wenn das Collider einen anderen berührt
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
