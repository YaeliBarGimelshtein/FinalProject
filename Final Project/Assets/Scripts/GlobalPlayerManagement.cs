using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalPlayerManagement : MonoBehaviour
{
    public int playerNumberOfSowrds = 0;
    public Vector3 playerLocationOnExitCastleA;
    public Vector3 playerLocationOnExitCastleB;
    public GameObject player;
    public int lastScene;

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
            SetPlayerPosition();
        }
    }

    void SetPlayerPosition()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if(instance.lastScene == 1)
            {
                player.transform.position = instance.playerLocationOnExitCastleA;
            }
            else if (instance.lastScene == 2)
            {
                player.transform.position = instance.playerLocationOnExitCastleB;
            }
        }
    }
}
