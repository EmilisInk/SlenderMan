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

    private float speedIncrement = 0.5f;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);

        if (distanceToPlayer <= 10f)
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
        if (!agent.hasPath || agent.remainingDistance < 1f)
        {
            Vector3 randomPos = transform.position + Random.insideUnitSphere * wanderRadius;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPos, out hit, wanderRadius, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
            }
        }
    }

    public void IncreaseSpeed()
    {
        agent.speed += speedIncrement;
        Debug.Log(agent.speed);
    }
}
