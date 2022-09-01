using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    [SerializeField] int MaxHP;
    private Animator anim;
    private int CurrentHP;

     private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        CurrentHP = MaxHP;
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

    private void Die()
    {
        Debug.Log("enemy is dead");

        anim.SetBool("IsDead", true);

        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionY;

        GetComponent<Collider2D>().enabled = false;
        
        this.enabled = false;
    }

}
