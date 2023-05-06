using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcMovement : MonoBehaviour
{    
    [SerializeField] private Transform[] Points;
    UnityEngine.AI.NavMeshAgent agent;

    [SerializeField] private float distanceToChangePoint;
    int currentPoint = -1;

    private int timer = 100000;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = Points[0].position;
    }

    void Update()
    {
        bool trigger = gameObject.GetComponent<Animator>().GetBool("Stay");
        agent.enabled = true;
        trigger = false;
        if (agent.remainingDistance < distanceToChangePoint)
        {           
            trigger = false;
            currentPoint++;                                                                    
            if (currentPoint == Points.Length)
            {
                currentPoint = -1;
            }
            agent.destination = Points[currentPoint].position;
        }        
    }
}
