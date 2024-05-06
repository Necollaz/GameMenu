using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMusic : MonoBehaviour
{
    [SerializeField] private AudioMixer _mixer;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _buttonMusicSlider;
    [SerializeField] private Slider _backgroundMusicSlider;

    private void Start()
    {
        InitializeVolume("AllMusicVolume", _musicSlider);
        InitializeVolume("ButtonVolume", _buttonMusicSlider);
        InitializeVolume("MusicVolume", _backgroundMusicSlider);

        _musicSlider.onValueChanged.AddListener(volume => SetMusicVolume("AllMusicVolume", volume));
        _buttonMusicSlider.onValueChanged.AddListener(volume => SetMusicVolume("ButtonVolume", volume));
        _backgroundMusicSlider.onValueChanged.AddListener(volume => SetMusicVolume("MusicVolume", volume));
    }

    public void SetMusicVolume(string parameterName, float volume)
    {
        _mixer.SetFloat(parameterName, Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat(parameterName, volume);
    }

    public void InitializeVolume(string parameterName, Slider slider)
    {
        float defaultVolume = 0.75f;
        slider.value = PlayerPrefs.GetFloat(parameterName, defaultVolume);
        SetMusicVolume(parameterName, slider.value);
    }
}
