using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxcollider;
    private bool facingRight = true;
    public float KBforce;
    public float KBcounter;
    public float KBtotaltime;
    public bool KockFromRight;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed;
    public PlayerHP hP;
    private void Awake()
    {
       //Pega as referencias do objeto
       body = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
       boxcollider = GetComponent<BoxCollider2D>();
        hP= GetComponent<PlayerHP>();
    }
    private void Update()
    {
            
            float HorizontalInput = Input.GetAxis("Horizontal");
            if(KBcounter <= 0)
            {
                body.velocity = new Vector2(HorizontalInput * speed, body.velocity.y);
            }
            else
            {
                if(KockFromRight == true)
                {
                     body.velocity = new Vector2(-KBforce, 1);
 
                }
                if(KockFromRight == false)
                {
                    body.velocity = new Vector2(KBforce, 1);
                }
                KBcounter -= Time.deltaTime;
            }
            
            //mudar a direcao do jogador (direita e esquerda)
            if (HorizontalInput > 0.01f && !facingRight && hP.isLive)
            {
                Flip();
            }
            else if (HorizontalInput < -0.01f && facingRight && hP.isLive)
            {
                Flip();
            }

            if (Input.GetKey(KeyCode.Space) && isGrounded() && hP.isLive)
            {
                Jump();
            }

            //definir parametro de animador
            //anim.setBool("Jumping", (!isGrounded()));
            anim.SetBool("Running", HorizontalInput != 0);
            anim.SetBool("Grounded", isGrounded());
      
    }

    private void Flip()
    {
      Vector3 currentscale = transform.localScale;
      currentscale.x *= -1;
      transform.localScale = currentscale;
      facingRight =! facingRight;
    }

    private void Jump()
    {
         body.velocity = new Vector2(body.velocity.x,15); 
         anim.SetTrigger("Jump");
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider.bounds.center,boxcollider.bounds.size,0,Vector2.down,0.1f,groundLayer);
        return raycastHit.collider != null;
    }
    
    //public void MovimentDano()
    //{
        
    //    body.AddForce(new Vector2(100,0), ForceMode2D.Impulse);
    //}
   
    /*private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider.bounds.center,boxcollider.bounds.size,0,new Vector2(transform.localScale.x, 0),0.1f,wallLayer);
       return raycastHit.collider != null;
    }*/
}
