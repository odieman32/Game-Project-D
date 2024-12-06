using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

public class WeaponBloom : MonoBehaviour
{
    [SerializeField] float defaultBloomAngle = 3;
    [SerializeField] float walkBloomAngle = 1.5f;
    [SerializeField] float crouchBloomAngle = 0.5f;
    [SerializeField] float sprintBloomAngle = 2f;
    [SerializeField] float adsBloomAngle = 0.5f;

    MovementStateManager movement;
    AimStateManager aiming;

    float currentBloom;
    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponentInParent<MovementStateManager>();
        aiming = GetComponentInParent<AimStateManager>();
    }

    public Vector3 BloomAngle(Transform barrelPos)
    {
        if (movement.currentState == movement.Idle) currentBloom = defaultBloomAngle;
        else if (movement.currentState == movement.Walk) currentBloom = defaultBloomAngle * walkBloomAngle;
        else if (movement.currentState == movement.Run) currentBloom = defaultBloomAngle * sprintBloomAngle;
        else if (movement.currentState == movement.Crouch)
        {
            if (movement.dir.magnitude == 0) currentBloom = defaultBloomAngle * crouchBloomAngle;
            else currentBloom = defaultBloomAngle * crouchBloomAngle * walkBloomAngle;
        }
        
        if (aiming.currentState == aiming.Aim) currentBloom *= adsBloomAngle;

        float randX = Random.Range(-currentBloom, currentBloom);
        float randY = Random.Range(-currentBloom, currentBloom);
        float randZ = Random.Range(-currentBloom, currentBloom);

        Vector3 randomRotation = new Vector3(randX, randY, randZ);
        return barrelPos.localEulerAngles + randomRotation;
    }

}


//https://www.youtube.com/@gaddgames by Gadd Games
