using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPooler : MonoBehaviour
{

    [SerializeField] PooledObject[] prefabs;
    [SerializeField] Transform spawnPoint;
    [SerializeField] float delay;
    private float delayTime;
    public float PlayTime { get; private set; }

    private Stack<PooledObject> objectPool;  // ������ ����
    private int poolSize = 50;  // �ʱ� ũ��

    [SerializeField] Transform[] point;

    private List<Dictionary<string, object>> csv;

    private void Awake()
    {
        csv = CSVReader.Read("Data/CSV/CookieRun_CSV");
        delayTime = 0f;
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

        delayTime += Time.deltaTime;
        PlayTime += Time.deltaTime;
        if (delayTime > delay)
        {
            Debug.Log("�ð�üũ");
            delayTime = 0f;
            Generate();
        }

        //    if (delay > 0)
        //    {
        //        delay -= Time.deltaTime;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < prefabs.Length; i++)
        //        {
        //            PooledObject Coin = Manager.Pool.GetPool(prefabs[i], spawnPoint.position, spawnPoint.rotation);
        //        }
        //        delay = delayTime;
        //    }
    }

    void Generate()
    {
        if (csv.Count <= (int)PlayTime)
            return;        

        csv[(int)PlayTime].TryGetValue("CoinType", out object obj);
        // obj �� ������
        if (obj == "")
            return;

        // CSV���� �����͸� �ҷ��ͼ� ������ �� ���
        // PlayTime�� �̿��ؼ� ���ӽð� üũ

            PooledObject Coin = Manager.Pool.GetPool(
            prefabs[(int)csv[(int)PlayTime]["CoinType"]],
            point[(int)csv[(int)PlayTime]["CoinYPos"]].position,
            point[(int)csv[(int)PlayTime]["CoinYPos"]].rotation);
    }

}