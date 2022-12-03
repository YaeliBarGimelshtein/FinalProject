using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public bool revealed;
    public bool taken;

    void Start()
    {
        gameObject.SetActive(false);
        revealed = false;
        taken = false;
    }

    void Update()
    {

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
            }
        }

    }
   
}
