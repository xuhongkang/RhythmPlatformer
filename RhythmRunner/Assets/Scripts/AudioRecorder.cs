using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioRecorder : MonoBehaviour
{
	public RealTimeData realTime;
	public PlayerData playerStats;
	public int microphoneIdx = 0;
	public int sampleWindow = 64;
	private AudioClip microphoneClip;
	private string microphoneName;

	void Start() {
		foreach (var device in Microphone.devices)
        {
            Debug.Log("Name: " + device);
        }
		microphoneName = Microphone.devices[microphoneIdx];
        microphoneClip = Microphone.Start(microphoneName, true, 20, AudioSettings.outputSampleRate);
	}

	void Update() {
		realTime.volume = GetVolumeFromMicrophone() * 100.0f;
		//Debug.Log(realTime.volume.ToString());
	}

	private float GetVolumeFromMicrophone() {
		int clipPos = Microphone.GetPosition(Microphone.devices[microphoneIdx]);
		return GetVolumeFromAudioClip(clipPos, microphoneClip);
	}

    private float GetVolumeFromAudioClip(int clipPos, AudioClip clip) {
		float totalLoudness = 0;
		if (Microphone.IsRecording(microphoneName)) {
			float[] sampleData = new float[sampleWindow];
			int startPosition = clipPos - sampleWindow - 1;
        	if (startPosition >= 0) {
            	clip.GetData(sampleData, startPosition);
				Debug.Log(sampleData[0]);
				for (int i = 0; i < sampleWindow; i++) {
            		totalLoudness += Mathf.Abs(sampleData[i]);
        		}
			}
		}
		return totalLoudness / sampleWindow;
    }
}