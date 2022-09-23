using System.Collections;
using System.Collections.Generic;
using Unity.Burst.Intrinsics;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Arqueiro : Enemy
{
    private float TempoAtaque;
    private bool flag = false;
    private float flecha_cooldown = 3;
    private float flecha_cooldowntimer = 3;
    public Transform Flecha;
    public Transform pivot;

    public bool Flag { get => flag; set => flag = value; }
    public override void Start()
    {
        base.Start();
        TempoAtaque = 3;
    }
    public override void Update()
    {
        base.Update();
        TempoAtaque -= Time.deltaTime;
        flecha_cooldowntimer -= Time.deltaTime;
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
                Flag = true;
                Spawn();
                TempoAtaque = 3;
                
            }
            
        }


    }
    void Spawn()
    {
        if (Flag == true)
        {
            StartCoroutine(AtirarFlecha(1));
        }
    }
    IEnumerator AtirarFlecha(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);
        //Spawn Flecha
        if (flecha_cooldowntimer < 0)
        {
            Transform obj = Instantiate(Flecha, pivot.position, transform.rotation);
            obj.right = Vector2.right * GetComponent<Arqueiro>().Side;
            flecha_cooldowntimer = flecha_cooldown;
        }
        Flag = false;
    }
}
