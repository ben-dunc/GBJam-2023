using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public GameObject enemy;
    public List<Transform> spawnLocations;
    public float initialSpawnPeriod = 3f;
    public float decay = 0.95f;
    public float decayPeriod = 3f;

    private float spawnTime;
    private float timeRef;

    void Start() {
        spawnTime = initialSpawnPeriod;
        StartCoroutine(DelaySpawn(spawnTime));
        StartCoroutine(DelayDecay(decayPeriod));
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
}
