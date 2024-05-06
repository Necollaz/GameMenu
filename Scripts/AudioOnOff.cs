using UnityEngine;

public class AudioOnOff : MonoBehaviour
{
    [SerializeField] private AudioSource _audio;

    private bool _isAudioOn = true;

    private void Start()
    {
        UpdateAudioState();
    }

    public void ToggleSound()
    {
        _isAudioOn = !_isAudioOn; 
        UpdateAudioState();

        if (_isAudioOn && _audio.clip != null && !_audio.isPlaying)
        {
            _audio.Stop();
            _audio.Play();
        }
        else if (!_isAudioOn && _audio.isPlaying)
        {
            _audio.Stop();
        }
    }

    private void UpdateAudioState()
    {
        _audio.volume = _isAudioOn ? 1.0f : 0.0f;
    }
}
