using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Taken from this video: https://www.youtube.com/watch?v=-bkmPm_Besk
public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;

    public GameObject bullet;
    public Transform bulletTransform;
    public bool canFire;
    private float timer;
    public float timeBetweenFiring;
    public SpriteRenderer spriteRender;
    private bool facingRight;

    // Start is called before the first frame update
    void Start()
    {
        //mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Look();
        Fire();
        
    }

    public void Look()
    {
        //mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        //Vector3 rotation = mousePos - transform.position;

        //float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if(rotZ < 89 && rotZ > -89)
        {
            Debug.Log("Facing right");
            spriteRender.flipY = false;
        }
        else
        {
            Debug.Log("Facing left");
            spriteRender.flipY = true;
        }
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
