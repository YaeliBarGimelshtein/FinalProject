using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventrySwords : MonoBehaviour
{
    public UnityEvent<PlayerInventrySwords> OnSwordCollected;

    public void SwordsCollected()
    {
        UpdateSwordCollectedNumber();
        OnSwordCollected.Invoke(this);
    }

    private void UpdateSwordCollectedNumber()
    {
        SoldierInformation soldierInformation = gameObject.GetComponent<SoldierInformation>();
        int numSwordsBefore = soldierInformation.WeaponsNumber;
        soldierInformation.WeaponsNumber += 1;
        if(numSwordsBefore == 0)
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);
        }
    }

}
