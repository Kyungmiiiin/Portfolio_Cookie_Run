using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPooler : MonoBehaviour
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
        if (delayTime > delay )
        {
            Debug.Log("�ð�üũ");
            delayTime = 0f;
            Generate();
        }        
    }

    void Generate()
    {
        if (csv.Count <= (int)PlayTime)
            return;
        

        csv[(int)PlayTime].TryGetValue("ItemType", out object obj);
        // obj �� ������
        if (obj == "")
            return;
       
        // CSV���� �����͸� �ҷ��ͼ� ������ �� ���
        // Time.time�� �̿��ؼ� ���ӽð� üũ
        PooledObject Item = Manager.Pool.GetPool(
            prefabs[(int)csv[(int)PlayTime]["ItemType"]], 
            point[(int)csv[(int)PlayTime]["ItemYPos"]].position, 
            point[(int)csv[(int)PlayTime]["ItemYPos"]].rotation);
    }
}
