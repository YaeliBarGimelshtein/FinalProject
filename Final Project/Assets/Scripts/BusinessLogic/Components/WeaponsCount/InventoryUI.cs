using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI swordText;

    // Start is called before the first frame update
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
        return "Sword count: " + GlobalPlayerManagement.instance.playerNumberOfSowrds;
    }
}
