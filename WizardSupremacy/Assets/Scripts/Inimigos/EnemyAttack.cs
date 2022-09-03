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
            other.gameObject.GetComponent<PlayerHP>().GetDamage(GetComponent<Enemy>().getDanoInimigo());
        }
    }
}
