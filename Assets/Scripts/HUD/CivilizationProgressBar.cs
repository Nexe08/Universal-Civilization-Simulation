using TMPro;
using UnityEngine.UI;
using UnityEngine;
using Assets.Scripts;

public class CivilizationProgressBar : MonoBehaviour
{

    public TMP_Text text;
    
    Slider slider;
    
    void Start()
    {
        slider = GetComponent<Slider>();  
        GameObject.Find("ProgressionManager").GetComponent<ProgressionManager>().CollectedPointChanged += SetCollectedPoint;
    }


    // called by event in progression manager script
    void SetCollectedPoint(int collectedPointValue, int maxPointValue)
    {
        slider.value = collectedPointValue;
        slider.maxValue = maxPointValue;
        text.text = collectedPointValue.ToString();
    }
}
