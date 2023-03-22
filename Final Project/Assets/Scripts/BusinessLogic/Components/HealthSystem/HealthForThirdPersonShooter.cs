using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthForThirdPersonShooter : MonoBehaviour
{
    private Ragdoll ragdoll;
    private SoldierInformation soldierInformation;
    private PlayerInventoryHealth inventoryHealth;

    private SkinnedMeshRenderer[] skinnedMeshRenderer;
    public float blinkIntensity;
    public float blinkDuration;
    private float blinkTimer;

    // Start is called before the first frame update
    void Start()
    {
        ragdoll = GetComponent<Ragdoll>();
        skinnedMeshRenderer = GetComponentsInChildren<SkinnedMeshRenderer>();
        inventoryHealth = GetComponent<PlayerInventoryHealth>();
        soldierInformation = GetComponent<SoldierInformation>();
        
        var rigitBodies = GetComponentsInChildren<Rigidbody>();
        foreach (var rigitBody in rigitBodies)
        {
            GetHitThirdPersonShooter getHit = rigitBody.gameObject.AddComponent<GetHitThirdPersonShooter>();
            getHit.health = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        blinkTimer -= Time.deltaTime;
        float lerp = Mathf.Clamp01(blinkTimer / blinkDuration);
        float intensity = (lerp * blinkIntensity) + 1.0f;
        foreach (var renderer in skinnedMeshRenderer)
        {
            renderer.material.color = Color.white * intensity;
        }
    }

    public void TakeDamage(int amount)
    {
        soldierInformation.Health -= amount;
        inventoryHealth.OnTakenDamage();
        if (soldierInformation.Health == 0)
        {
            Die();
        }

        blinkTimer = blinkDuration;
    }

    private void Die()
    {
        Debug.Log("Die");
        ragdoll.ActivateRagdoll();
    }
}
