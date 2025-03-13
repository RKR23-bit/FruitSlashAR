using UnityEngine;

public class FruitSpawner : MonoBehaviour {
    public GameObject fruitPrefab;
    public GameObject bombPrefab;
    public float initialSpawnRate = 1f;
    public float minSpawnRate = 0.3f;
    public float bombChance = 0.2f;
    private float nextSpawn = 0f;
    private float currentSpawnRate;

    void Start() {
        currentSpawnRate = initialSpawnRate;
    }

    public void UpdateSpawnRate(float timeLeft, float totalTime) {
        currentSpawnRate = Mathf.Lerp(minSpawnRate, initialSpawnRate, timeLeft / totalTime);
    }

    void Update() {
        if (Time.time > nextSpawn) {
            nextSpawn = Time.time + currentSpawnRate;
            Vector3 spawnPos = new Vector3(Random.Range(-1f, 1f), 0f, Random.Range(-1f, 1f));
            GameObject prefab = (Random.value < bombChance) ? bombPrefab : fruitPrefab;
            GameObject obj = Instantiate(prefab, spawnPos, Quaternion.identity);
            obj.GetComponent<Rigidbody>().AddForce(Vector3.up * 5f, ForceMode.Impulse);
        }
    }
}