using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI text;
    public static int score;
    public static int rawScore;
    public TextMeshProUGUI endText;
    

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void ChangeScore(int coinValue)
    {
        score += coinValue;
        text.text = "x" + score.ToString();
        rawScore += Mathf.Abs(coinValue);
    }

    public void Update()
    {
        if (QuizUI.userWin)
        {
            endText.text = "You scored " + rawScore.ToString() + " points! Great Job!";
        }
        if (PlayerMovement.gameOver)
        {
            endText.text = "You scored " + rawScore.ToString() + " points! Great Job!";
        }
    }
}
