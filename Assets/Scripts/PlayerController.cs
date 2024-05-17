using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;

    Rigidbody2D rigidbody2d;

    Vector2 move;

    public int maxHealth = 5;

    int currentHealth = 1;

    public float characterSpeed = 3.0f;

    void Start()
    {
        MoveAction.Enable();
        rigidbody2d = GetComponent<Rigidbody2D>();

        //currentHealth = maxHealth;
    }
    
    void Update()
    {
        move = MoveAction.ReadValue<Vector2>();

        //Debug.Log(move);
    }

    public void ChangeHealth (int amount)
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);

        Debug.Log(currentHealth + "/" + maxHealth);
    }

    void FixedUpdate()
    {
        Vector2 position = (Vector2)rigidbody2d.position + move * characterSpeed * Time.deltaTime;

        rigidbody2d.MovePosition(position);
    }
}
