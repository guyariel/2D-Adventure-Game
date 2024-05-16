using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class PlayerController : MonoBehaviour
{
    public InputAction MoveAction;

    void Start()
    {
        MoveAction.Enable();
    }

    
    void Update()
    {
        Vector2 Move = MoveAction.ReadValue<Vector2>();

        Debug.Log(Move);

        Vector2 Position = (Vector2)transform.position + Move * 3.0f * Time.deltaTime;
        transform.position = Position;

    }
}
