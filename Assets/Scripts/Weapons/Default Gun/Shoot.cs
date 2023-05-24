using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Taken from: https://www.youtube.com/watch?v=-bkmPm_Besk
public class Shoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    private void Fire()
    {
        var input = Input.GetButton("Fire1");
        if (!canFire)
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenFiring)
            {
                canFire = true;
                timer = 0;
            }
        }

        if (input && canFire)
        {
            canFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
    }
}
