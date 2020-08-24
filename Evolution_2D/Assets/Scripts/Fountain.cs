using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fountain : MonoBehaviour
{
    public float delay = 0.5f;
    public float damage = 0.10f;
    public float heal = 0.5f;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
           
        }
        else if(collision.CompareTag("Enemy"))
        {
            
        }
    }

}
