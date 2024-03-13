using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemTable : MonoBehaviour
{
    [SerializeField] JellyData[] jellys;

    Dictionary<int, JellyData> jellyTable;

    public static ItemTable Instance;

    private void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
            Instance = this;

        jellyTable = new Dictionary<int, JellyData>();
        foreach (var item in jellys)
        {
            jellyTable.Add(item.jellyType, item);
        }
    }
    public JellyData GetJelly(int type)
    {
        jellyTable.TryGetValue(type, out JellyData jelly);
        return jelly;
    }
}
