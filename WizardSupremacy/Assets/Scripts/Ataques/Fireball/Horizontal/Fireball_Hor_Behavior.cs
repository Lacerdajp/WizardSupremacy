using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Fireball_Hor_Behavior : MonoBehaviour
{   
    private AudioSource Som;
    private CircleCollider2D CircleCollider2D;
    private Enemy enemy;
    [SerializeField] private LayerMask EnemyLayers;
    private int AttackPower = 10;

    private void Awake()
    {
        Som = GetComponent<AudioSource>();
    }
    void Start()
    {
        Som.Play();
        GetComponent<Rigidbody2D>().AddForce(transform.right * 800);
        Destroy(gameObject, 2);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Inimigo") || collision.CompareTag("Ground"))
        {
            Collider2D[] hitenemies = Physics2D.OverlapCircleAll(this.transform.position, GetComponent<CircleCollider2D>().radius, EnemyLayers);
            foreach (Collider2D enemy in hitenemies)
            {
                enemy.GetComponent<Enemy>().TakeDmg(AttackPower);
                if (enemy.GetComponent<StatusEffectManager>() != null)
                {
                    enemy.GetComponent<StatusEffectManager>().ApplyBurn(5);
                }
            }
            Destroy(gameObject);
        }
        
    }
}
