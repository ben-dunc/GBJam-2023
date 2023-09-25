using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    
    public float speed = 10f;
    private Rigidbody2D rb2;
    private bool dead = false;

    void Start() {
        rb2 = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (dead) {
            SetVelocity(Vector2.zero, 0);
            return;
        }

        Vector2 inputAxis = GetInputAxis();
        SetVelocity(inputAxis, speed);
    }

    void SetVelocity(Vector2 dir, float speed) {
        rb2.velocity = dir * speed;
    }

    Vector2 GetInputAxis() {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (h < 0)
            h = -1;
        else if (h > 0)
            h = 1;

        if (v < 0)
            v = -1;
        else if (v > 0)
            v = 1;

        return new Vector2(h, v).normalized;
    }

    void Die() {
        dead = true;
    }
}
