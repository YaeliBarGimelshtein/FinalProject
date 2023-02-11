using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Character
{
    public bool IsAlive { get; private set; }
    public float Helath { get; private set; }
    public List<Weapon> Weapons { get; set; }
    public Transform Enemy { get; set; }


}
