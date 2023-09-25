using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour {

    GameObject player;
    Rigidbody2D rb2;
    
    void Start() {
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        rb2 = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (player == null)
            player = GameObject.FindGameObjectsWithTag("Player")[0];
        
        if (player != null) {
            // move towards player
            rb2.velocity = (player.transform.position - transform.position).normalized;
            
        }
    }
}
