using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Soldier : Character
{
    public bool IsAlive { get; private set; }
    public int Helath { get; private set; }
    public List<Weapon> Weapons { get; set; }


    
}
