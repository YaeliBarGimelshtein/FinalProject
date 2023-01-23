using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    public AudioSource sound;
    
    public void OnValueChanged(float value)
    {
        sound.volume = value;
        GlobalPlayerManagement.instance.soundVolume = value;
    }
}
