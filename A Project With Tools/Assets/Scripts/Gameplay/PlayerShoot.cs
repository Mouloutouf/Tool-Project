using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;

    public Transform spawn;
    public Transform container;

    public GameObject InstantiateShot()
    {
        GameObject shot = Instantiate(bulletPrefab, spawn.position, spawn.rotation, container);

        return shot;
    }
}

public class PlayerShoot : Shoot
{
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            InstantiateShot();
        }
    }
}
