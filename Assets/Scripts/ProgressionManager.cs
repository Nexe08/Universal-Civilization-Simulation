using UnityEngine;

namespace Assets.Scripts
{
    public class ProgressionManager : MonoBehaviour
    {
        // this is been using to update HUD
        public delegate void CollectedPointEventHandler(int collectedPointValue);
        public event CollectedPointEventHandler CollectedPointChanged;

        [SerializeField] // serialized for debug purpose.
        int CollectedPoint;

        [SerializeField] // serialized for debug purpose.
        int CivilizationLevel = 0;
        
        
        ProgressionManager selfInstance;


        void Update()
        {
            HandleCivilizationLevel();
            OnColllectedPointChanged();
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
            if (Utile.GetRange(CollectedPoint, 10000, 100000))
                CivilizationLevel = 1;
            
            if(Utile.GetRange(CollectedPoint, 100000, 1000000))
                CivilizationLevel = 2;

            if(Utile.GetRange(CollectedPoint, 1000000, 10000000))
                CivilizationLevel = 3;
        }
        

        protected virtual void OnColllectedPointChanged()
        {
            CollectedPointChanged(CollectedPoint); // reff to delegate methode
        }


        // IMGUI
        void OnGUI()
        {
            // civilization level/phase
            GUI.TextArea(new Rect(Screen.width*.2f,0,Screen.width * .1f,Screen.height*.1f), CivilizationLevel.ToString());
        }
    }
}
