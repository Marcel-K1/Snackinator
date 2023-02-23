using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
    [SerializeField]
    public static TimerController instance;

    [SerializeField]
    public TextMeshProUGUI timeCounter;

    [SerializeField]
    public AutomaticMovement speedControlArm;

    [SerializeField]
    public PlayerMovement speedControlPlayer;

    private bool timerGoing;
    private float roundTime; 
    private TimeSpan timeLeft;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GetComponent<AutomaticMovement>();
        GetComponent<PlayerMovement>();
    }

    public void BeginTimer()
    {
        timerGoing = true;
        roundTime = 80f;
        StartCoroutine(UpdateTimer());
    }

    //Aktualisiert den Timer und die Geschwindigkeit der Arm Bewegung abhängig von der verbleibenden Zeit
    private IEnumerator UpdateTimer()
    {
        while (timerGoing)
        {
            roundTime -= Time.deltaTime;
            timeLeft = TimeSpan.FromSeconds(roundTime);
            string timeLeftStr = timeLeft.ToString("mm':'ss");
            timeCounter.text = timeLeftStr;
            if (roundTime < 50f)
            {
                speedControlArm.Speed = 25f;
            }
            if (roundTime < 30f)
            {
                speedControlArm.Speed = 35f;
            }
            if (roundTime <= 0f)
            {
                timeCounter.text = "ENDE";
                speedControlArm.Speed = 0f;
                timerGoing = false;
                break;
            }
            yield return null;
        }



    }

}
