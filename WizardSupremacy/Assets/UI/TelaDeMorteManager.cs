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
        SceneManager.LoadScene(LevelAtual);
    }
    public void VoltarAoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
