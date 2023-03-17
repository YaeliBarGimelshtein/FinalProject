using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetGeneralEnvironment : MonoBehaviour
{
    public AudioSource sound;
    public Bar swordsBar;
    public Bar armyHealthBar;
    public TextMeshProUGUI swordText;
    public TextMeshProUGUI healthText;


    void Start()
    {
        sound.volume = GlobalPlayerManagement.instance.soundVolume;
        swordsBar.SetMinBar(0);
        armyHealthBar.SetMaxBar(Constants.MaxHealth);
        Cursor.visible = false;
        swordText.text = 0.ToString();
        healthText.text = Constants.MaxHealth.ToString();
    }
}
