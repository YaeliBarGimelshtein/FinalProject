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
    public AudioSource swordDrawSound;

    void Start()
    {
        gameObject.SetActive(true);
        revealed = true;
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
        Debug.Log("enterder OnTriggerEnter of sword with name " +other.gameObject.name + "and revealed " + revealed);
        if (revealed)
        {
            PlayerInventrySwords playerInventory = other.transform.root.GetComponent<PlayerInventrySwords>();
            if (playerInventory != null)
            {
                swordDrawSound.Play();
                playerInventory.SwordsCollected();
                taken = true;
                gameObject.SetActive(false);
                swordInstrucationsText.text = "";
            }
            gameObject.transform.root.gameObject.SetActive(false);
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
