using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfigText : MonoBehaviour
{
    public static ConfigText instance;
    private bool gameOver=false;

    public GameObject TelaDeMorte;
    void Start()
    {
        instance = this;
    }

    void Update()
    {
        
    }
    public void GameOver()
    {
        gameOver = true;
        TelaDeMorte.SetActive(true);
    }
}
