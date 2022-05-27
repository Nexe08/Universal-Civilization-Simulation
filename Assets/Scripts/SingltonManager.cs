using System.IO.IsolatedStorage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
	public class SingltonManager : MonoBehaviour
	{
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
	}
}

