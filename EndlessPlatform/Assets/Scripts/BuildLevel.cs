using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildLevel : MonoBehaviour
{ 
    [SerializeField]
    public int sampleWindow = 64;
    public int microphoneIdx = 0;
    public float minInputVolume = 0.1f;
    public float forgivingness = 0.2f;
    public float multiplier = 0.8f;
    public GameObject groundSprite;
    public float prepDistance = 2f;
    public float endDistance = 2f;
    public float baseY = -1f;
    public PlayerData playerData;
    
    private float tempWordCounter;
    private float tempPauseCounter;
    private LevelData levelData;
    private bool hasStarted = false;
    private bool isRecording = false;
    private AudioClip microphoneClip;

    void Start()
    {
        MicrophoneToClip();
    }

    void Update()
    {
        if (isRecording) {
            float loudness = GetLoudnessFromMicrophone();
            Debug.Log("loudness is " + loudness);
            if (!hasStarted)
            {
                if (loudness > minInputVolume) {
                    this.tempWordCounter += 1f;
                    this.hasStarted = true;
                } 
            }
            else
            {
                if (loudness > this.minInputVolume)
                {
                    if (this.tempWordCounter == 0)
                    {
                        this.levelData.AddPause(this.tempPauseCounter);
                        this.tempPauseCounter = 0;
                    }
                    this.tempWordCounter += 1f;
                } else {
                    if (this.tempPauseCounter == 0)
                    {
                        this.levelData.AddWord(this.tempWordCounter);
                        this.tempWordCounter = 0;
                    }
                    this.tempPauseCounter += 1f;
                }
            }
        }
    }

    private void MicrophoneToClip() {
        string microphoneName = Microphone.devices[microphoneIdx];
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
    }

    private float GetLoudnessFromMicrophone() {
        return GetLoudnessFromAudioClip(Microphone.GetPosition(Microphone.devices[microphoneIdx]), microphoneClip);
    }

    private float GetLoudnessFromAudioClip(int clipPosition, AudioClip clip) {
        int startPosition = clipPosition - sampleWindow;
        if (startPosition < 0) {
            return 0;
        }
        float[] waveData = new float[sampleWindow];
        clip.GetData(waveData, startPosition);

        float totalLoudness = 0;
        for (int i = 0; i < sampleWindow; i++) {
            totalLoudness += Mathf.Abs(waveData[i]);
        }
        return totalLoudness / sampleWindow;
    }

    public void StartRecording()
    {
        this.levelData = new LevelData();
        foreach (GameObject platform in GameObject.FindGameObjectsWithTag("Platform")) {
            Destroy(platform);
		}
        this.isRecording = true;
    }

    public void EndRecording() {
        if (tempWordCounter > 0)
        {
            this.levelData.AddWord(this.tempWordCounter);
        }
        this.isRecording = false;
        this.BuildGround();
    }

    private float PlacePlatform(float posX, float posY, float scaleX)
    {
		float trueScale = (1 + this.forgivingness) * scaleX * multiplier;
        GameObject platform = Instantiate(this.groundSprite) as GameObject;
		platform.transform.position = new Vector3(posX * this.multiplier + trueScale/2, posY, 0);
        platform.transform.localScale = new Vector3(trueScale, 1, 1);
		return scaleX;
    }

    public void BuildGround()
    {
        this.PlacePlatform(0, this.baseY, this.prepDistance);
        float posX = this.prepDistance;
        float posY = this.baseY;
        int numOfWords = this.levelData.wordDurations.Count;
        if (numOfWords > 0)
        {
            for (int i = 0; i < numOfWords - 1; i++)
            {
                posX += this.levelData.wordDurations[i];
                float offSet = this.levelData.pauseDurations[i];
                posX += this.PlacePlatform(posX, posY, offSet);
            }
            posX += this.levelData.wordDurations[numOfWords - 1];
        }
        posX += this.PlacePlatform(posX, this.baseY, this.endDistance);

    }
}
