using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Slime : Enemy
{
    private float RecargaPulo;
    public float SpeedY;
    public float SpeedX;

    public override void Start()
    {
        base.Start();
        SpeedMov = 3;
        RecargaPulo = 2;
        SpeedX = 1;
        SpeedY = 5;
    }

    public override void Update()
    {
        base.Update();
        RecargaPulo -= Time.deltaTime;
    }

    public override void ChasePlayer()
    {
            if (rb.position.x < Player.position.x)
            {
                rb.velocity = new Vector2(SpeedMov, 0);
                rb.AddForce(Vector2.up * JumpSpeed);
                if(isGrounded() && RecargaPulo < 0)
                {
                    //StartCoroutine(Pulo(1));
                }
            }
            else
            {
                rb.velocity = new Vector2(-SpeedMov, 0);
                rb.AddForce(Vector2.up * JumpSpeed);
                if (isGrounded() && RecargaPulo < 0)
                {
                    //StartCoroutine(Pulo(-1));
                }
            }
            
        if (!isGrounded())
        {
            RecargaPulo = 3;
        }
    }
    IEnumerator Pulo(int side)
    {
        if (isGrounded() && RecargaPulo < 0)
        {
            Debug.Log("pulando");
            rb.velocity = new Vector2(0, 0);
            yield return new WaitForSeconds(1);
            SpeedX = SpeedX * side;
            rb.velocity = new Vector2(SpeedX, 0);
            rb.AddForce(Vector2.up * SpeedY);
            RecargaPulo = 3;
        }
    }
}
