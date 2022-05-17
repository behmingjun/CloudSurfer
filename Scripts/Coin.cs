using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioSource mAudioSource;

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
            // mUIHandle.IncreaseScore(5);
            mAudioSource.Play();
            Debug.Log("Audio Playing!");
            ScoreManager.instance.AddPoints(1);
            Destroy(this.gameObject, 0.1f);
        }
    }
}
