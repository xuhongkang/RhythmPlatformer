using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="RealTimeData",menuName="ScriptableObjects/RealTimeData")]
public class RealTimeData : ScriptableObject
{
    public float distance;
    public Vector2 velocity;
    public float groundHeight;
    public bool isGrounded;
    public bool isHoldingJump;
    public float holdJumpTimer;
    public float hAcceleration;

	public void Init() {
		distance = 0.0f;
    	velocity = new Vector2(0.0f,0.0f);
    	groundHeight = 0.0f;
    	isGrounded =  false;
    	isHoldingJump = false;
    	holdJumpTimer = 0.0f;
    	hAcceleration = 0.0f;
	}
}
