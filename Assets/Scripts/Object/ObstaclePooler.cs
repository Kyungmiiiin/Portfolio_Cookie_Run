using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePooler : MonoBehaviour
{
    [SerializeField] PooledObject[] prefabs;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float delay;
    private float delayTime;
    private Stack<PooledObject> objectPool;  // 보관함 생성
    private int poolSize = 50;  // 초기 크기


    private void Start()
    {
        delayTime = delay;
        for (int i = 0; i < prefabs.Length; i++)
        {
            Manager.Pool.CreatePool(prefabs[i], poolSize, poolSize);
        }
    }

    private void Update()
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            for (int i = 0; i < prefabs.Length; i++)
            {
                PooledObject Obstacle = Manager.Pool.GetPool(prefabs[i], transform.position, transform.rotation);
            }
            delay = delayTime;
        }
    }
}
