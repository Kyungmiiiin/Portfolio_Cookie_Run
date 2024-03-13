using System.Collections.Generic;
using UnityEngine;

public class JellyPooler : MonoBehaviour
{

    [SerializeField] PooledObject[] prefabs;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float delay;
    private float delayTime;
    private Stack<PooledObject> objectPool;  // ������ ����
    private int poolSize = 50;  // �ʱ� ũ��
    List<Jelly> prefabJellyData;
    private void Awake()
    {
        prefabJellyData = new List<Jelly>();
        foreach (var element in prefabs)
        {
            prefabJellyData.Add(element.GetComponent<Jelly>());
        }
    }

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
                PooledObject Jelly = Manager.Pool.GetPool(prefabs[i], spawnPoint.position, spawnPoint.rotation);
            }
            delay = delayTime;
        }

    }
    public void SetData(int type, Vector2 setPos)
    {
        int idx = -1;
        for (int i = 0; i < prefabJellyData.Count; i++)
        {
            if (prefabJellyData[i].data.jellyType == type)
            {
                PooledObject Jelly = Manager.Pool.GetPool(prefabs[i], spawnPoint.position, spawnPoint.rotation);
            }
        }
    }
}




