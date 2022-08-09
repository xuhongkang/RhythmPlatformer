using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="AudioData",menuName="ScriptableObjects/AudioData")]
public class AudioData : ScriptableObject
{
    // Durations must start with the first word length, alternate
    // between word duration and pause duration, finally ending on
    // the last word duration.
    public List<float> durations;
}
