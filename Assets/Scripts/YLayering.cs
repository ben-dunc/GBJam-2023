using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YLayering : MonoBehaviour {

    private SpriteRenderer sr;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update() {
        sr.sortingOrder = (int) -(transform.position.y * 100);
    }
}
