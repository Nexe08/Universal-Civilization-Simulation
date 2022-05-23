using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class Orb : MonoBehaviour
{
    int HoldedPoint = 1;
    
    void OnDestroy()
    {
        // add point corresponding to its level
        GameObject pro_man = GameObject.Find("ProgressionManager");
        pro_man.GetComponent<ProgressionManager>().AddPoint(HoldedPoint);
        // play animation;
    }    
}