using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[DisallowMultipleComponent]
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private TimerController time;

        [SerializeField]
        private ScoreData score;

        float highScore;

        string highScoreKey = "HighScore";


        private void Awake()
        {
            GetComponent<TimerController>();
        }

        private void Start()
        {
            if (score.PlayerScore != 0)
            {
                score.PlayerScore = 0;
            }

            highScore = PlayerPrefs.GetFloat(highScoreKey, 300);

            TimerController.instance.BeginTimer();
        }

        private void Update()
        {
            PlayerWon();
            PlayerLoose();
        }

        private void LoadScene(string _sceneName)
        {
            SceneManager.LoadScene(_sceneName);
        }

        private void PlayerWon()
        {
            if (TimerController.instance.timeCounter.text == "ENDE" && score.PlayerScore > highScore)
            {
                PlayerPrefs.SetFloat(highScoreKey, score.PlayerScore);
                PlayerPrefs.Save();
                LoadScene("Win");
            }
        }

        private void PlayerLoose()
        {
            if (TimerController.instance.timeCounter.text == "ENDE"
                && score.PlayerScore < highScore)
            {
                LoadScene("Loose");
            }
        }
    }


