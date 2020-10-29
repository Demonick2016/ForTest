using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    private GameObject enemy;

    private int enemyCount = 1;

    void Update()
    {
        if (enemy == null)
        {
            for (int i = 0; i < enemyCount; i++)
            {
                InstantiateEnemy();
            }
            enemyCount++; 
        }
    }

    void InstantiateEnemy()
    {
        int posX = Random.Range(2, 14);
        int posZ = Random.Range(1, 14);

        enemy = Instantiate(enemyPrefab, new Vector3(posX, 1, posZ), Quaternion.identity);

        float angle = Random.Range(0, 360);
        enemy.transform.Rotate(0, angle, 0);
    }
}
