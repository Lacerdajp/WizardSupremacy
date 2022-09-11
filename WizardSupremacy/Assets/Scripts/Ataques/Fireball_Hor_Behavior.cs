using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class Fireball_Hor_Behavior : MonoBehaviour
{   
    private AudioSource Som;
    private CircleCollider2D CircleCollider2D;
    [SerializeField] private LayerMask EnemyLayers;
    private int AttackPower = 10;

    private void Awake()
    {
        Som = GetComponent<AudioSource>();
    }
    void Start()
    {
        Debug.Log(this.transform.position);
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
            }
            Destroy(gameObject);
        }
        
    }
}
