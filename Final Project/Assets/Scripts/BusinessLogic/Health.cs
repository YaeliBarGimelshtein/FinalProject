using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth;
    [HideInInspector]
    public int currentHealth;
    private Ragdoll ragdoll;
    private Bar healthBar;

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
        currentHealth = maxHealth;
        healthBar.SetMaxBar(currentHealth);
        healthBar.SetCurrentBar(currentHealth);


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
        currentHealth -= amount;
        healthBar.SetCurrentBar(currentHealth);
        if(currentHealth <= 0)
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
