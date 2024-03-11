using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TestCSV : MonoBehaviour
{
    //CookieRun_CSVt
   // Dictionary<>
    // Start is called before the first frame update
    void Start()
    {
        //List<Dictionary<string, JellyData>> tester = new List<Dictionary<string, JellyData>>();
        //tester =
        List<Dictionary<string,object>> readData = CSVReader.Read($"Data/CSV/CookieRun_CSV");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
