using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Transform target;

    private NavMeshAgent agent;
    private Animator animator;

    public float wanderRadius = 30f;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {


        if (agent.remainingDistance <= 10)
        {
            Chase();
        }
        else
        {
            Wander();
        }
        animator.SetFloat("speed", agent.velocity.magnitude);
    }

    void Chase()
    {
        agent.SetDestination(target.position);
    }

    void Wander()
    {
    }
}
