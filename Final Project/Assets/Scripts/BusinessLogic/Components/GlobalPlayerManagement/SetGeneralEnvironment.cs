using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetGeneralEnvironment : MonoBehaviour
{
    public AudioSource sound;
    
    void Start()
    {
        sound.volume = GlobalPlayerManagement.instance.soundVolume;
    }
}
