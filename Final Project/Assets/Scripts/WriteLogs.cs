using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class WriteLogs : MonoBehaviour
{
    string fileName = "";

    void OnEnable()
    {
        Application.logMessageReceived += Log;
    }

    void OnDisable()
    {
        Application.logMessageReceived -= Log;
    }

    // Start is called before the first frame update
    void Start()
    {
        fileName = Application.dataPath + "/Log.text";
    }

    // Update is called once per frame
    public void Log(string logString, string stackTrace, LogType type)
    {
        TextWriter writer = new StreamWriter(fileName, true);
        writer.WriteLine("[" + System.DateTime.Now + "]" + logString);
        writer.Close();
    }
}
