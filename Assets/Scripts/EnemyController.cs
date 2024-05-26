using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed = 1.0f;
    public bool vertical;
    Rigidbody2D rigidBody2D;
    Vector2 position;

    public float changeTime = 3.0f;
    float Timer;
    int direction = 1;

    Animator animator;


    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();

        Timer = changeTime;

        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        position = rigidBody2D.position;

        if (vertical)
        {
            position.y = position.y + speed * direction * Time.deltaTime;
            animator.SetFloat("Move X",0);
            animator.SetFloat("Move Y", direction);
        }
        else
        {
            position.x = position.x + speed * direction * Time.deltaTime;
            animator.SetFloat("Move X", direction);
            animator.SetFloat("Move Y", 0);
        }
        rigidBody2D.MovePosition(position);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }

    void Update()
    {
        Timer -= Time.deltaTime;

        if (Timer < 0)
        {
            direction = -direction;
            Timer = changeTime;
        }
    }
}
