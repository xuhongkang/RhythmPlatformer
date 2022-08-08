using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveData", menuName = "SaveData", order = 0)]
public class SaveData : ScriptableObject
{
    public List<LevelData> levels;
}
