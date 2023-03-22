using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour
{
    public Health health;
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Sword" )
        {
            health.TakeDamage(Constants.HitAmount);
        }
    }
}
