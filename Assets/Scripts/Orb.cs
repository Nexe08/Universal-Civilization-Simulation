using System.Data;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Orb : MonoBehaviour
{
    int HoldedPoint;

    ProgressionManager pro_man; // progression manager


    void Start()
    {
        pro_man = GameObject.Find("ProgressionManager").GetComponent<ProgressionManager>();
        // it need to be called here so old point gameobject cant update there value in new phase of civilization
        ManageHoldedPoint();
    }
    
    
    void OnDestroy()
    {
        // add point corresponding to its level
        pro_man.SetPoint(HoldedPoint);
        // play animation;
    }    


    void ManageHoldedPoint()
    {
        switch (pro_man.GetCivilizationLevel()) {
            case 0:
                    HoldedPoint = Random.Range(1, 10);
                    break;
                
                case 1:
                    HoldedPoint = Random.Range(100, 1000);
                    break;
                
                case 2:
                    HoldedPoint = Random.Range(10000, 100000);
                    break;
                
                case 3:
                    HoldedPoint = Random.Range(1000000, 100000000);
                    break;
                
            default :
                Debug.LogError("Civilization Level is out of range.");
                break;
        }
    }
}