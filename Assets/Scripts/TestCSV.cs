using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TestCSV : MonoBehaviour
{
    JellyPooler pooler;
    private void Start()
    {
        pooler = FindObjectOfType<JellyPooler>();

        List<Dictionary<string, object>> readData = CSVReader.Read($"Data/CSV/CookieRun_CSV");


    }
}
