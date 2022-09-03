using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaDeMorteManager : MonoBehaviour
{
    [SerializeField] private GameObject MenuDeMorte;
    [SerializeField] private string LevelAtual;

    public void Renascer()
    {
        Debug.Log("oi");
        SceneManager.LoadScene(LevelAtual);
    }
    public void VoltarAoMenu()
    {
        Debug.Log("oi");
        SceneManager.LoadScene(0);
    }
}
