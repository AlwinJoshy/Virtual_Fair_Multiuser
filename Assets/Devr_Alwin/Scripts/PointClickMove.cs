using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PointClickMove : MonoBehaviour
{
    Animator anim;
    NavMeshAgent agent;
    Vector3 destinantion;
    PlayerAnimationState animationState;

    enum PlayerAnimationState
    {
        Idle,
        Running
    }

    void Start()
    {
        animationState = PlayerAnimationState.Idle;
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        agent.isStopped = true;
    }

    private void Update()
    {
        // if is moving
        float distance = Vector3.Distance(transform.position, destinantion);

        if (!agent.isStopped) anim.SetFloat("Speed", Mathf.Min(distance, 0.5f));
        else if (agent.isStopped && animationState == PlayerAnimationState.Running)
        {
            animationState = PlayerAnimationState.Idle;
        }
    }

    public void MovePlayer()
    {
        agent.isStopped = false;
        destinantion = GameManager.instance.hit.point;
        animationState = PlayerAnimationState.Running;
        agent.SetDestination(destinantion);
    }
}
