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
    [SerializeField] Transform Posicao1;
    [SerializeField] Transform Posicao2;
    private bool Chao;
    private bool PausaPulo;
    private float TempoPulo;
    private float XSpeed;
    private float YSpeed;
    

    void Start()
    {
        Slime = GetComponent<Rigidbody2D>();

        XSpeed = 40 * Time.deltaTime;
        YSpeed = 50 * Time.deltaTime;
        TempoPulo = 4;
        AgroRange = 4;
    }

    void Update()
    {
        if (Personagem)
        {

        
        Raycast();
        //distância do jogador
        float distDoPlayer = Vector2.Distance(transform.position, Personagem.position);
        TempoPulo -= TempoPulo * Time.deltaTime;
        if(distDoPlayer < AgroRange)
        {
            ChasePlayer();
        }
        else
        {
            StopChasePlayer();
        }
       }
    }

    void ChasePlayer()
    {
        if(Slime.position.x < Personagem.position.x)
        {
            if(Chao == true && TempoPulo < 4)
            {
                Slime.velocity = new Vector2(SpeedMov, 0);
                Slime.AddForce(Vector2.up * YSpeed);
             
            }
            
        }
        else
        {
            
            if (Chao == true && TempoPulo < 4)
            {
                
                Slime.velocity = new Vector2(-SpeedMov, 0);
                Slime.AddForce(Vector2.up * YSpeed);
            }
        }

        if(Chao == false)
        {
            TempoPulo = 4;
        }
    }
    void StopChasePlayer()
    {
        Slime.velocity = new Vector2(0, 0);
    }
    void Raycast()
    {
        if(Physics2D.Linecast(Posicao1.position, Posicao2.position))
        {
            Chao = true;
        }
        else
        {
            Chao = false;
        }
    }
}
