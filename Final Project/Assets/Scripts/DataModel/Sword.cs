using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Sword : Weapon
{
    public bool revealed;
    public bool taken;
    public GameObject playersLook;
    public TextMeshProUGUI swordInstrucationsText;

    void Start()
    {
        gameObject.SetActive(false);
        revealed = false;
        taken = false;
    }

    void Update()
    {
        if(gameObject.activeSelf)
        {
            HandleLookAtSword();
        }
    }

    public void ShowSword(bool state)
    {
        if(!taken)
        {
            gameObject.SetActive(state);
            revealed = state;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (revealed)
        {
            PlayerInventrySwords playerInventory = other.GetComponent<PlayerInventrySwords>();
            if (playerInventory != null)
            {
                playerInventory.SwordsCollected();
                taken = true;
                gameObject.SetActive(false);
                swordInstrucationsText.text = "";
            }
        }
    }
   
    private void HandleLookAtSword()
    {
        if (Physics.Raycast(playersLook.transform.position, playersLook.transform.forward, out RaycastHit hit))
        {
            if (hit.collider.gameObject == gameObject) // looking at the sword
            {
                swordInstrucationsText.text = "Approach to collect the sword";
            }
            else
            {
                swordInstrucationsText.text = "";
            }
        }
    }
}
