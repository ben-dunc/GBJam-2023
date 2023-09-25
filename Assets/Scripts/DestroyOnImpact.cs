using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnImpact : MonoBehaviour {
    
    public GameObject corpse;
    [Tooltip("If this is empty, it will collide with all tags!")]
    public List<string> tagsToCollideWith = new();
    public bool timeout = true;
    public float timeoutTime = 10f;

    private bool isApplicationQuitting = false;

    void Start() {
        if (timeout)
            StartCoroutine(DestroyAfterDelay(timeoutTime));
    }

    IEnumerator DestroyAfterDelay(float time) {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }

    void OnCollisionEnter2D(Collision2D other) {
        if (tagsToCollideWith.Contains(other.gameObject.tag) || tagsToCollideWith.Count == 0) {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (tagsToCollideWith.Contains(other.gameObject.tag) || tagsToCollideWith.Count == 0) {
            Destroy(gameObject);
        }
    }

    void OnDestroy() {
        if (corpse != null && !isApplicationQuitting)
            Instantiate(corpse, transform.position, transform.rotation);
    }

    void OnApplicationQuit () {
        isApplicationQuitting = true;
    }
}
