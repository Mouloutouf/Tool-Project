using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : Movement
{
    public Transform target;
    public bool fixedTarget;
    private Vector2 direction;

    public GameEvent hitEvent;

    public float lifetime;

    private void Start()
    {
        if (fixedTarget) direction = target.position;
    }

    private void FixedUpdate()
    {
        Move(Vector2.up);

        StartCoroutine(Lifetime());
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(lifetime);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        hitEvent.Raise();

        Destroy(gameObject);
    }
}
