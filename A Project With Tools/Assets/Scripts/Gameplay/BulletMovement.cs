using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : Movement
{
    public Transform target;
    public bool fixedTarget;
    public Vector2 direction;

    public float lifetime;

    private void Start()
    {
        if (fixedTarget) direction = target.position - transform.position;
    }

    private void FixedUpdate()
    {
        Vector2 dir = Vector2.ClampMagnitude(direction, 1f);
        Move(dir);

        StartCoroutine(Lifetime());
    }

    IEnumerator Lifetime()
    {
        yield return new WaitForSeconds(lifetime);

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet") return;

        collision.GetComponentInParent<PlayerCharacter>().Hit();

        Destroy(gameObject);
    }
}
