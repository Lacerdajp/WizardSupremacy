using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] int MaxHP; //VidaMAxima
    [SerializeField] int DanoInimigo;//DanoGerado
    public Transform Player; //jogador
    [SerializeField] public bool isAlive;//VerificaSe está vivo
    private Rigidbody2D rb;//fisica a se alterar
    public float knockback = 10;
    public float knockbackup = 2;
    [SerializeField] float AgroRange;
    [SerializeField] private LayerMask groundLayer;
    public Transform barraVerde;
    public GameObject objetoBarra;
    [SerializeField] float SpeedMov;


    private SpriteRenderer sprite;
    //private SlimeMoviment Mov;
    private int CurrentHP;//HPAtual
    private Animator anim;//animação
    private Vector3 escalaBarra;
    private float percentual;
    private BoxCollider2D boxcollider;
    //[SerializeField] Transform Personagem;
    private bool facingRight = false;
    private float TempoPulo;
    private float YSpeed;
    

    public int CurrentHP1 { get => CurrentHP; set => CurrentHP = value; }
    public SpriteRenderer Sprite { get => sprite; set => sprite = value; }

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        CurrentHP = MaxHP;
        isAlive = true;
        //Mov = GetComponent<SlimeMoviment>();
        escalaBarra = barraVerde.localScale;
        percentual = escalaBarra.x/CurrentHP;
        boxcollider = GetComponent<BoxCollider2D>();
        TempoPulo = 2;
        YSpeed = 50 * Time.deltaTime;
        sprite = GetComponent<SpriteRenderer>();

    }
   

   void Update()
    {
        if (isAlive)
        {
            if (Player)
            {
                //dist�ncia do jogador
                float distDoPlayer = Vector2.Distance(transform.position, Player.position);
                TempoPulo = TempoPulo - TempoPulo * Time.deltaTime;
                //Flip
                if (rb.position.x < Player.position.x && !facingRight)
                {
                    Flip();
                }
                else if (rb.position.x > Player.position.x && facingRight)
                {
                    Flip();
                }
                //Persegue
                if (distDoPlayer < AgroRange)
                {
                    ChasePlayer();
                }
                //n�o persegue
                else
                {
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
        Destroy(gameObject, 1f);
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
    private void Flip()
    {
        Vector3 currentscale = transform.localScale;
        currentscale.x *= -1;
        transform.localScale = currentscale;
        facingRight = !facingRight;
    }
    //altera de acordo com  o vilão
    void ChasePlayer()
    {
        if (rb.position.x < Player.position.x)
        {

            if (isGrounded() && TempoPulo < 2)
            {
                rb.velocity = new Vector2(SpeedMov, 0);
                rb.AddForce(Vector2.up * YSpeed);
            }

        }
        else
        {

            if (isGrounded() && TempoPulo < 2)
            {

                rb.velocity = new Vector2(-SpeedMov, 0);
                rb.AddForce(Vector2.up * YSpeed);
            }
        }

        if (isGrounded())
        {
            TempoPulo = 2;
        }
    }
    void StopChasePlayer()
    {
        rb.velocity = new Vector2(0, -1);
    }
}
