using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public int poolSize = 10;

    //public GameObject[] enemyObjectPool;

    public Transform[] spawnPoints;
    public List<GameObject> enemyObjectPool;
    public GameObject enemyFactory;

    private float currentTime;
    private float minTime = 1f;
    private float maxTime = 3f;
    public float createTime = 1f;

    private void Start()
    {
        createTime = Random.Range(minTime, maxTime);

        //enemyObjectPool = new GameObject[poolSize];
        enemyObjectPool = new List<GameObject>();

        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyFactory);
            //enemyObjectPool[i] = enemy;

            enemyObjectPool.Add(enemy);
            enemy.SetActive(false);
        }
    }
    private void Update()
    {
        currentTime += Time.deltaTime;

        if (currentTime > createTime)
        {
            if (enemyObjectPool.Count > 0)
            {
                currentTime = 0;
                createTime = Random.Range(minTime, maxTime);

                GameObject enemy = enemyObjectPool[0];    // 가져올 오브젝트 선택

                int ranIndex = Random.Range(0, spawnPoints.Length);
                Transform spawnPoint = spawnPoints[ranIndex];

                enemy.transform.position = spawnPoint.transform.position;
                enemy.SetActive(true);     // 오브젝트 사용

                enemyObjectPool.Remove(enemy);    // pool에서 오브젝트 제거
            }
        }
    }
}
