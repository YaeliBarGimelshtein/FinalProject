using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierData : Character
{
    public bool IsAlive { get; set; }
    public int Health { get; set; }
    public List<Weapon> Weapons { get; set; }
    public GameObject Enemy { get; set; }
    public bool IsAttacking { get; set; }
}
