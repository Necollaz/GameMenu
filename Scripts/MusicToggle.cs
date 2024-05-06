using UnityEngine;
using System.Collections.Generic;

public class MusicToggle : MonoBehaviour
{
    [SerializeField] private List<AudioSource> _audioSources;

    private bool _isEnabled = true;

    private void Update()
    {
        foreach (var audio in _audioSources)
        {
            audio.enabled = _isEnabled;
        }
    }

    public void EnadleMusic()
    {
        _isEnabled = !_isEnabled;
    }
}
