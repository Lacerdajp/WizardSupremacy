using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int MaxHP; //VidaMAxima
    [SerializeField] int DanoInimigo;//DanoGerado
    public Transform Player; //jogador
    public bool isAlive;//VerificaSe está vivo
    public Rigidbody2D rb;//fisica a se alterar
    public float knockback = 10;
    public float knockbackup = 2;
    [SerializeField] float AgroRange;
    [SerializeField] private LayerMask groundLayer;
    public Transform barraVerde;
    public GameObject objetoBarra;
    [SerializeField] public float SpeedMov;
    public float JumpSpeed;
    private int side;


    private SpriteRenderer sprite;
    [SerializeField] int CurrentHP;//HPAtual
    public Animator anim;//animação
    private Vector3 escalaBarra;
    private float percentual;
    public BoxCollider2D boxcollider;
    private bool facingRight = false;
    public int playerInRange;
    public float distDoPlayer;
    

    public int CurrentHP1 { get => CurrentHP; set => CurrentHP = value; }
    public SpriteRenderer Sprite { get => sprite; set => sprite = value; }
    public int Side { get => side; set => side = value; }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    virtual public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CurrentHP = MaxHP;
        isAlive = true;
        //Mov = GetComponent<SlimeMoviment>();
        escalaBarra = barraVerde.localScale;
        percentual = escalaBarra.x/CurrentHP;
        boxcollider = GetComponent<BoxCollider2D>();
        JumpSpeed = 50 * Time.deltaTime;
        side = -1;
        sprite = GetComponent<SpriteRenderer>();
        playerInRange = 0;

    }
   

   virtual public void Update()
    {
        if (isAlive)
        {
            if (Player)
            {
                //distancia do jogador
                distDoPlayer = Vector2.Distance(transform.position, Player.position);

                //Flip
                if (rb.position.x < Player.position.x && !facingRight)
                {
                    Flip();
                    side = 1;
                }
                else if (rb.position.x > Player.position.x && facingRight)
                {
                    Flip();
                    side = -1;
                }
                //Persegue
                if (distDoPlayer < AgroRange)
                {
                    playerInRange = 1;
                    ChasePlayer();
                }
                //nao persegue
                else
                {
                    playerInRange = 0;
                    StopChasePlayer();
                }
            }
        }

        if (!(isGrounded()) && isAlive == false)
        {
            UnityEngine.Object.Destroy(gameObject, 3.5f);
        }

        if (CurrentHP <= 0)
        {
            Die();
        }
        UpdateBarra();
    }
    void UpdateBarra()
    {
        if (CurrentHP > 0)
        {
            escalaBarra.x = percentual * CurrentHP;
            barraVerde.localScale = escalaBarra;
        }
        else
        {
            escalaBarra.x = 0;
            barraVerde.localScale = escalaBarra;
        }
    }
    public void TakeDmg(int damage)
    {
        CurrentHP -= damage;
        anim.SetTrigger("Hurt");
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
        Destroy(gameObject, 3f);
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
    public bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider.bounds.center, boxcollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }
    public void Flip()
    {
        Vector3 currentscale = transform.localScale;
        currentscale.x *= -1;
        transform.localScale = currentscale;
        facingRight = !facingRight;
    }
    //altera de acordo com  o vilão
    virtual public void ChasePlayer()
    {
        anim.SetBool("IsRunning", true);
        if (rb.position.x < Player.position.x)
        {
            rb.velocity = new Vector2(SpeedMov, 0);
            rb.AddForce(Vector2.up * JumpSpeed);

        }
        else
        {
            rb.velocity = new Vector2(-SpeedMov, 0);
            rb.AddForce(Vector2.up * JumpSpeed);
        }

    }
        void StopChasePlayer()
    {
        anim.SetBool("IsRunning", false);
        rb.velocity = new Vector2(0, -1);
    }
}
