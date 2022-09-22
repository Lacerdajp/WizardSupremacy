using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaBehavior : MonoBehaviour
{
    private AudioSource Som;
    private CircleCollider2D CircleCollider2D;
    private PlayerHP hP;
    [SerializeField] private LayerMask EnemyLayers;
    private int AttackPower = 5;

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
        if (collision.CompareTag("Player") || collision.CompareTag("Ground"))
        {
            Collider2D[] hitenemies = Physics2D.OverlapCircleAll(this.transform.position, GetComponent<CircleCollider2D>().radius, EnemyLayers);
            foreach (Collider2D hP in hitenemies)
            {
                hP.GetComponent<PlayerHP>().GetDamage(AttackPower);
            }
            Destroy(gameObject);
        }

    }
}
