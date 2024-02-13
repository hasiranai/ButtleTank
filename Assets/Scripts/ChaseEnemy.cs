using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   // 追加

public class ChaseEnemy : MonoBehaviour
{
    private GameObject target;

    private NavMeshAgent agent;

    void Start()
    {
        // (復習) Find() の働きは？
        target = GameObject.Find("Tank");

        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (target)
        {
            // targetの位置を目的地に設定する
            agent.destination = target.transform.position;
        }
    }
}
