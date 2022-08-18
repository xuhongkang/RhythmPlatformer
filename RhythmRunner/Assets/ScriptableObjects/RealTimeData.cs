using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="RealTimeData",menuName="ScriptableObjects/RealTimeData")]
public class RealTimeData : ScriptableObject
{
	// Current Mircophone Volume
	public float volume;
	// Current Distance Travelled
    public float distance;
    // Current Player Velocity, both horizontal and vertical
    public Vector2 velocity;
    // Current Height of Ground Beneath the Player Based on Platform Placement and Player Movement (Dynamic)
    public float groundHeight;
    // Boolean that tracks if the game is currently paused
	public bool isPaused;
	// Boolean that tracks if the player is currently grounded
    public bool isGrounded;
    // Boolean that tracks if the player is currently holding jump
    public bool isHoldingJump;
    // Counter that keeps track of the duration of the jump key held
    public float holdJumpTimer;
    // Current Horizontal Acceleration
    public float hAcceleration;
    // Max Time Player Can Hold to Jump Based on Current Velocity and Other Level Settings (Dynamic)
	public float maxHoldJumpTime;

	// Resets Scriptable Object Data to Default Starting Values
	public void Init() {
		distance = 0.0f;
    	velocity = new Vector2(0.0f,0.0f);
    	groundHeight = 0.0f;
		isPaused = true;
    	isGrounded =  false;
    	isHoldingJump = false;
    	holdJumpTimer = 0.0f;
    	hAcceleration = 0.0f;
		maxHoldJumpTime = 0.0f;
	}
}
