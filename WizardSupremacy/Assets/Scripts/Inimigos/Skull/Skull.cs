using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : Enemy
{
    private float TempoAtaque;
    [SerializeField] Transform meleeRange;
    [SerializeField] LayerMask PlayerLayer;
    [SerializeField] float range;
    [SerializeField] CircleCollider2D circle;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        TempoAtaque = 2;

    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
        TempoAtaque -= Time.deltaTime;
    }

    public override void ChasePlayer()
    {
        anim.SetBool("IsRunning", true);
        
        if (distDoPlayer < 4)
        {
            anim.SetBool("IsRunning", false);
            rb.velocity = new Vector2(0, 0);
            if (TempoAtaque < 0)
            {
                anim.SetTrigger("Attack");
                MeleeAttack();
                TempoAtaque = 4;
            }
        }
        else
        {
            anim.SetBool("IsRunning", true);
            if (rb.position.x < Player.position.x && anim.GetBool("IsRunning"))
            {
                rb.velocity = new Vector2(SpeedMov, 0);
                rb.AddForce(Vector2.up * JumpSpeed);

            }
            else if (rb.position.x > Player.position.x && anim.GetBool("IsRunning"))
            {
                rb.velocity = new Vector2(-SpeedMov, 0);
                rb.AddForce(Vector2.up * JumpSpeed);
            }
        }
    }
    public void MeleeAttack()
    {
        //animacao

        //detectar inimigos
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(meleeRange.position, circle.GetComponent<CircleCollider2D>().radius, PlayerLayer);
        //danificando eles
        foreach (Collider2D player in hitenemies)
        {
            if(player != null && TempoAtaque < 0)
            {
                Debug.Log("Tomando Dano");
                player.GetComponent<PlayerHP>().GetDamage(getDanoInimigo());
            }
        }
        TempoAtaque = 2;
    }
}

