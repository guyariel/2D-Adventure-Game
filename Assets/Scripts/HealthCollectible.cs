using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    public int healthIncrease;

    void OnTriggerEnter2D(Collider2D other)
    {

        PlayerController controller = other.GetComponent<PlayerController>();

        if (controller != null && controller.health < controller.maxHealth)
        {
            controller.ChangeHealth(healthIncrease);
            Destroy(gameObject);
        }
    }
}
