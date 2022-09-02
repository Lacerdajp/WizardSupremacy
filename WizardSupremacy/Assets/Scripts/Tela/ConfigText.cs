using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConfigText : MonoBehaviour
{
    public static ConfigText instance;
    private bool gameOver=false;

    public GameObject gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        gameOver = true;
        gameOverText.SetActive(true);
    }
}
