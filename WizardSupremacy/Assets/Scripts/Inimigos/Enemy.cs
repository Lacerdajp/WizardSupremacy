using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int MaxHP;
    [SerializeField] int DanoInimigo;
    private Animator anim;
    [SerializeField] public bool isAlive;
    private int CurrentHP;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        CurrentHP = MaxHP;
        isAlive = true;
    }

   void Update()
    {
        

    }
    public void TakeDmg(int damage)
    {
        CurrentHP -= damage;

        anim.SetTrigger("Hurt");

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
}