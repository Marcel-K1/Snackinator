using System.Collections;
using System.Collections.Generic;
using Unity;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

    [DisallowMultipleComponent]

    public class OptionMenu : MonoBehaviour
    {
        [SerializeField]
        private AudioMixer m_masterMixer;

        private float m_masterVolume;
        private float m_musicVolume;
        private float m_effectsVolume;

        [SerializeField]
        private Slider m_masterVolumeSlider;
        
        [SerializeField]
        private Slider m_musicVolumeSlider;
        
        [SerializeField]
        private Slider m_effectsVolumeSlider;

        public void Start()
        {
            SetMasterVolumeSlider();
            SetMusicVolumeSlider();
            SetEffectsVolumeSlider();
        }

        public void ChangeMasterVolume(float _value)
        {
            PlayerPrefs.SetFloat("PlayerMasterVolume", _value);
            PlayerPrefs.Save();
            m_masterMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("PlayerMasterVolume", 0f));
        }

        public void SetMasterVolumeSlider()
        {
            m_masterVolumeSlider.value = PlayerPrefs.GetFloat("PlayerMasterVolume", 0f);
        }

        public void ChangeMusicVolume(float _value)
        {
            PlayerPrefs.SetFloat("PlayerMusicVolume", _value);
            PlayerPrefs.Save();
            m_masterMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("PlayerMusicVolume", 0f));
            m_musicVolumeSlider.value = PlayerPrefs.GetFloat("PlayerMusicVolume", 0f);
        }

        public void SetMusicVolumeSlider()
        {
            m_musicVolumeSlider.value = PlayerPrefs.GetFloat("PlayerMusicVolume", 0f);
        }

        public void ChangeEffectVolume(float _value)
        {
            PlayerPrefs.SetFloat("PlayerEffectsVolume", _value);
            PlayerPrefs.Save();
            AudioSource snackEffect = gameObject.GetComponent<AudioSource>();
            snackEffect.Play();
            m_masterMixer.SetFloat("EffectsVolume", PlayerPrefs.GetFloat("PlayerEffectsVolume", 8f));
            m_effectsVolumeSlider.value = PlayerPrefs.GetFloat("PlayerEffectsVolume", 0f);
        }

        public void SetEffectsVolumeSlider()
        {
            m_effectsVolumeSlider.value = PlayerPrefs.GetFloat("PlayerEffectsVolume", 8f);
        }

        public void MuteMaster(bool _mute)
        {
            if (_mute)
            {
                if (m_masterMixer.GetFloat("MasterVolume", out float volume))
                {
                    m_masterVolume = volume;
                }
                m_masterMixer.SetFloat("MasterVolume", -80.0f);
            }
            else
            {
                m_masterMixer.SetFloat("MasterVolume", m_masterVolume);
            }
        }
        public void MuteMusic(bool _mute)
        {
            if (_mute)
            {
                if (m_masterMixer.GetFloat("MusicVolume", out float volume))
                {
                    m_musicVolume = volume;
                }
                m_masterMixer.SetFloat("MusicVolume", -80.0f);
            }
            else
            {
                m_masterMixer.SetFloat("MusicVolume", m_musicVolume);
            }
        }
        public void MuteEffects(bool _mute)
        {
            if (_mute)
            {
                if (m_masterMixer.GetFloat("EffectsVolume", out float volume))
                {
                    m_effectsVolume = volume;
                }
                m_masterMixer.SetFloat("EffectsVolume", -80.0f);
            }
            else
            {
                m_masterMixer.SetFloat("EffectsVolume", m_effectsVolume);
            }
        }
}

