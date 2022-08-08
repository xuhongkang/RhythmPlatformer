using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField] public float depth = 1;
    [SerializeField] public int lWrapMargin = -25;
    [SerializeField] public int rWrapMargin = 80;
    [SerializeField] public RealTimeData realTime;

    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        float realVelocty = realTime.velocity.x / depth;
        Vector2 pos = transform.position;
        
        pos.x -= realVelocty * Time.fixedDeltaTime;

        if (pos.x <= lWrapMargin)
        {
            pos.x = rWrapMargin;
        }
        
        transform.position = pos;
    }
}
