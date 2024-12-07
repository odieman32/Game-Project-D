using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    RagdollManager ragdollManager;

    public void Start()
    {
        ragdollManager = GetComponent<RagdollManager>();
    }

    public void TakeDamage(float  damage)
    {
        if (health > 0)
        {
            health -= damage;
            if (health <= 0) EnemyDeath();
            Debug.Log("Hit");
        }
       
    }

    void EnemyDeath()
    {
        ragdollManager.TriggerRagdoll();
        Debug.Log("Death");
    }
}

//https://www.youtube.com/@gaddgames by Gadd Games
