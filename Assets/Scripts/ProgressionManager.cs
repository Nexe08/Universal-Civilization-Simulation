using UnityEngine;

namespace Assets.Scripts
{
    public class ProgressionManager : MonoBehaviour
    {
        // this is been using to update HUD
        public delegate void CollectedPointEventHandler(int collectedPointValue, int maxPointValue);
        public event CollectedPointEventHandler CollectedPointChanged;

        [SerializeField] // serialized for debug purpose.
        int CollectedPoint;

        [SerializeField] // serialized for debug purpose.
        int CivilizationLevel = 0;
        
        int MaxCollectedPoint;
        
        ProgressionManager selfInstance;


        void Update()
        {
            HandleCivilizationLevel();
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


        // is  being called in update methode
        void HandleCivilizationLevel()
        {
            // defining civilization level
            if (Utile.GetRange(CollectedPoint, 10000, 100000))
                CivilizationLevel = 1;
            
            if(Utile.GetRange(CollectedPoint, 100000, 1000000))
                CivilizationLevel = 2;

            if(Utile.GetRange(CollectedPoint, 1000000, 10000000))
                CivilizationLevel = 3;

            // defining max collected point value
           switch (CivilizationLevel) {
               case 0:
                   MaxCollectedPoint = 10000;
                   break;
                
                case 1:
                   MaxCollectedPoint = 100000;
                   break;
                
                case 2:
                   MaxCollectedPoint = 1000000;
                   break;
                
                case 3:
                   MaxCollectedPoint = 10000000;
                   break;
                
               default :
                   
                   break;
           }
        }
        

        protected virtual void OnColllectedPointChanged()
        {
            CollectedPointChanged(CollectedPoint, MaxCollectedPoint); // reff to delegate methode
        }


        // IMGUI
        void OnGUI()
        {
            // civilization level/phase
            GUI.TextArea(new Rect(Screen.width*.2f,0,Screen.width * .1f,Screen.height*.1f), CivilizationLevel.ToString());
        }
    }
}
