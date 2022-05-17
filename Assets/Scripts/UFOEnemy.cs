using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.transform.parent.tag == "Player" && this.gameObject != null)
        {
            Debug.Log("Player touch UFO enemy!");
            FindObjectOfType<GameManager>().EndGame();
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }

    void OnBecameInvisible()
	{
		Destroy(this.gameObject);
	}
}
