using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierInformation : Character
{
    private int health;
    [HideInInspector]
    public bool IsAlive { get; private set; }
    [HideInInspector]
    public bool IsAttacking { get; set; }
    [HideInInspector]
    public bool IsDefending { get; set; }
    [HideInInspector]
    public bool IsFallingBack { get; set; }
    [HideInInspector]
    public GameObject Enemy { get; set; }
    [HideInInspector]
    public int WeaponsNumber { get; set; }
    [HideInInspector]
    public int Health
    {
        get { return health; }
        set
        {
            health = value;
            if(health == 0 )
            {
                IsAlive = false;
            }
            IsAlive = true;
        }
    }

    private void Start()
    {
        health = Constants.MaxHealth;
        IsAlive = true;
        IsAttacking = false;
        IsDefending = false;
        IsFallingBack = false;
        Enemy = null;
        WeaponsNumber = 0;
    }
}
