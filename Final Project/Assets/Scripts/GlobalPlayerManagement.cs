using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GlobalPlayerManagement : MonoBehaviour
{
    public int playerNumberOfSowrds = 0;
    public Vector3 playerLocation;
    public GameObject player;
    public GameObject portalCatleA;

    //singeltion
    public static GlobalPlayerManagement instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            playerLocation = player.transform.position;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                var location = portalCatleA.transform.position;
                location.x += 7;
                player.transform.position = location;
            }

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
