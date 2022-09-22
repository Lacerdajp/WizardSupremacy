using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnFlecha : MonoBehaviour
{
    private float flecha_cooldown = 3;
    private float flecha_cooldowntimer = 3;
    private Arqueiro arq;
    private Animator anim;
    public Transform Flecha;
    public Transform pivot;

    void Start()
    {
        arq = GetComponent<Arqueiro>();
        anim = GetComponent<Arqueiro>().anim;
    }
    void Update()
    {
        flecha_cooldowntimer -= Time.deltaTime;
        if(arq.flag)
        {
            StartCoroutine(AtirarFlecha(anim.GetCurrentAnimatorStateInfo(0).length));
        }
        
    }

    IEnumerator AtirarFlecha(float _delay = 0)
    {
        yield return new WaitForSeconds(_delay);
        //Spawn Flecha
        if(flecha_cooldowntimer < 0)
        {
            Transform obj = Instantiate(Flecha, pivot.position, transform.rotation);
            obj.right = Vector2.right * GetComponent<Arqueiro>().Side;
            flecha_cooldowntimer = flecha_cooldown;
        }
        arq.flag = false;
    }
}
