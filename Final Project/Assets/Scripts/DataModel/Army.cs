using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army 
{
    public Commander _Commander { get; set; }
    public List<Soldier> _OffenceSoldiers { get; set; }
    public List<Soldier> _DefenceSoldiers { get; set; }


    public Army(Commander Commander,
        List<Soldier> OffenceSoldiers,
        List<Soldier> DefenceSoldiers)
    {
        _Commander = Commander;
        _OffenceSoldiers = OffenceSoldiers;
        _DefenceSoldiers = DefenceSoldiers;
    }

}
