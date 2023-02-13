using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Character
{
    public bool IsAlive { get; private set; }
    public int Health { get; protected set; }
    public List<Weapon> Weapons { get; set; }
    public GameObject Enemy { get; set; }
    public Bar healthBar;
    public bool isAttacking { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        Health = 5;
        healthBar.SetMaxBar(Health);
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MakeAnAttack()
    {
        isAttacking = true;
        if (Enemy != null)
        {
            Soldier enemySoldier = Enemy.GetComponent<Soldier>();
            enemySoldier.TakeAHit();
            Debug.Log("made a hit!");
        }
        isAttacking = false;
    }

    public void TakeAHit()
    {
        Health -= 1;
        healthBar.SetCurrentBar(Health);
        Debug.Log("took a hit! have " + Health + " lives");
        if(Health == 0)
        {
            Destroy(gameObject);
        }
    }

}
