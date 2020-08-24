using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
  
    public int countEnemy = 3;
    public GameObject prefabEnemy;
    public List<GameObject> enemyList;

    public Transform enemySpawner;

    private void Start()
    {
        for (int i = 1; i <= countEnemy; i++)
        {
            var offsetX = Random.Range(-25f, 25f);

            var offsetY = Random.Range(-15f, 15f);

            Vector2 ofssetVec = new Vector2(enemySpawner.position.x + offsetX, enemySpawner.position.y + offsetY);
            GameObject go = Instantiate(prefabEnemy, ofssetVec, Quaternion.identity, enemySpawner);
            enemyList.Add(go);
        }
    }

    private void Update()
    {
        if (enemyList.Count <= countEnemy)
        {
            var offsetX = Random.Range(-3f, 3f);
            var offsetY = Random.Range(-3f, 3f);
            Vector2 ofssetVec = new Vector2(enemySpawner.position.x + offsetX, enemySpawner.position.y + offsetY);
            GameObject go = Instantiate(prefabEnemy, ofssetVec, Quaternion.identity, enemySpawner);
            enemyList.Add(go);
        }
    }
}
