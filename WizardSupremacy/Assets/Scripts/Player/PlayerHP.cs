using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{

    [SerializeField] public int VidaMax;
    [SerializeField] public int VidaAtual;
    private Rigidbody2D body;
    private Animator anim;
    private BoxCollider2D boxcollider;
    public bool isLive;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxcollider = GetComponent<BoxCollider2D>();
    }
    void Start()
    {
        VidaAtual = VidaMax;
        isLive = true;
    }
    void Update()
    {
        
    }

    public void GetDamage(int Dano)
    {
        VidaAtual = VidaAtual - Dano;
        anim.SetTrigger("Hurt");
        
        if(VidaAtual <= 0)
        {
            Death();
            
        }
    }
    public void Death()
    {
        Debug.Log("Game Over");
        isLive = false;
        anim.SetTrigger("Die");
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        UnityEngine.Object.Destroy(gameObject,3.5f);
        GetComponent<Collider2D>().enabled = false;
        ConfigText.instance.GameOver();
    }
}
