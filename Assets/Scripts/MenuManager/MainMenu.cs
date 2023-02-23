using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

[DisallowMultipleComponent]
    public class MainMenu : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI infoText;

        [SerializeField]
        private TextWriterSingle textWriterSingle;


        private void Start()
        {
            AddWriter(infoText, infoText.text, 0.05f, true);
        }

        private void Update()
        {
            if (textWriterSingle != null)
            {
                textWriterSingle.Update();
            }
        }

        public void AddWriter(TextMeshProUGUI _textField, string _textToWrite, float _timePerCharacter, bool _invisibleCharacters)
        {
            textWriterSingle = new TextWriterSingle(_textField, _textToWrite, _timePerCharacter, _invisibleCharacters);
        }

    //Nested Class um das TMPro Buchstabe für Buchstabe auszugeben
    public class TextWriterSingle
    {
        //Felder
        private TextMeshProUGUI textField;
        private string textToWrite;
        private float timePerCharacter;
        private float timer;
        private int characterIndex;
        private bool invisibleCharacters;

        //Konstruktor
        public TextWriterSingle(TextMeshProUGUI _textField, string _textToWrite, float _timePerCharacter, bool _invisibleCharacters)
        {
            this.textField = _textField;
            this.textToWrite = _textToWrite;
            this.timePerCharacter = _timePerCharacter;
            this.invisibleCharacters = _invisibleCharacters;
            characterIndex = 0;

        }

        // Gibt jeden Buchstaben einzeln aus
        public void Update()
        {
            timer -= Time.deltaTime;
            while (timer <= 0f)
            {
                //Nächsten Buchstaben anzeigen
                timer += timePerCharacter;
                characterIndex++;
                string text = textToWrite.Substring(0, characterIndex);
                if (invisibleCharacters)
                {
                    textField.text += "<color=#00000000>" + textToWrite.Substring(0, characterIndex) + "</color>";
                }
                textField.text = text;
                if (characterIndex >= textToWrite.Length)
                {
                    //Ganzer String wurde angezeigt
                    textField = null;
                    return;
                }
            }
        }
    }
}
