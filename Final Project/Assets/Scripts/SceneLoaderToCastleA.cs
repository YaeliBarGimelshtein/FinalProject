using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderToCastleA : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;
    public GameObject player;
    int nextScene = -1;

    private void OnTriggerEnter(Collider other)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        switch (currentScene)
        {
            case 0:
                nextScene = 1;
                SavePositionOnExitMainScene();
                break;
            case 1:
                nextScene = 0;
                break;
        }
        StartCoroutine(LoadLevel(nextScene));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play Animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(transitionTime);

        //Load Scene
        SceneManager.LoadScene(levelIndex);
    }

    private void SavePositionOnExitMainScene()
    {
        var location = gameObject.transform.position;
        location.x += 12;
        location.y -= 3;
        GlobalPlayerManagement.instance.playerLocationOnExitCastleA = location;
        GlobalPlayerManagement.instance.lastScene = 1;
    }
}
