using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnFireball_Hor : MonoBehaviour
{
    public PlayerHP hP;
    //Fireball
    private float Fireball_cooldown = 2;
    private float Fireball_cooldowntimer = 0;
    public Transform Fireball;
    public Transform pivot;
    public int side = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            side = 1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            side = -1;
        }
        Fireball_cooldowntimer -= Time.deltaTime;
        if (Input.GetMouseButton(1) && Fireball_cooldowntimer <= 0 && hP.isLive)
        {
            Transform obj = Instantiate(Fireball, pivot.position, transform.rotation);
            obj.right = Vector2.right * side;
            Fireball_cooldowntimer = Fireball_cooldown;
        }
    }
}
