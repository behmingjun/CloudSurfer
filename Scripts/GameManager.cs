using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    private float restartDelay = 0.5f;
    public GameOverScreen GameOverScreen;
    public AudioSource mAudioSource;

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            mAudioSource.Play();
            Debug.Log("Game has ended!");
            Invoke("GameOver", restartDelay); 
        }
    }

    void GameOver()
    {
        GameOverScreen.Setup(ScoreManager.instance.getPoints());
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
