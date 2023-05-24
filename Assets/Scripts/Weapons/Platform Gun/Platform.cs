using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer += 1.0F * Time.deltaTime;
        if (timer >= 3)
            GameObject.Destroy(gameObject);
    }
}
