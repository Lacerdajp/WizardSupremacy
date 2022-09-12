using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float AC;
    private Animator anim;
    public PlayerHP hP;
    private PlayerMovement mov;

    //MeleeAttack
    private float cooldowntimer = 0;
    private float tempoDeAtaque = 0;
    public Transform attackpoint;
    [SerializeField] private LayerMask EnemyLayers;
    [SerializeField] private int AttackPower;
    private AudioSource Melee_som;
    [SerializeField] private float range; //= 0.7f;

    //Fireball
    private float Fireball_cooldown = 3;
    private float Fireball_cooldowntimer = 0;


    private void Awake()
    {
        Melee_som = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        mov = GetComponent<PlayerMovement>();
        hP = GetComponent<PlayerHP>();
    }
 
     private void Update()
     {
         
        cooldowntimer -=  Time.deltaTime;
        Fireball_cooldowntimer -= Time.deltaTime;
        tempoDeAtaque -= Time.deltaTime;

        if (Input.GetMouseButton(0) && cooldowntimer <= 0 && hP.isLive)
        {
            Melee_som.Play();
            MeleeAttack();
            cooldowntimer = AC;
        }
        if (Input.GetMouseButton(1) && Fireball_cooldowntimer <= 0 && hP.isLive)
        {
            RangeAttack();
            Fireball_cooldowntimer = Fireball_cooldown;
        }
    }

    private void MeleeAttack()
    {
        //animacao
        anim.SetTrigger("MeleeAttack");
        cooldowntimer = 3;
        tempoDeAtaque = 2;
            //detectar inimigos
            Collider2D[] hitenemies = Physics2D.OverlapCircleAll(attackpoint.position, range, EnemyLayers);

            //danificando eles
            foreach(Collider2D enemy in hitenemies)
            {
                Debug.Log("toma filha da puta " + enemy.name);
                if (enemy.GetComponent<StatusEffectManager>() != null)
                {
                    enemy.GetComponent<StatusEffectManager>().ApplyBurn(2);
                }
                enemy.GetComponent<Enemy>().TakeDmg(AttackPower);
            }
    }
    private void OnDrawGizmosSelected()
    {
        if(attackpoint == null)
            return; 

        Gizmos.DrawWireSphere(attackpoint.position, range);  
    }

    private void RangeAttack()
    {
        //Animação
        anim.SetTrigger("RangeAttack");
    }

}