using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    [CreateAssetMenu(fileName = "Empty Player Data", menuName = "Data/Player")]

    public class PlayerData : ScriptableObject
    {
        [SerializeField]
        private string m_playerName;
        public string PlayerName { get => m_playerName; set => m_playerName = value; }
    }

