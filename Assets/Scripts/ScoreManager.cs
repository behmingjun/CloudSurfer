using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text mText;

    private int mScore;
    public static ScoreManager instance;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        mText.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddPoints(int value) 
    {
        mScore = mScore + value;
        mText.text = "Score: " + mScore;
    }

    public int getPoints()
    {
        return mScore;
    }
}
