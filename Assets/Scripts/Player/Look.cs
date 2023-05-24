using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Taken from: https://www.youtube.com/watch?v=-bkmPm_Besk
public class Look : MonoBehaviour
{
    public SpriteRenderer spriteRender;
    private bool facingRight;

    // Update is called once per frame
    void Update()
    {
        Looking();
    }

    public void Looking()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ);

        if (rotZ < 89 && rotZ > -89)
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
}
