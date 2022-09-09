using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int MaxHP;
    [SerializeField] int DanoInimigo;
    private Animator anim;
    [SerializeField] public bool isAlive;
    private Rigidbody2D rb;
    public float knockback = 10;
    public float knockbackup = 2;
    private int CurrentHP;
    private SlimeMoviment Mov;
    public Transform Player;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CurrentHP = MaxHP;
        isAlive = true;
        Mov = GetComponent<SlimeMoviment>();
    }

   void Update()
    {
        if(!(Mov.isGrounded()) && isAlive == false)
        {
            UnityEngine.Object.Destroy(gameObject, 3.5f);
        }

    }
    public void TakeDmg(int damage)
    {
        CurrentHP -= damage;

        anim.SetTrigger("Hurt");
        KnockBack();

        if(CurrentHP <= 0)
        {
            Die();
        }

    }
    
    public int getDanoInimigo()
    {
        return DanoInimigo;
    }

    private void Die()
    {
        Debug.Log("enemy is dead");

        anim.SetBool("IsDead", true);
        isAlive = false;

        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        GetComponent<Collider2D>().enabled = false;
        
        this.enabled = false;
    }

    public bool getisAlive()
    {
        return isAlive;
    }
    private void KnockBack(){
        Vector2 knockbackDirection = new Vector2(transform.position.x - Player.transform.position.x,0);
        rb.velocity = new Vector2(knockbackDirection.x,knockbackup)* knockback;
    }
}
