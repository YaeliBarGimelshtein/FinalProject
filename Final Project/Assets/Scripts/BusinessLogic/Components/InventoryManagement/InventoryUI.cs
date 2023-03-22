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
    public SoldierInformation soldierInformation;

    void Start()
    {
        UpdateSwordNumberOnStart();
        UpdateHealthTextOnStart();
    }

    public void UpdateSwordText()
    {
        swordText.text = soldierInformation.WeaponsNumber.ToString();
        swordsBar.SetCurrentBar(soldierInformation.WeaponsNumber);
    }

    public void UpdateHealthText()
    {
        armyHealthText.text = soldierInformation.Health.ToString();
        swordsBar.SetCurrentBar(soldierInformation.Health);
    }

    private void UpdateSwordNumberOnStart()
    {
        swordText.text = 0.ToString();
        swordsBar.SetCurrentBar(0);
    }

    public void UpdateHealthTextOnStart()
    {
        armyHealthText.text = Constants.MaxHealth.ToString();
        swordsBar.SetCurrentBar(Constants.MaxHealth);
    }
}
