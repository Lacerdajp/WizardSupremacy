using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float AC;
    private Animator anim;
    private PlayerMovement mov;
    private float cooldowntimer = 0;
    public Transform attackpoint;
    [SerializeField] private float range; //= 0.7f;
    [SerializeField] private LayerMask EnemyLayers;
    [SerializeField] private int AttackPower;
    private AudioSource som;
    public PlayerHP hP;


    private void Awake()
    {
        som = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        mov = GetComponent<PlayerMovement>();
        hP = GetComponent<PlayerHP>();
    }
 
     private void Update()
     {
        cooldowntimer -=  Time.deltaTime;
        if(Input.GetMouseButton(0) && cooldowntimer <= 0 && hP.isLive)
        {
            som.Play();
            Attack();
            cooldowntimer = AC;
        }
    }

    private void Attack()
    {
        //animacao
        anim.SetTrigger("attack");
        cooldowntimer = 1;
        //detectar inimigos
        Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position, range, EnemyLayers);
        //danificando eles
        foreach(Collider2D enemy in hitenemies)
        {
            Debug.Log("toma filha da puta " + enemy.name);

            enemy.GetComponent<Enemy>().TakeDmg(AttackPower);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if(attackpoint == null)
            return; 

        Gizmos.DrawWireSphere(attackpoint.position, range);  
    }
}