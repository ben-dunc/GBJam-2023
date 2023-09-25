using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {

    Rigidbody2D rb2;    
    Animator anim;
    [System.NonSerialized] public string dir = "s";
    readonly float MOVEMENT_DEADZONE = 0.01f;
    bool dead = false;
    
    void Start() {
        rb2 = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update() {
        if (dead) return;
        
        string clipToPlay = GetAnimationName();
        anim.Play(clipToPlay);
    }

    string GetAnimationName() {
        bool moving = rb2.velocity.magnitude > MOVEMENT_DEADZONE;
        float x = (rb2.velocity.x < MOVEMENT_DEADZONE && rb2.velocity.x > -MOVEMENT_DEADZONE ? 0 : rb2.velocity.x);
        float y = (rb2.velocity.y < MOVEMENT_DEADZONE && rb2.velocity.y > -MOVEMENT_DEADZONE ? 0 : rb2.velocity.y);

        if (y > 0 && x == 0) {
            dir = "n";
        } else if (x > 0) {
            if (y > 0)
                dir = "ne";
            else if (y == 0)
                dir = "e";
            else if (y < 0)
                dir = "se";
        } else if (y < 0 && x == 0) {
            dir = "s";
        } else if (x < 0) {
            if (y < 0)
                dir = "sw";
            else if (y == 0)
                dir = "w";
            else if (y > 0)
                dir = "nw";
        }
        
        return $"player-{ (moving ? "move" : "idle") }-{ dir }_Clip";
    }

    void Die() {
        dead = true;
        anim.Play("player-die_Clip");
    }
}
