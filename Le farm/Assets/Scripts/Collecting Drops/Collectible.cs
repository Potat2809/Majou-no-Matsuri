using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Collectible : MonoBehaviour, ICollectible
{
    public AudioSource collected;

    public static event Action UponCollected;
    Rigidbody2D rb;

    bool hasTarget;
    Vector3 TargetPosition;
    public float movSpeed = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Collect()
    {
        Debug.Log("Coin Collected");
        Destroy(gameObject);
        collected.Play();
        UponCollected?.Invoke();
    }

    private void FixedUpdate()
    {
        if(hasTarget)
        {
            Vector2 targetDirection = (TargetPosition - transform.position).normalized;
            rb.velocity = new Vector2(targetDirection.x, targetDirection.y) * movSpeed;
        }
    }

    public void SetTarget(Vector3 position)
    {
        TargetPosition = position;
        hasTarget = true;
    }
}
