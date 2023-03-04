using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierInformation 
{
    private bool IsAlive;
    private int Health;
    private List<Weapon> Weapons;
    private GameObject Enemy;
    private bool IsAttacking;

    public SoldierInformation(int health)
    {
        IsAlive = true;
        Health = health;
        IsAttacking = false;
        Weapons = new List<Weapon>();
        Enemy = null;
    }

    public bool GetIsAlive()
    {
        return IsAlive;
    }

    public int GetHealth()
    {
        return Health;
    }

    public GameObject GetEnemy()
    {
        if(Enemy == null)
        {
            Debug.Log("returning enemy = null");
        }
        return Enemy;
    }

    public bool GetIsAttacking()
    {
        return IsAttacking;
    }

    public void SetIsAlive(bool isAlive)
    {
        IsAlive = isAlive;
    }

    public void SetHealth(int health)
    {
        Health = health;
        if(Health == 0)
        {
            IsAlive = false;
        }
    }

    public void SetEnemy(GameObject enemy)
    {
        Enemy = enemy;
    }

    public void SetIsAttacking(bool isAttacking)
    {
        IsAttacking = isAttacking;
    }
}
