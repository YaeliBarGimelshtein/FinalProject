using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI swordText;
    public TextMeshProUGUI healthText;
    public Bar swordsBar;
    public Bar armyHealthBar;

    void Start()
    {
        swordText = GetComponent<TextMeshProUGUI>();
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
        healthText.text = "20";
        swordsBar.SetCurrentBar(20);
    }
}
