using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelContro : MonoBehaviour
{
    [SerializeField] int nextFase;
    public GameObject TelaDeVitoria;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //public int index;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if(nextFase != 0)
            {
                SceneManager.LoadScene(nextFase);
            }
            else
            {
                TelaDeVitoria.SetActive(true);
            }
            
        }
    }
}


