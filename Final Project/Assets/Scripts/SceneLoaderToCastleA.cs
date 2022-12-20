using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderToCastleA : MonoBehaviour
{
    public Animator transition;
    public GameObject player;
    
    private void OnTriggerEnter(Collider other)
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = -1;

        switch (currentScene)
        {
            case Constants.MedievalEnvironmentScene:
                nextScene = Constants.CastleAScene;
                SavePositionOnExitMainScene();
                break;
            case Constants.CastleAScene:
                nextScene = Constants.MedievalEnvironmentScene;
                break;
        }
        StartCoroutine(LoadLevel(nextScene));
    }

    IEnumerator LoadLevel(int levelIndex)
    {
        //Play Animation
        transition.SetTrigger("Start");

        //Wait
        yield return new WaitForSeconds(Constants.TransitionTimeBetweenScenes);

        //Load Scene
        SceneManager.LoadScene(levelIndex);
    }

    private void SavePositionOnExitMainScene()
    {
        var location = gameObject.transform.position;
        location.x += Constants.AdditionalOnXAxesLeavingMedievalEnviromentScene;
        location.y -= Constants.AdditionalOnYAxesLeavingMedievalEnviromentScene;
        GlobalPlayerManagement.instance.playerLocationOnExitCastleA = location;
        GlobalPlayerManagement.instance.lastScene = Constants.CastleAScene;
    }
}
