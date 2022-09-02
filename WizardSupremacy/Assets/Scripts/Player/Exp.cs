using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public static int Experiencia;
    public static int Nivel;
    public int MultiplicadorPorNivel, expInicial;
    public static int ExpNecessario;
    public Font Fonte;

    void Start()
    {
        Nivel = 0;
    }
    void Update()
    {
        ExpNecessario = expInicial+(MultiplicadorPorNivel*Nivel);
        if(Experiencia >= ExpNecessario)
        {
            Nivel = Nivel + 1;
            Experiencia = 0;
        }
    }
    /*void OnGui()
    {
        GUI.skin.font = Fonte;
        GUI.skin.label.fontSize = ScreenHeight / 15;
        
        GUI.label(new Rect(Screen.width/2 - Screen.width / 2.1f, Screen.height- Screen.height / 2.1f, Screen.width/1,5, Screen.height/4), "Nivel: " + Nivel);
        GUI.label(new Rect(Screen.width / 2 - Screen.width / 2.1f, Screen.height - Screen.height / 2.5f, Screen.width / 1, 5, Screen.height / 4), "Nivel: " + Experiencia);
        GUI.label(new Rect(Screen.width / 2 - Screen.width / 2.1f, Screen.height - Screen.height / 3f, Screen.width / 1, 5, Screen.height / 4), "Nivel: " + (ExpNecessario - Experiencia));
    }*/
}