using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    public GameObject Bulletprefab;
    public float SpawneRateMin = 1f;
    public float SpawneMaxMin = 4f;
    Transform target;
    float SpawnRate;
    float timeAfterSpawn;

    public float distancemonkey = 10f;

    void Start()
    {
        timeAfterSpawn = 0f;
        SpawnRate = Random.Range(SpawneRateMin, SpawneMaxMin);
        target = FindFirstObjectByType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime;

        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= distancemonkey && timeAfterSpawn >= SpawnRate)
        {
            timeAfterSpawn = 0f;
            GameObject bullet = Instantiate(Bulletprefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
            SpawnRate = Random.Range(SpawneRateMin, SpawneMaxMin);
        }
    }
}
