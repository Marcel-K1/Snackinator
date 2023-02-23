using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


    [DisallowMultipleComponent]

    public class MenuManager : MonoBehaviour
    {

        [SerializeField]
        private PlayerData playerData;

        [SerializeField]
        private Transform m_firstPanel;

        private Stack<Transform> m_activePanels;

        string nameKey = "Player";

        private void Awake()
        {
            m_activePanels = new Stack<Transform>();
            m_activePanels.Push(m_firstPanel);
          
        }

        private void SetPlayerName(string m_playerName)
        {
            playerData.PlayerName = m_playerName;
            PlayerPrefs.SetString(nameKey, playerData.PlayerName);
            PlayerPrefs.Save();
        }

        private void LoadScene(string _sceneName)
        {
            SceneManager.LoadScene(_sceneName);
        }

        private void QuitGame()
        {
            PlayerPrefs.DeleteKey("PlayerMasterVolume");
            PlayerPrefs.DeleteKey("PlayerMusicVolume");
            PlayerPrefs.DeleteKey("PlayerEffectsVolume");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void ShowNext(Transform _next)
        {
            Transform currentPanel = m_activePanels.Peek();
            currentPanel.gameObject.SetActive(false);
            m_activePanels.Push(_next);
            _next.gameObject.SetActive(true);
        }

        private void Close()
        {
            Transform panel = m_activePanels.Pop();
            panel.gameObject.SetActive(false);
            Transform currentPanel = m_activePanels.Peek();
            currentPanel.gameObject.SetActive(true);
        }

        private void DeleteHighscoreAndName()
        {
            PlayerPrefs.DeleteAll();
            LoadScene("MainMenu");
        }
    }
