using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Beweger : MonoBehaviour
{ 
    public GameObject Player;
    [SerializeField] private FieldOfView fieldOfView;

    public GameObject Enemy;
    private NavMeshAgent NavMeshAgent;

    void Start()
    {
        NavMeshAgent = Enemy.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Enemy.transform.position;
        
        fieldOfView.SetAimDirection(NavMeshAgent.velocity.normalized);
     //   fieldOfView.SetAimDirection(Player.transform.position - Enemy.transform.position);

        fieldOfView.SetOrigin(transform.position);


    }
    private void OnTriggerEnter2D(Collider2D collision) //fürt auß wenn das Collider einen anderen berührt
    {
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        
    }
}
