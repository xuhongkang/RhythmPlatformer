using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] public RealTimeData realTime;
    [SerializeField] public TextMeshProUGUI textDisplay;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        textDisplay.text = "Distance: " + Mathf.Round(realTime.distance).ToString() 
                             + "\nVelocity: " + Mathf.Round(realTime.velocity.x).ToString()
                             + "\nAcceleration: " + Mathf.Round(realTime.hAcceleration).ToString()
							 + "\nInput Volume: " + (Mathf.Round(realTime.volume) * 100.0f).ToString("0.00");
    }
}
