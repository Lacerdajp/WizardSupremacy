using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffectManager : MonoBehaviour
{
    private Enemy enemy;
    public List<int> burnTickTimers = new List<int>();

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    public void ApplyBurn(int ticks)
    {
        if(burnTickTimers.Count <= 0)
        {
            burnTickTimers.Add(ticks);
            StartCoroutine(Burn());
        }
        else
        {
            burnTickTimers.Add(ticks);
        }
    }   

    IEnumerator Burn()
    {
        while(burnTickTimers.Count > 0)
        {
            for(int i = 0; i < burnTickTimers.Count; i++)
            {
                burnTickTimers[i]--;
            }
            StartCoroutine(BurnDamage());
            Debug.Log(enemy.name + "Queimou 1 de dano!");
            enemy.CurrentHP1 -= 1;
            burnTickTimers.RemoveAll(i => i == 0);
            yield return new WaitForSeconds(0.75f);
        }
    }
    IEnumerator BurnDamage()
    {
        GetComponent<Enemy>().Sprite.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        GetComponent<Enemy>().Sprite.color = Color.white;
    }
}
