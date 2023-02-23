using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KeepPlayerScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI currentScore;

    [SerializeField]
    private TextMeshProUGUI highScoreText;

    [SerializeField]
    private ScoreData scoreData;

    private void Start()
    {
        highScoreText.text = PlayerPrefs.GetFloat("HighScore", 300).ToString();
    }

    private void Update()
    {
        currentScore.text = scoreData.PlayerScore.ToString();
    }

    //Teilt den Snacks verschiedene Punkte zu
    private void OnTriggerEnter2D(Collider2D _collision)
        {
            switch (_collision.gameObject.tag)
            {
                case "Soda":
                    scoreData.PlayerScore += 5f;
                    break;
                case "Chocolate":
                    scoreData.PlayerScore += 6f;
                    break;
                case "Candy":
                    scoreData.PlayerScore += 15f;
                    break;
                case "Chips":
                    scoreData.PlayerScore += 9f;
                    break;
                case "Nuts":
                    scoreData.PlayerScore += 10f;
                    break;
                default:
                    break;
            }
        }
}

