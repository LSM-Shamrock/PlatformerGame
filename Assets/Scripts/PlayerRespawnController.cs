using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawnController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private Vector3 savePoint;
    public List<Action> saveActions = new List<Action>();
    public List<Action> deadActions = new List<Action>();

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        SetSave();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
            PlayerDead();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Dead"))
        {
            PlayerDead();
        }

        if (collision.CompareTag("Respawn") && rigidBody.linearVelocityY == 0f)
        {
            if (savePoint != transform.position)
            {
                SetSave();
            }
        }
    }

    private void SetSave()
    {
        savePoint = transform.position;
        foreach (Action action in saveActions)
        {
            action.Invoke();
        }
    }

    private void PlayerDead()
    {
        rigidBody.linearVelocity = Vector2.zero;
        transform.position = savePoint;
        foreach (Action action in deadActions)
        {
            action.Invoke();
        }
    }
}
