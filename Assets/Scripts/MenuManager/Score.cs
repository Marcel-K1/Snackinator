using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    private float highScore;

    private string nameWinner;

    string highScoreKey = "HighScore";

    string nameKey = "Player";

    [SerializeField]
    public TextMeshProUGUI highscoreText;


    void Start()
    {
        highScore = PlayerPrefs.GetFloat(highScoreKey, 300);
        nameWinner = PlayerPrefs.GetString(nameKey, "Standard");
        highscoreText.text = "Name: "+ nameWinner + "\tHöchstpunktzahl: " + highScore.ToString();
    }

}
