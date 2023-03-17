using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Ragdoll ragdoll;
    private Bar healthBar;
    private SoldierInformation soldierInformation;

    private SkinnedMeshRenderer[] skinnedMeshRenderer;
    public float blinkIntensity;
    public float blinkDuration;
    private float blinkTimer;

    // Start is called before the first frame update
    void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
        skinnedMeshRenderer = GetComponentsInChildren<SkinnedMeshRenderer>();
        healthBar = GetComponentInChildren<Bar>();
        soldierInformation = GetComponent<SoldierInformation>();
        healthBar.SetMaxBar(Constants.MaxHealth);
        healthBar.SetCurrentBar(Constants.MaxHealth);


        var rigitBodies = GetComponentsInChildren<Rigidbody>();
        foreach(var rigitBody in rigitBodies)
        {
            GetHit getHit = rigitBody.gameObject.AddComponent<GetHit>();
            getHit.health = this;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        blinkTimer -= Time.deltaTime;
        float lerp = Mathf.Clamp01(blinkTimer / blinkDuration);
        float intensity = (lerp * blinkIntensity) + 1.0f;
        foreach(var renderer in skinnedMeshRenderer)
        {
            renderer.material.color = Color.white * intensity;
        }
    }

    public void TakeDamage(int amount)
    {
        soldierInformation.Health -= amount;
        healthBar.SetCurrentBar(soldierInformation.Health);
        if(!soldierInformation.IsAlive)
        {
            Die();
        }

        blinkTimer = blinkDuration;
    }

    private void Die()
    {
        ragdoll.ActivateRagdoll();
    }
}
