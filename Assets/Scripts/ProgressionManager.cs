using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class ProgressionManager : MonoBehaviour
    {
        int CollectedPoint = 0;
        [SerializeField]
        int CivilizationLevel = 0;
        
        ProgressionManager selfInstance;

        void Awake()
        {
            if (selfInstance == null)
            {
                selfInstance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                DestroyImmediate(gameObject);
            }
        }

        
        // called in orb.cs
        public void SetPoint(int value)
        {
            CollectedPoint += value;
        }


        public int GetPoint()
        {
            return CollectedPoint;
        }


        public int GetCivilizationLevel()
        {
            return CivilizationLevel;
        }

        // IMGUI
        void OnGUI()
        {
            GUI.TextArea(new Rect(Screen.width / 2,0,Screen.width * .1f,Screen.height*.1f), CollectedPoint.ToString());
        }
    }
}
