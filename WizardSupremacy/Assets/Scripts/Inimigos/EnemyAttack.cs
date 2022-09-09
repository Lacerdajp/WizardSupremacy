using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public PlayerMovement playerMovement;
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
            playerMovement.KBcounter = playerMovement.KBtotaltime;
            if(other.transform.position.x <= transform.position.x)
            {
                playerMovement.KockFromRight = true;
            }
            if(other.transform.position.x >= transform.position.x)
            {
                playerMovement.KockFromRight = false;
            }
            other.gameObject.GetComponent<PlayerHP>().GetDamage(GetComponent<Enemy>().getDanoInimigo());
        }
    }
}
