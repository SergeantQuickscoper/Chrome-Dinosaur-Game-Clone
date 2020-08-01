using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  TMPro;


public class ScoreManager : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI scoreText;
   [SerializeField] private TextMeshProUGUI highScoreText;

   public float score = 0;
   public float highScore = 0;
   [HideInInspector] public bool isScoreIncreasing = false;
   public float scorePerSecond = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isScoreIncreasing == true)
        {
            score = score + scorePerSecond * Time.fixedDeltaTime;
        }

        if(score >= highScore)
         {
             highScore = score;
         }
        
        scoreText.text = "Score: " + Mathf.Round(score);
        
        if(isScoreIncreasing == false)
        {
            highScoreText.text = "High Score: " + Mathf.Round(highScore);
        }

    }
}
