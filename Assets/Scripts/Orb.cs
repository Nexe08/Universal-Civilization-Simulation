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
        ManageHoldedPoint();
    }
    
    
    void OnDestroy()
    {
        // add point corresponding to its level
        pro_man.SetPoint(HoldedPoint);
        // event
        SingltonManager.Instance.OrbDestroyed = true;
        // play animation;
    }    


    void ManageHoldedPoint()
    {
        switch (pro_man.GetCivilizationLevel()) {
            case 0:
                    HoldedPoint = Random.Range(1, 10);
                    gameObject.transform.localScale = new Vector3(1,1,1);
                    break;
                
                case 1:
                    HoldedPoint = Random.Range(100, 1000);
                    gameObject.transform.localScale = new Vector3(1.5f,1.5f,1.5f);
                    break;
                
                case 2:
                    HoldedPoint = Random.Range(10000, 100000);
                    gameObject.transform.localScale = new Vector3(2,2,2);
                    break;
                
                case 3:
                    HoldedPoint = Random.Range(1000000, 100000000);
                    gameObject.transform.localScale = new Vector3(2.5f,2.5f,2.5f);
                    break;
                
            default :
                Debug.LogError("Civilization Level is out of range.");
                break;
        }
    }
}