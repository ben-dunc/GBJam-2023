using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShoot : MonoBehaviour {
    public GameObject bullet;
    public float bulletSpeed = 20f;
    public float fireCooldown = 0.5f;
    readonly float MOVEMENT_DEADZONE = 0.01f;


    Rigidbody2D rb2;    
    Vector3 norm = Vector3.down;
    bool dead = false;
    bool canFire = true;

    void Start() {
        rb2 = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (dead)
            return;
        
        Vector3 dir = GetDir() * 0.5f;
        if (Input.GetKeyDown("z") || Input.GetKeyDown("j") && canFire) {
            Vector3 pos = transform.position + new Vector3(dir.x, dir.y, 0);
            GameObject b = Instantiate(bullet, pos, Quaternion.identity);
            Rigidbody2D rb2 = b.GetComponent<Rigidbody2D>();
            if (rb2 != null)
                rb2.velocity = new Vector2(dir.x, dir.y) * bulletSpeed; 
            canFire = false;
            StartCoroutine(DelayAction(fireCooldown, () => canFire = true));
        } else if (Input.GetKeyDown("x") || Input.GetKeyDown("k")) {
            Debug.Log("FIRE PICKUP!");
        }
    }

    IEnumerator DelayAction(float time, UnityAction action) {
        yield return new WaitForSeconds(time);
        action.Invoke();
    }

    Vector3 GetDir() {
        bool moving = rb2.velocity.magnitude > MOVEMENT_DEADZONE;
        if (moving)
            norm = new Vector3(rb2.velocity.normalized.x, rb2.velocity.normalized.y, 0);

        return norm;
    }

    void Die() {
        dead = true;
    }
}
