using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetHit : MonoBehaviour
{
    public Health health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Sword" )
        {
            health.TakeDamage(10);
        }
    }
}
