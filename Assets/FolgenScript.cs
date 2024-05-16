using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;

public class FolgenScript : StateMachineBehaviour
{
    
    Transform target;
    NavMeshAgent agent;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent = animator.gameObject.GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
      

        if (agent == null)
        {
            Debug.LogError("NavMeshAgent is not initialized!");
            return;
        }
        
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
        if (target != null)
            
            agent.SetDestination(target.position);


    }
}