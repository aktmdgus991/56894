using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class PlatGunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject platformPrefab;

    public Transform bulletTransform;

    public bool bulletFired = false;
    [HideInInspector]
    public GameObject currentBullet;

    // Bardent's videos on multi weapon combat system
    // Update is called once per frame
    void Update()
    {
        checkBullet();
        if (Input.GetMouseButtonDown(0) && bulletFired == false) 
            fireBullet();
        else if (Input.GetMouseButtonDown(0) && bulletFired == true)
            createPlatform();
    }

    private void fireBullet()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        currentBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        currentBullet.GetComponent<PlatBullet>().SetTarget(mousePosition);
        bulletFired = true;
    }

    public void createPlatform()
    {
        Vector3 bulletPos = currentBullet.transform.position;
        Destroy(currentBullet);

        Instantiate(platformPrefab, bulletPos, Quaternion.identity);

        bulletFired = false;
    }

    private void checkBullet()
    {
        if(currentBullet.IsDestroyed() == true)
            bulletFired = false;
    }
}
