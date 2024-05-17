using UnityEngine;
using UnityEngine.AI;

public class FolgenScript : StateMachineBehaviour
{
    public GameObject Player;
    public float schussRadius;
    public float stoppRadius;

    private Vector2 lastknownPosition;
    private Transform target;
    private NavMeshAgent agent;
    private Movement movementScript;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Player = GameObject.Find("Player");
        agent = animator.gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        movementScript = Player.GetComponent<Movement>();
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent == null || movementScript == null)
        {
            Debug.LogError("NavMeshAgent or Movement script is not initialized!");
            return;
        }

        Vector3 a = agent.transform.position;
        Vector3 b = Player.transform.position;
        a.z = 0;
        b.z = 0;

        Vector2 abstandsvektor = a - b;
        float abstand = abstandsvektor.magnitude;
        lastknownPosition = agent.transform.position;

        if (!animator.GetBool("siehtSpieler") || abstand > stoppRadius)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
            if (target != null)
                agent.SetDestination(target.position);
        }
        else if (abstand < stoppRadius)
        {
            agent.SetDestination(lastknownPosition);
        }

        if (animator.GetBool("siehtSpieler") && abstand < schussRadius)
        {
            //Debug.Log("In Schussreichweite!");
            movementScript.HP -= 10 * Time.deltaTime; // Reducing player's HP
        }
        else
        {
            // No action if not in shooting range
        }
    }
}
