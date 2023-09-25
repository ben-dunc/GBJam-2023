using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int health = 3;
    public UnityEvent onDeath = new();

    void Start() {
        // generate health icons
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Enemy") {
            collision.gameObject.SendMessage("Die");
            health--;
        }

        if (health <= 0) {
            Die();
        }
    } 

    void Die() {
        health = 0;
        SendMessage("Die");
    }
}
