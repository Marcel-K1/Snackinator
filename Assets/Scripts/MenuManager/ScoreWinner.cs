using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreWinner : MonoBehaviour
{
    float highScore;

    string highScoreKey = "HighScore";

    [SerializeField]
    private TextMeshProUGUI highscoreText;


    void Start()
    {
        highScore = PlayerPrefs.GetFloat(highScoreKey, 300);
        highscoreText.text = "Punktzahl: " + highScore.ToString();
    }

}
