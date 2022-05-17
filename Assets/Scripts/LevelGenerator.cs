using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject platform;
    // public Transform target;
    private int platformCount = 8;
    public float minY = 2f;
    public float maxY = 2.5f;
    public float levelWidth = 3.0f;
    // public UIManager mUIManagerHandle;

    private int UFOSpawnChance;
    public GameObject UFOEnemy;

    public GameObject superPlatform;
    public bool superPlatformSpawnChance = false;

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPos = new Vector3();

        for (int i = 0; i < platformCount; i++)
        {
            spawnPos.y += Random.Range(minY, maxY);
            spawnPos.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platform, spawnPos, Quaternion.identity);
        }
        StartCoroutine(Waiter());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void generatePlatform()
    {
        Vector3 spawnPos = new Vector3();
        spawnPos.y += Random.Range(minY, maxY);
        spawnPos.x = Random.Range(-levelWidth, levelWidth);
        Instantiate(platform, spawnPos, Quaternion.identity);
    }

    IEnumerator Waiter()
    {
        while (true)
        {
            //Wait for 4 seconds
            yield return new WaitForSeconds(3.0f);
            UFOSpawnChance = Random.Range(1,4);
            // UFOSpawnChance = 1;

            Vector3 spawnPos = new Vector3();
            if (UFOSpawnChance == 1)
            {
                spawnPos.x = Random.Range(-levelWidth, levelWidth);
                spawnPos.y = player.transform.position.y + Random.Range(6f,9f);
                Instantiate(UFOEnemy, spawnPos, Quaternion.identity);
            }

            if (superPlatformSpawnChance == false)
            {
                superPlatformSpawnChance = true;
                spawnPos.x = Random.Range(-levelWidth, levelWidth);
                spawnPos.y = player.transform.position.y + Random.Range(6f, 9f);
                Instantiate(superPlatform, spawnPos, Quaternion.identity);
            }

        }

    }
}
