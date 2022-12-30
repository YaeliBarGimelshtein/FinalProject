using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalPlayerManagement : MonoBehaviour
{
    public Vector3 playerLocationOnExitCastleA;
    public Vector3 playerLocationOnExitCastleB;
    public int playerNumberOfSowrds = 0;
    public int lastScene = 0;

    //singeltion
    public static GlobalPlayerManagement instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
