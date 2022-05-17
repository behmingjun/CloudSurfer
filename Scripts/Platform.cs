using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField]
    private float jumpForce = 12f;
    public float levelWidth = 3.0f;
    public Transform target;
    
    private int coinSpawnChance;
    public GameObject coin;
    private GameObject coinObject;
    private bool coinSpawned;
    // public bool seen = false;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.y <= 0f)
        {
            Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 velocity = rb.velocity;
                velocity.y = jumpForce;
                rb.velocity = velocity;
            }
        }

        
    }

    // Start is called before the first frame update
    void Start()
    {
        spawnCoin();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnBecameInvisible()
    {
        if (target != null)
        {
            if (coinSpawned == true)
            {
                Destroy(coinObject);
                coinSpawned = false;
            }
    
            Vector3 newSpawnPos = new Vector3();
            newSpawnPos.x = Random.Range(-levelWidth, levelWidth);
            newSpawnPos.y = target.position.y + 5;
            transform.position = newSpawnPos;
            spawnCoin();
        }
    }

    void spawnCoin()
    {
        // spawn coin on top of the platform
        coinSpawnChance = Random.Range(0, 2);
        if (coinSpawnChance == 1)
        {
            coinSpawned = true;
            Vector3 spawnPos = new Vector3();
            spawnPos.x = transform.position.x;
            spawnPos.y = (float) (transform.position.y + 0.5);
            spawnPos.z = transform.position.z;
            coinObject = Instantiate(coin, spawnPos, Quaternion.identity);
        }
        
        else
        {
            coinSpawned = false;
        }
    }
}
