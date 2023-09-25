using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour {
    public List<TMP_Text> scoreText;
    public GameObject enemy;
    public List<Transform> spawnLocations;
    public float initialSpawnPeriod = 3f;
    public float decay = 0.95f;
    public float decayPeriod = 3f;
    public float score = 0;

    float spawnTime;
    PlayerHealth pHealth;

    void Start() {
        pHealth = FindObjectOfType<PlayerHealth>();    
        spawnTime = initialSpawnPeriod;
        StartCoroutine(DelaySpawn(spawnTime));
        StartCoroutine(DelayDecay(decayPeriod));
        StartCoroutine(DelayScore());
    }

    void Update() {
        foreach (TMP_Text t in scoreText)
            t.text = score.ToString();
    }

    IEnumerator DelayScore() {
        yield return new WaitForSeconds(1f);
        if (pHealth.health != 0) {
            score++;
            StartCoroutine(DelayScore());
        }
    }

    IEnumerator DelayDecay(float time) {
        yield return new WaitForSeconds(time);
        spawnTime *= decay;
        StartCoroutine(DelayDecay(decayPeriod));
    }
    
    IEnumerator DelaySpawn(float time) {
        yield return new WaitForSeconds(time);
        SpawnEnemy();
        StartCoroutine(DelaySpawn(spawnTime));
    }

    void SpawnEnemy() {
        int i = (int) (Random.value * spawnLocations.Count * 10) % spawnLocations.Count;
        
        while (i < 0 || i >= spawnLocations.Count)
            i = (int) (Random.value * spawnLocations.Count * 10) % spawnLocations.Count;

        Transform s = spawnLocations[i];

        Instantiate(enemy, s.position, Quaternion.identity);
    }

    public void AddScore(int s) {
        this.score += s;
    }
}
