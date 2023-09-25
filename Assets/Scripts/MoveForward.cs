using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody2D rb2;

    void Start() {
        rb2 = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        rb2.velocity = transform.up * speed;
    }
}
