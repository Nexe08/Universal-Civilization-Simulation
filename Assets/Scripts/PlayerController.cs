using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public AudioSource HeartBeat;
    public bool PlayHeartBeatSFX = false; // will get enabled in animation player
    public float runSpeed = 3.0f;

    Rigidbody2D body;
    Animation anim;

    float horizontal;
    float vertical;
    float moveLimiter = .7f;


    void Start(){
        body = GetComponent<Rigidbody2D>();    
        anim = GetComponent<Animation>();
    }


    void Update(){
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        HandleSFX();
    }


    void FixedUpdate(){
        if (horizontal != 0 && vertical != 0)
        {
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }
        
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    protected void HandleSFX() {
        if (HeartBeat.time == HeartBeat.clip.length) {
            PlayHeartBeatSFX = false;
        }

        if (PlayHeartBeatSFX) {
            if (HeartBeat.isPlaying) {
                return;
            }
            HeartBeat.Play();
        }
    }
}
