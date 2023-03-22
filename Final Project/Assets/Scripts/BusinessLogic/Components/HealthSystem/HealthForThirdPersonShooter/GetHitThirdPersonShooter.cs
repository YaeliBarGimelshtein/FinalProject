using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHitThirdPersonShooter : MonoBehaviour
{
    public HealthForThirdPersonShooter health;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "EnemySword")
        {
            health.TakeDamage(Constants.HitAmount);
        }
    }
}