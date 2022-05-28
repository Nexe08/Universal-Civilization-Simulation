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
    
    public int CollectedPoint;
    Slider slider;
    
    void Start()
    {
        slider = GetComponent<Slider>();  
        GameObject.Find("ProgressionManager").GetComponent<ProgressionManager>().CollectedPointChanged += SetCollectedPoint;
    }


    // called based on event in progression manager
    void SetCollectedPoint(int collectedPointValue)
    {
        CollectedPoint = collectedPointValue;
        UpdateCollectedPointVisuals();
    }


    void UpdateCollectedPointVisuals()
    {
        slider.value = CollectedPoint;
        slider.maxValue = 20;
        text.text = CollectedPoint.ToString();
    }
}
