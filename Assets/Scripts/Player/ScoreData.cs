using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "Empty Score Data", menuName = "Data/Score")]

    public class ScoreData : ScriptableObject
    {
        [SerializeField]
        private float m_playerScore;
        public float PlayerScore { get => m_playerScore; set => m_playerScore = value; }

    }

