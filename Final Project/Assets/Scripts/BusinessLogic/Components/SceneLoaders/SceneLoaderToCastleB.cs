using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderToCastleB : MonoBehaviour
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
                nextScene = Constants.CastleBScene;
                SavePositionOnExitMainScene();
                break;
            case Constants.CastleBScene:
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
        location.x -= Constants.AdditionalOnXAxesLeavingMedievalEnviromentSceneToCastleBScene;
        location.y -= Constants.AdditionalOnYAxesLeavingMedievalEnviromentSceneToCastleBScene;
        location.z += Constants.AdditionalOnZAxesLeavingMedievalEnviromentSceneToCastleBScene;
        GlobalPlayerManagement.instance.playerLocationOnExitCastleB = location;
        GlobalPlayerManagement.instance.lastScene = Constants.CastleBScene;
    }
}
