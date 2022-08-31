using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float AC;
    private Animator anim;
    private PlayerMovement mov;
    private float cooldowntimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        mov = GetComponent<PlayerMovement>();
     }
 
     private void Update()
     {
        if(Input.GetMouseButton(0) && cooldowntimer >= AC)
        {
            Attack();
        }
        cooldowntimer += Time.deltaTime;
    }

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldowntimer = 0;
    }
}