using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnImpact : MonoBehaviour {
    
    public GameObject corpse;
    [Tooltip("If this is empty, it will collide with all tags!")]
    public List<string> tagsToCollideWith = new();

    void OnCollisionEnter2D(Collision2D other) {
        if (tagsToCollideWith.Contains(other.gameObject.tag) || tagsToCollideWith.Count == 0) {
            if (corpse != null)
                Instantiate(corpse);
            Debug.Log("Destroy this!");
            Destroy(gameObject);
        }
    }
}
