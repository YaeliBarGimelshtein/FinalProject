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
    private bool IsDefending;
    private bool IsFallingBack;

    public SoldierInformation(int health)
    {
        IsAlive = true;
        Health = health;
        IsAttacking = false;
        Weapons = new List<Weapon>();
        Enemy = null;
        IsDefending = false;
        IsFallingBack = false;
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
        return Enemy;
    }

    public bool GetIsAttacking()
    {
        return IsAttacking;
    }

    public bool GetIsDefending()
    {
        return IsDefending;
    }

    public bool GetIsFallingBack()
    {
        return IsFallingBack;
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

    public void SetIsDefending(bool isDefending)
    {
        IsDefending = isDefending;
    }

    public void SetIsFallingBack(bool isFallingBack)
    {
        IsFallingBack = isFallingBack;
    }
}
