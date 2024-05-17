using UnityEngine;
using UnityEngine.AI;

public class PatrouilleSkript : StateMachineBehaviour
{   

    
    
    NavMeshAgent agent;
    EnemyWayPoints enemyWayPoints;

    private void initialSetup(Animator animator)
    {
        agent = animator.GetComponent<NavMeshAgent>();
        enemyWayPoints = animator.transform.GetComponent<EnemyWayPoints>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        SetNextDestination();
        //Debug.LogWarning("initialSetup");
    }



    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent == null || enemyWayPoints == null)
        {

            initialSetup(animator);

            return;
        }

       
       

        SetNextDestination();
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (agent == null || enemyWayPoints == null) {

            initialSetup(animator);
            //Debug.Log("FehlendeReferenzen");


            return;}


        //Debug.Log(agent.destination +" Zielort");
        if (Vector2.Distance(enemyWayPoints.GetActiveWayPoint(), agent.transform.position) < 3f)
        {
            SetNextDestination();
        }
    }

    void SetNextDestination()
    {
        enemyWayPoints.NextWayPoint();
        Vector2 nWP = enemyWayPoints.GetActiveWayPoint();
        
        Vector3 destination = new Vector3(nWP.x, nWP.y, agent.transform.position.z);
        bool succ = agent.SetDestination(destination);
        // Debug.LogWarning("ActiveWaypoint"+succ);
    }
}
