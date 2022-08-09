using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
    public AudioData audioData;
    public PlayerData playerStats;
    public LevelData levelConfig;
    public RealTimeData realTime;
    public GameObject groundPrefab;
    public float groundHeight = 10;

    private float currentX = 0.0f;

    void Awake()
    {
        BuildLevel();
    }

    public void BuildLevel()
    {
        List<float> durations = audioData.durations;
        if (durations.Count > 0)
        {
            for (int i = 0; i < durations.Count - 1; i += 2)
            {
                float wordDuration = durations[i];
                float pauseDuration = durations[i + 1];
                PlaceGround(wordDuration, pauseDuration);
            }
            float lastWordDuration = durations[durations.Count - 1];
            PlaceGround(lastWordDuration, 0.0f);
        }
    }

    public void PlaceGround(float wordDuration, float pauseDuration)
    {
        GameObject currentGround = groundPrefab;
        currentGround.transform.localScale = new Vector2(wordDuration * playerStats.runVelocity, groundHeight);
        Instantiate(currentGround, new Vector2(currentX + 0.5f * wordDuration * playerStats.runVelocity, groundHeight), Quaternion.identity);
        currentX += wordDuration * playerStats.runVelocity + pauseDuration * playerStats.runVelocity * levelConfig.gapMutiplier;
    }
}
