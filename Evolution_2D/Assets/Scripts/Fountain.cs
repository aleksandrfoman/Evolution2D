using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class Fountain : MonoBehaviour
{
    public float damage = 2.5f;
    public float healFountain = 2.5f;
    public float delay = 1f;
    public float timerHeal = 0f;
    public float timerDamage = 0f;
    public Transform player;

    private void OnTriggerStay2D(Collider2D collision)
    {
        timerHeal += Time.deltaTime;
        timerDamage += Time.deltaTime;

        if (collision.CompareTag("Player"))
        {
            if (timerHeal >= delay)
            {
                collision.GetComponent<PlayerController>().AddHp(healFountain);
                timerHeal = 0f;
            }
        }

        if (collision.CompareTag("Enemy"))
        {
            if (timerDamage >= delay)
            {
                collision.GetComponent<Enemy>().TakeDamageEnemy(damage);
                timerDamage = 0f;
            }
        }
    }
}
