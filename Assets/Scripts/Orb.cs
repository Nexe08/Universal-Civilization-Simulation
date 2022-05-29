using Assets.Scripts;
using UnityEngine;

public class Orb : MonoBehaviour
{
    int HoldedPoint;
    float MaxDistanceFromPlayer = 10f;
    bool IsSelfDestructed = false;

    ProgressionManager pro_man; // progression manager
    GameObject player;
    Animation anim;


    void Start()
    {
        player = GameObject.Find("Player");
        pro_man = GameObject.Find("ProgressionManager").GetComponent<ProgressionManager>();
        anim = GetComponent<Animation>();
        ManageHoldedPoint();
    }


    void Update()
    {
        // destroyed if is far from player position
        if (Vector3.Distance(transform.position, player.GetComponent<Transform>().position) > MaxDistanceFromPlayer) {
            Destroy(gameObject, 1f);
            IsSelfDestructed = true;
        }
    }
    
    
    void OnDestroy()
    {
        if (!IsSelfDestructed)
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