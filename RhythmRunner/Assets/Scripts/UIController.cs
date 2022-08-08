using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField] public RealTimeData realTime;
    [SerializeField] public TextMeshProUGUI distanceText;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        distanceText.text = "Distance: " + Mathf.Round(realTime.distance).ToString();
    }
}
