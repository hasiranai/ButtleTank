using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpownEnemy : MonoBehaviour
{
    public int spownInterval;

    public GameObject EnemyPrefab;

    private int spncount;

    //void Start()
    //{
        
    //}

    void Update()
    {
        spncount += 1;

        if (spncount % 500 == 0)
        {
            GameObject EnemyB = Instantiate(EnemyPrefab, transform.position, Quaternion.identity);
        }
    }
}
