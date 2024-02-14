using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseCamera : MonoBehaviour
{
    private GameObject target;

    private Vector3 offset;

    void Start()
    {
        target = GameObject.Find("Tank");

        offset = transform.position - target.transform.position;
    }

    void Update()
    {
        if (target)
        {
            transform.position = target.transform.position + offset;
        }
    }
}
