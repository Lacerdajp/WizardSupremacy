using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] public int VidaMax;
    [SerializeField] public int VidaAtual;

    void Start()
    {
        VidaAtual = VidaMax;
    }
    void Update()
    {
        
    }

    public void GetDamage(int Dano)
    {
        VidaAtual = VidaAtual - Dano;
        
        if(VidaAtual <= 0)
        {

            Debug.Log("Game Over");
            SceneManager.LoadScene("Main Menu");
        
        }
    }
}
