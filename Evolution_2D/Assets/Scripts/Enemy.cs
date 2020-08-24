using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{
    [Header("Характеристики")]
    public float hpEnemy = 5;
    public float damageEnemy = 5f;
    public float expEnemy = 10f;
    public float goldEnemy = 5f;
    [Header("Движение")]
    public float speed = 3f;
    public float timerEnemy = 10f;
    public float waitTimerEnemy = 5f;
    public Vector2 ofssetVec;
    [Header("Знание")]
    public GameObject effect;
    void Start()
    {
        waitTimerEnemy = Random.Range(1f, 7f);
    }

    public void TakeDamageEnemy(float damage)
    {
        hpEnemy -= damage;
        if (hpEnemy <= 0)
        {
            Instantiate(effect, transform.position, Quaternion.identity);
            gameObject.GetComponentInParent<EnemySpawner>().enemyList.Remove(gameObject);
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        RandmoMoveEnemy();
    }

    private void RandmoMoveEnemy()
    {
        timerEnemy += Time.deltaTime;
        if (timerEnemy >= waitTimerEnemy)
        {
            var offsetX = Random.Range(-5f, 5f);
            var offsetY = Random.Range(-5f, 5f);
            ofssetVec = new Vector2(transform.position.x + offsetX, transform.position.y + offsetY);

            timerEnemy = 0f;
        } 
            transform.position = Vector2.MoveTowards(transform.position,ofssetVec,speed*Time.deltaTime);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemySpawner")
        {
            gameObject.GetComponentInParent<EnemySpawner>().enemyList.Remove(gameObject);
            Destroy(gameObject);
        }
    }


}
