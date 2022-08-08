using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBehavior : MonoBehaviour
{
    public float groundHeight;
    public BoxCollider2D groundCollider;

    private void Awake()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHeight = transform.position.y + (groundCollider.size.y / 2);
    }
}
