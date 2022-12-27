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
        GlobalPlayerManagement.instance.playerNumberOfSowrds = GlobalPlayerManagement.instance.playerNumberOfSowrds + 1;
    }

}
