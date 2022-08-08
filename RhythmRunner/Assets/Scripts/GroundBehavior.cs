using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBehavior : MonoBehaviour
{
    public float groundHeight;
    BoxCollider2D boxCollider;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        groundHeight = transform.position.y + (boxCollider.size.y / 2);
    }
}
