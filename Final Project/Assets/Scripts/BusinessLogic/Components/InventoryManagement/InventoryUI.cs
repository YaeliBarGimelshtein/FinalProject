using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public TextMeshProUGUI swordText;
    public TextMeshProUGUI armyHealthText;
    public Bar swordsBar;
    public Bar armyHealthBar;

    void Start()
    {
        UpdateSwordText();
        UpdateHealthText();
    }

    public void UpdateSwordText()
    {
        swordText.text = GlobalPlayerManagement.instance.playerNumberOfSowrds.ToString();
        swordsBar.SetCurrentBar(GlobalPlayerManagement.instance.playerNumberOfSowrds);
    }

    public void UpdateHealthText()
    {
        armyHealthText.text = "20";
        swordsBar.SetCurrentBar(20);
    }
}
