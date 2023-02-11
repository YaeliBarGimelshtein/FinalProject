using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Character
{
    public bool IsAlive { get; private set; }
    public float Helath { get; private set; }
    public List<Weapon> Weapons { get; set; }
    public GameObject Enemy { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeAttack()
    {
        if(Enemy != null)
        {
            Destroy(Enemy);
        }
    }

}
