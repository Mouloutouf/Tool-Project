using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : Shoot
{
    public Vector2 breakTime;
    private float breakWaitTime;

    public float shootTime;
    private float shootWaitTime;

    public int salveAmount;
    private int currentAmount;

    private Transform target;

    private void Start()
    {
        breakWaitTime = Random.Range(breakTime.x, breakTime.y);
        shootWaitTime = shootTime;
        currentAmount = salveAmount;
    }

    void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (breakWaitTime <= 0.0f)
        {
            if (currentAmount > 0)
            {
                if (shootWaitTime <= 0.0f)
                {
                    target = GetPlayer();
                    GameObject shot = InstantiateShot();
                    shot.GetComponent<BulletMovement>().target = target;

                    shootWaitTime = shootTime;
                    currentAmount--;
                }
                else
                {
                    shootWaitTime -= Time.deltaTime;
                }
            }
            else
            {
                breakWaitTime = Random.Range(breakTime.x, breakTime.y);
                currentAmount = salveAmount;
            }
        }
        else
        {
            breakWaitTime -= Time.deltaTime;
        }
    }

    Transform GetPlayer()
    {
        return GameObject.Find("Player").transform;
    }
}
