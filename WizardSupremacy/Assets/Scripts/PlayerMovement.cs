using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxcollider;
    private bool facingRight = true;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float speed;
    private void Awake()
    {
       //Pega as referencias do objeto
       body = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
       boxcollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {   float HorizontalImput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(HorizontalImput*speed,body.velocity.y);
        //mudar a direcao do jogador (direita e esquerda)
        if(HorizontalImput > 0.01f && !facingRight)
        {
           Flip();
        }
        else if(HorizontalImput < -0.01f && facingRight)
        {
           Flip();
        }

        if(Input.GetKey(KeyCode.Space) && isGrounded())
        {
           Jump();
        }

        //definir parametro de animador
        anim.SetBool("Running", HorizontalImput != 0);
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
         body.velocity = new Vector2(body.velocity.x,speed); 
         anim.SetTrigger("Jump");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider.bounds.center,boxcollider.bounds.size,0,Vector2.down,0.1f,groundLayer);
        return raycastHit.collider != null;
    }
    //private bool onWall()
   // {
    //    RaycastHit2D raycastHit = Physics2D.BoxCast(boxcollider.bounds.center,boxcollider.bounds.size,0,new Vector2(transform.localScale.x, 0),0.1f,wallLayer);
   //     return raycastHit.collider != null;
   // }
}
