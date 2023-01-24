using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGeneralEnvironment : MonoBehaviour
{
    public AudioSource sound;
    public Bar swordsBar;
    
    void Start()
    {
        sound.volume = GlobalPlayerManagement.instance.soundVolume;
        swordsBar.SetMinBar(0);
    }
}
