using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaBehavior : MonoBehaviour
{
    private AudioSource Som;
    private CircleCollider2D Circle;
    [SerializeField] private LayerMask PlayerLayer;
    [SerializeField] private int AttackPower = 5;
    [SerializeField] private float SpeedX;

    private void Awake()
    {
        Som = GetComponent<AudioSource>();
    }
    void Start()
    {
        Som.Play();
        Circle = GetComponent<CircleCollider2D>();
        GetComponent<Rigidbody2D>().AddForce(transform.right * SpeedX);
        Destroy(gameObject, 5);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Collider2D hitplayer = collision.GetComponent<Collider2D>();
            hitplayer.GetComponent<PlayerHP>().GetDamage(AttackPower);

            Destroy(gameObject);
        }
        else if (collision.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }

    }
}
