using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public bool revealed;

    void Start()
    {
        gameObject.SetActive(false);
        revealed = false;
    }

    void Update()
    {

    }

    public void ShowSword(bool state)
    {
        gameObject.SetActive(state);
        revealed = state;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (revealed)
        {
            PlayerInventrySwords playerInventory = other.GetComponent<PlayerInventrySwords>();
            if (playerInventory != null)
            {
                playerInventory.SwordsCollected();
                gameObject.SetActive(false);
            }
        }

    }
   
}
