using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    void Start()
    {
    }

    void Update()
    {
    

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.CompareTag("Player") && GetComponent<Enemy>().getisAlive() == true)
        {
            //Debug.Log("Encostou!");
           
            //other.gameObject.GetComponent<PlayerMovement>().MovimentDano();
            other.gameObject.GetComponent<PlayerHP>().GetDamage(GetComponent<Enemy>().getDanoInimigo());
            //Debug.Log("Player levou " + GetComponent<Enemy>().getDanoInimigo() + " de dano!");
        }
    }
}
