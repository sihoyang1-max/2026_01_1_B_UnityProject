using UnityEditor;
using UnityEngine;

public class NewMonoBehaviourScript1 : MonoBehaviour
{
    public GameObject coinPrefabs;
    public GameObject MissilePrefabs;

    [Header("스폰 타이밍 설정")]
    public float minSpawnlnterval = 0.5f;
    public float maxSpawnlnterval = 2.0f;

    public float timer = 0.0f;
    public float nextSpawntime;

    [Header("동전 스폰 확률 설정")]
    [Range(0, 100)]
    public int coinSpawnChance = 50;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetNextSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > nextSpawntime)
        {
            SpawnObect();
            timer = 0.0f;
            SetNextSpawnTime();
        }
    }
    void SpawnObect()
    {
        Transform spawnTransform = transform;
        int randomValue = Random.Range(0, 100);

        if (randomValue < coinSpawnChance)
        {
            Instantiate(coinPrefabs, spawnTransform.position, spawnTransform.rotation);
        }
        else
        {
            Instantiate(MissilePrefabs, spawnTransform.position, spawnTransform.rotation);
        }
    }
    void SetNextSpawnTime()
    {
        nextSpawntime = Random.Range(minSpawnlnterval, maxSpawnlnterval);
    }
}
    

