using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour {

    public float score = 10;

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
            PlayerHealth pHealth = player.GetComponent<PlayerHealth>();    
            if (pHealth != null && pHealth.health != 0) {
                // move towards player
                rb2.velocity = (player.transform.position - transform.position).normalized;
            } else {
                rb2.velocity = Vector2.zero;
            }
        } else {
            rb2.velocity = Vector2.zero;
        }
    }

    void OnDestroy() {
        GameManager gm = FindObjectOfType<GameManager>();
        if (gm != null)
            gm.AddScore(10);
    }
}
