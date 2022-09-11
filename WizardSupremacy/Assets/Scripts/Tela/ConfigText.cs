using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfigText : MonoBehaviour
{
    public static ConfigText instance;

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
        TelaDeMorte.SetActive(true);
    }
}
