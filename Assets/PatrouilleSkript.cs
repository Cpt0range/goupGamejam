using UnityEngine;
using UnityEngine.AI;

public class PatrouilleSkript : StateMachineBehaviour
{
    Vector2[] Wegpunkte = { new Vector2(-22, -15), new Vector2(-10, -20) };
    int aktuellerIndex = 0;
    NavMeshAgent agent;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        SetNextDestination();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        
        if (agent == null || aktuellerIndex < 0 || aktuellerIndex >= Wegpunkte.Length)
            return;

        if (Vector2.Distance(agent.destination, agent.transform.position) < 0.5f)
        {
            SetNextDestination();
        }
    }

    void SetNextDestination()
    {
        aktuellerIndex = (aktuellerIndex + 1) % Wegpunkte.Length;
        agent.SetDestination(new Vector2(Wegpunkte[aktuellerIndex].x, Wegpunkte[aktuellerIndex].y));
        
    }
}
