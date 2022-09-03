using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private string LevelAtual;

    public void Jogar()
    {
        Debug.Log(LevelAtual);
        SceneManager.LoadScene("Level1");
    }
    public void Sair()
    {
        Debug.Log("Você saiu!");
    }
}
