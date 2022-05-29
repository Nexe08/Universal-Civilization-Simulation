using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Assets.Scripts;

public class CivilizationProgressBar : MonoBehaviour
{

    public TMP_Text text;
    
    int CollectedPoint;
    int MaxPoint;
    Slider slider;
    
    void Start()
    {
        slider = GetComponent<Slider>();  
        GameObject.Find("ProgressionManager").GetComponent<ProgressionManager>().CollectedPointChanged += SetCollectedPoint;
    }


    // called based on event in progression manager
    void SetCollectedPoint(int collectedPointValue, int maxPointValue)
    {
        CollectedPoint = collectedPointValue;
        MaxPoint = maxPointValue;
        UpdateCollectedPointVisuals();
    }


    // collected ponit slider
    void UpdateCollectedPointVisuals()
    {
        slider.value = CollectedPoint;
        slider.maxValue = MaxPoint;
        text.text = CollectedPoint.ToString();
    }
}
