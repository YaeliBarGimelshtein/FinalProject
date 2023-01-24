using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI swordText;
    public Bar swordsBar;

    void Start()
    {
        swordText = GetComponent<TextMeshProUGUI>();
        UpdateSwordText();
    }

    public void UpdateSwordText()
    {
        swordText.text = GlobalPlayerManagement.instance.playerNumberOfSowrds.ToString();
        swordsBar.SetCurrentBar(GlobalPlayerManagement.instance.playerNumberOfSowrds);
    }
}
