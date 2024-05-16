using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyRotator : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject Player;

    // Start is called before the first frame update
    void Start(Animator animator)
    {
        agent = animator.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        var dir = agent.transform.position - Player.transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle - 30, Vector3.forward);

    }
}
