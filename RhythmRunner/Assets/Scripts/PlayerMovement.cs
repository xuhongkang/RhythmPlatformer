using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public PlayerData playerStats;
    [SerializeField] public LevelData levelConfig;
    [SerializeField] public RealTimeData realTime;
	[SerializeField] public LayerMask groundLayerMask;

    void Start()
    {
        realTime.Init();
		if (!levelConfig.isRunUpNeeded || !playerStats.isVelocityDynamic) {
			realTime.velocity.x = playerStats.runVelocity;
		}
		if (!playerStats.isHoldJumpScalable) {
			realTime.maxHoldJumpTime = playerStats.maxMaxHoldJumpTime;
		}
    }

    void Update()
    {
        Vector2 pos = transform.position;
        float groundDistance = Mathf.Abs(pos.y - realTime.groundHeight);
        
        if (realTime.isGrounded || groundDistance <= levelConfig.jumpGroundThreshold)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                realTime.isGrounded = false;
                realTime.velocity.y = playerStats.jumpVelocity;
                realTime.isHoldingJump = true;
                realTime.holdJumpTimer = 0.0f;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            realTime.isHoldingJump = false;
        }
    }

    private void FixedUpdate()
    {
		realTime.distance += realTime.velocity.x * Time.fixedDeltaTime;
        Vector2 pos = transform.position;
        
        if (!realTime.isGrounded)
        {
            pos.y += realTime.velocity.y * Time.fixedDeltaTime;
            if (realTime.isHoldingJump)
            {
                realTime.holdJumpTimer += Time.fixedDeltaTime;
                if (realTime.holdJumpTimer >= realTime.maxHoldJumpTime)
                {
                    realTime.isHoldingJump = false;
                }
            }
            else
            {
                realTime.velocity.y += levelConfig.gravity * Time.fixedDeltaTime;
            }

            Vector2 rayOrigin = new Vector2(pos.x + levelConfig.sidePadding, pos.y);
            Vector2 rayDirection = Vector2.up;
            float rayDistance = realTime.velocity.y * Time.fixedDeltaTime;
            RaycastHit2D hit2D = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance, groundLayerMask);
            if (hit2D.collider != null)
            {
                GroundBehavior ground = hit2D.collider.GetComponent<GroundBehavior>();
                if (ground != null)
                {
                    realTime.groundHeight = ground.groundHeight;
                    pos.y = realTime.groundHeight;
                    realTime.velocity.y = 0;
                    realTime.isGrounded = true;
                }
            }
            Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.red);
        }
        else
        {
           	if (playerStats.isVelocityDynamic)
           	{
				float velocityRatio = realTime.velocity.x / playerStats.runVelocity;
				if (playerStats.isVelocityCapped) {
            		realTime.hAcceleration = playerStats.maxAcceleration * (1 - velocityRatio);
					realTime.velocity.x += realTime.hAcceleration * Time.fixedDeltaTime;
					if (velocityRatio >= 1) {
						realTime.velocity.x = playerStats.runVelocity;
					}
				} else {
					realTime.hAcceleration = Mathf.Max(1f, playerStats.maxAcceleration * velocityRatio);
					realTime.velocity.x += realTime.hAcceleration * Time.fixedDeltaTime;
				}
				if (playerStats.isHoldJumpScalable) {
					realTime.maxHoldJumpTime = playerStats.maxMaxHoldJumpTime * velocityRatio;
				}
           	}
			Vector2 rayOrigin = new Vector2(pos.x - levelConfig.sidePadding, pos.y);
            Vector2 rayDirection = Vector2.up;
            float rayDistance = realTime.velocity.y * Time.fixedDeltaTime;
            RaycastHit2D hit2D = Physics2D.Raycast(rayOrigin, rayDirection, rayDistance, groundLayerMask);
            if (hit2D.collider == null)
            {
                realTime.isGrounded = false;
            }
            Debug.DrawRay(rayOrigin, rayDirection * rayDistance, Color.yellow);
        }

        transform.position = pos;
    }
}
