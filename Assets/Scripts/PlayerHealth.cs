using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {
    
    public Image heartsImage;
    public Sprite health3;
    public Sprite health2;
    public Sprite health1;
    public int health = 3;
    public UnityEvent onDeath = new();

    void Start() {
        heartsImage.sprite = health3;
    }

    void OnCollisionEnter2D(Collision2D collision) {
        
        if (collision.gameObject.tag == "Enemy") {
            health--;
            
            if (health == 2)
                heartsImage.sprite = health2;
            if (health == 1)
                heartsImage.sprite = health1;
            if (health == 0)
                heartsImage.color = new Color(0, 0, 0, 0);
        }

        if (health <= 0) {
            Die();
        }
    } 

    void Die() {
        health = 0;
        onDeath.Invoke();
    }
}
