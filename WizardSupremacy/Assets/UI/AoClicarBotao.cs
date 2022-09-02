using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AoClicarBotao : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _img;
    [SerializeField] private Sprite _default, _pressed;
    private void LoadNextLevel()
    {
        SceneManager.LoadScene("Level1");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _img.sprite = _pressed;
        LoadNextLevel();
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        _img.sprite = _default;
    }
}
