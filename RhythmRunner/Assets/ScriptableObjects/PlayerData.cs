using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="newPlayerData",menuName="ScriptableObjects/PlayerData")]
public class PlayerData : ScriptableObject
{
    public float runVelocity;
    public float jumpVelocity;
    public float maxAcceleration;
    public float maxMaxHoldJumpTime;
	public bool isVelocityDynamic = true;
	public bool isVelocityCapped = true;
	public bool isHoldJumpScalable = true;
}
