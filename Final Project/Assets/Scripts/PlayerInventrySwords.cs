using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventrySwords : MonoBehaviour
{
    public int NumberOfSwords { get; private set; }
    public UnityEvent<PlayerInventrySwords> OnSwordCollected;


    public void SwordsCollected()
    {
        NumberOfSwords++;
        OnSwordCollected.Invoke(this);
    }

}
