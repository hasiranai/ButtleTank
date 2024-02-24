using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ⭐︎コンポーネントのつけ忘れ防止
[RequireComponent(typeof(Rigidbody))]
public class TankMovement : MonoBehaviour
{
    public float moveSpeed;
    public float turnSpeed;
    public float currentDuration;

    private Rigidbody rb;
    private float movementInputValue;
    private float turnInputValue;
    private float defaultMoveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        defaultMoveSpeed = moveSpeed;
    }

    
    void Update()
    {
        TankMove();
        TankTurn();

        currentDuration -= Time.deltaTime;

        if (currentDuration <= 0)
        {
            currentDuration = 0;

            ResetMoveSpeed();
        }
    }

    // 前進・後退
    void TankMove()
    {
        movementInputValue = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);
    }

    // 旋回
    void TankTurn()
    {
        turnInputValue = Input.GetAxis("Horizontal");
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRptation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRptation);
    }

    public void BoostMoveSpeed(float speedupRate, float duration)
    {
        moveSpeed *= speedupRate;
        currentDuration += duration;

        Debug.Log(moveSpeed);
    }

    private void ResetMoveSpeed()
    {
        moveSpeed = defaultMoveSpeed;
    }
}
