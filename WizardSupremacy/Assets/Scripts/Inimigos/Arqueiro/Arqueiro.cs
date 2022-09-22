using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arqueiro : Enemy
{
    private float TempoAtaque;
    public bool flag = false;

    public override void Start()
    {
        base.Start();
        TempoAtaque = 3;
    }
    public override void Update()
    {
        base.Update();
        TempoAtaque -= Time.deltaTime;
    }
    public override void ChasePlayer()
    {

        if(distDoPlayer > 15)
        {
            anim.SetBool("IsRunning", true);
            if (rb.position.x < Player.position.x)
            {
                rb.velocity = new Vector2(SpeedMov, 0);
                rb.AddForce(Vector2.up * JumpSpeed);

            }
            else
            {
                rb.velocity = new Vector2(-SpeedMov, 0);
                rb.AddForce(Vector2.up * JumpSpeed);
            }
        }
        else if (distDoPlayer < 10)
        {
            anim.SetBool("IsRunning", true);
            if (rb.position.x < Player.position.x)
            {
                rb.velocity = new Vector2(-SpeedMov, 0);
                rb.AddForce(Vector2.up * JumpSpeed);

            }
            else
            {
                rb.velocity = new Vector2(SpeedMov, 0);
                rb.AddForce(Vector2.up * JumpSpeed);
            }
        }
        else
        {
            anim.SetBool("IsRunning", false);
            if(TempoAtaque < 0)
            {
                anim.SetTrigger("Attack");
                flag = true;
                TempoAtaque = 3;
            }
            
        }


    }
    void StopChasePlayer()
    {
        anim.SetBool("IsRunning", false);
        rb.velocity = new Vector2(0, -1);
    }
}
