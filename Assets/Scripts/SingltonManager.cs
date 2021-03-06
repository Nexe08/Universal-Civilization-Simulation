using System.IO.IsolatedStorage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class SingltonManager : MonoBehaviour
	{
        [HideInInspector]
		public bool OrbDestroyed;
		
		public static SingltonManager Instance;

		void Awake()
		{
			if (SingltonManager.Instance == null)
            {
                SingltonManager.Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                DestroyImmediate(gameObject);
            }
		}
	} // class end

    
    public class Utile
    {
        public static bool GetRange(int value, int rangeA, int rangeB)
        {
            if (value > rangeA && value < rangeB)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    } // class end
}


