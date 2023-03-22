using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventoryHealth : MonoBehaviour
{
    public UnityEvent<PlayerInventoryHealth> OnHealthDamage;

    public void OnTakenDamage()
    {
        OnHealthDamage.Invoke(this);
    }
}
