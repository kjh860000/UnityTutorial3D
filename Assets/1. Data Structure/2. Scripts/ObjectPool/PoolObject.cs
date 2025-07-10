using UnityEngine;
using System.Collections.Generic;

public class PoolObject : MonoBehaviour
{
    private ObjectPoolQueue pool;
    public float bulletSpeed = 50f;

    private void Awake()
    {
        pool = FindFirstObjectByType<ObjectPoolQueue>();
    }

    void OnEnable()
    {
        Invoke("ReturnPool", 3f);
    }
    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * bulletSpeed;
    }

    void ReturnPool()
    {
        pool.EnqueueObject(gameObject);
    }
}