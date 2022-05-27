using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts;

public class OrbSpawner : MonoBehaviour
{
    public GameObject OrbPrefabe;
    public Transform player_position;

    const int MAX_ORB = 20;

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
                Random.Range(player_position.position.x - 10, player_position.position.x + 10),
                Random.Range(player_position.position.y - 10, player_position.position.y + 10),
                0
            ),
            Quaternion.identity,
            transform
        );
    }
}
