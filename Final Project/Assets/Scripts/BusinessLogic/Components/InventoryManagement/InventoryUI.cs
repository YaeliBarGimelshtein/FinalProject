using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI swordText;

    void Start()
    {
        swordText = GetComponent<TextMeshProUGUI>();
        UpdateSwordText();
    }

    public void UpdateSwordText()
    {
        swordText.text = GetDisplayText();
    }

    private string GetDisplayText()
    {
        return ": " + GlobalPlayerManagement.instance.playerNumberOfSowrds;
    }
}
