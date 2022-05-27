using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ProgressionManager : MonoBehaviour
    {
        public delegate void CollectedPointEventHandler(int collectedPointValue);
        public event CollectedPointEventHandler CollectedPointChanged;

        int CollectedPoint {get; set;}
        [SerializeField] // serialized for debug purpose.
        int CivilizationLevel = 0;
        
        
        ProgressionManager selfInstance;


        void Awake()
        {
            
        }

        
        // called in orb.cs
        public void SetPoint(int value)
        {
            CollectedPoint += value;
            OnColllectedPointChanged();
        }


        public int GetPoint()
        {
            return CollectedPoint;
        }


        public int GetCivilizationLevel()
        {
            return CivilizationLevel;
        }


        protected virtual void OnColllectedPointChanged()
        {
            CollectedPointChanged(CollectedPoint);
        }
        
        // IMGUI
        void OnGUI()
        {
            // civilization level/phase
            GUI.TextArea(new Rect(Screen.width*.2f,0,Screen.width * .1f,Screen.height*.1f), CivilizationLevel.ToString());
        }
    }
}
