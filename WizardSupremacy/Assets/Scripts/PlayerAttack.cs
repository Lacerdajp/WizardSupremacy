using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float AC;
    private Animator anim;
    private PlayerMovement mov;
    private float cooldowntimer = Mathf.Infinity;
    public Transform attackpoint;
    [SerializeField] private float range; //= 0.7f;
    [SerializeField] private LayerMask EnemyLayers;
    [SerializeField] private int AttackPower;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        mov = GetComponent<PlayerMovement>();
     }
 
     private void Update()
     {
        if(Input.GetMouseButton(0) && cooldowntimer >= AC)
        {
            Attack();
        }
        cooldowntimer += Time.deltaTime;
    }

    private void Attack()
    {
        //animacao
        anim.SetTrigger("attack");
        cooldowntimer = 0;
        //detectar inimigos
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position, range, EnemyLayers);
        //danificando eles
        foreach(Collider2D enemy in hitenemies)
        {
            Debug.Log("toma flinha da puta " + enemy.name);

            enemy.GetComponent<EnemyHP>().TakeDmg(AttackPower);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(attackpoint == null)
            return; 

        Gizmos.DrawWireSphere(attackpoint.position, range);  
    }
}