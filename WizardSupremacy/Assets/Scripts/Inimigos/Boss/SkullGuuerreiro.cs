using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullGuuerreiro : Enemy
{
    private float TempoAtaque;
    [SerializeField] Transform meleeRange;
    [SerializeField] LayerMask PlayerLayer;
    // Start is called before the first frame update
    [SerializeField] CircleCollider2D circle;
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
        base.ChasePlayer();
        if (distDoPlayer < 6)
        {
            anim.SetBool("IsRunning", false);
            if (TempoAtaque < 0)
            {
                anim.SetTrigger("Attack");
                MeleeAttack();
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

            Debug.Log("Tomando Dano");
            player.GetComponent<PlayerHP>().GetDamage(getDanoInimigo());
        }
        TempoAtaque = 2;
    }
}
