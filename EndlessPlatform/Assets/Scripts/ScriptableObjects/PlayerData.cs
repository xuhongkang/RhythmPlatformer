using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "PlayerData", order = 0)]
public class PlayerData : ScriptableObject {
    // Player Horizontal Running Speed (Static/1 frame Acceleration to Top Speed)
    public float hRunSpeed;
    // Player Vertical Jump Speed
    public float vJumpSpeed;
    // Player Vertical Drop Speed
    public float vDropSpeed;
    // Maximum Height for Player Jump
    public float maxJumpHeight;
}
