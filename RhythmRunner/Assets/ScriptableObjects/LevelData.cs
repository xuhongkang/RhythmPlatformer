using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="newLevelData",menuName="ScriptableObjects/LevelData")]
public class LevelData : ScriptableObject
{
    public float gravity;
    public float jumpGroundThreshold;
    public float sidePadding = 0.7f;
}
