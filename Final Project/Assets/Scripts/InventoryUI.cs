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
    }

    public void UpdateSwordText(PlayerInventrySwords playerInventory)
    {
        swordText.text = "Sword count: " + playerInventory.NumberOfSwords.ToString();
    }
}
