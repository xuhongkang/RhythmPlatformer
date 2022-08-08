using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="RealTimeData",menuName="ScriptableObjects/RealTimeData")]
public class RealTimeData : ScriptableObject
{
    public float distance = 0.0f;
    public Vector2 velocity;
    public float groundHeight;
    public bool isGrounded =  false;
    public bool isHoldingJump = false;
    public float holdJumpTimer = 0.0f;
    public float hAcceleration;
}
