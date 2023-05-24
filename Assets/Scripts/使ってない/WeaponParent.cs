using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    // Getter/setter so it can be reused
    public Vector2 PointerPosition { get; set; }

    // 
    private void Update()
    {
        transform.right = (PointerPosition - (Vector2)transform.position).normalized;
    }
}
