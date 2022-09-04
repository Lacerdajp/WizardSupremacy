using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeMoviment : MonoBehaviour
{
    [SerializeField] Transform Personagem;
    [SerializeField] Rigidbody2D Slime;
    [SerializeField] float SpeedMov;
    [SerializeField] float AgroRange;
    private bool facingRight = false;
    [SerializeField] private LayerMask wallLayer;
    [SerializeField] private LayerMask groundLayer;
    private BoxCollider2D boxcollider;
    private Enemy Inimigo;
    private bool PausaPulo;
    private float TempoPulo;
    private float XSpeed;
    private float YSpeed;


    void Start()
    {
        Slime = GetComponent<Rigidbody2D>();
        boxcollider = GetComponent<BoxCollider2D>();
        Inimigo = GetComponent<Enemy>();
        XSpeed = 40 * Time.deltaTime;
        YSpeed = 50 * Time.deltaTime;
        TempoPulo = 2;
    }

    void Update()
    {
        if(Inimigo.isAlive)
        {
            if (Personagem)
            {
                //distância do jogador
                float distDoPlayer = Vector2.Distance(transform.position, Personagem.position);
                TempoPulo = TempoPulo - TempoPulo * Time.deltaTime;
                //Flip Slime
                if (Slime.position.x < Personagem.position.x && !facingRight)
                {
                    Flip();
                }
                else if (Slime.position.x > Personagem.position.x && facingRight)
                {
                    Flip();
                }
                //Slime persegue
                if (distDoPlayer < AgroRange)
                {
                    ChasePlayer();
                }
                //Slime não persegue
                else
                {
                    StopChasePlayer();
                }
            }
        }
        
    }

    void ChasePlayer()
    {
        if(Slime.position.x < Personagem.position.x)
        {
            
            if (isGrounded() && TempoPulo < 2)
            {
                Slime.velocity = new Vector2(SpeedMov, 5);
                Slime.AddForce(Vector2.up * YSpeed);
            }
            
        }
        else
        {
            
            if (isGrounded() && TempoPulo < 2)
            {
                
                Slime.velocity = new Vector2(-SpeedMov, 5);
                Slime.AddForce(Vector2.up * YSpeed);
            }
        }

        if(isGrounded())
        {
            TempoPulo = 2;
        }
    }
    void StopChasePlayer()
    {
        Slime.velocity = new Vector2(0, -1);
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
}
