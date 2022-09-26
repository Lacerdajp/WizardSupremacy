using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        TempoAtaque = 4;

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
                MeleeAttack();
            }
        }
    }
    public void MeleeAttack()
    {
        //animacao
        anim.SetTrigger("Attack");
        //detectar inimigos
        Collider2D hitenemies = Physics2D.OverlapCircle(meleeRange.position, circle.GetComponent<CircleCollider2D>().radius, PlayerLayer);
        //danificando eles
        if (hitenemies.CompareTag("Player"))
        {
            if (TempoAtaque < 0)
            {
                Debug.Log("Tomando Dano");
                hitenemies.GetComponent<PlayerHP>().GetDamage(getDanoInimigo());
                TempoAtaque = 4;
            }
        }

    }
}
