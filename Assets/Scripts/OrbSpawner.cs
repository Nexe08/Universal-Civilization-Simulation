using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class OrbSpawner : MonoBehaviour
{
    public GameObject OrbPrefabe;
    public Transform player_position;

    public float SpawneRadius = 7;
    public int MAX_ORB = 40;
    

    void Start()
    {
        for (int i=0; i < MAX_ORB; i++)
        {
            _AddOrbInstance();
        }
    }
    
    void Update()
    {
        if (SingltonManager.Instance.OrbDestroyed)        
        {
            _AddOrbInstance();
            SingltonManager.Instance.OrbDestroyed = false;
        }
    }

    void _AddOrbInstance()
    {
        Instantiate(
            OrbPrefabe,
            new Vector3(
                Random.Range(player_position.position.x - SpawneRadius, player_position.position.x + SpawneRadius),
                Random.Range(player_position.position.y - SpawneRadius, player_position.position.y + SpawneRadius),
                0
            ),
            Quaternion.identity,
            transform
        );
    }
}
