using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YLayering : MonoBehaviour {

    public float offsetByUnit = 0f;
    private SpriteRenderer sr;

    void Start() {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update() {
        sr.sortingOrder = (int) -((transform.position.y + offsetByUnit) * 100);
    }
}
