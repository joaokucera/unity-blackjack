using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    private AudioSource _audioSource;
    private bool _isAudioDisabled;

    [SerializeField]
    private AudioClip _buttonClip;
    [SerializeField]
    private AudioClip _cardClip;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        var uiManager = FindObjectOfType<UIManager>();
        uiManager.OnAudioButtonEvent += SwitchAudioEvent;
    }

    public bool SwitchAudioEvent()
    {
        _isAudioDisabled = !_isAudioDisabled;

        return _isAudioDisabled;
    }

    public void PlayButtonClip()
    {
        PlayClip(_buttonClip);
    }

    public void PlayCardClip()
    {
        PlayClip(_cardClip);
    }

    private void PlayClip(AudioClip clip)
    {
        if (_isAudioDisabled) {
            return;
        }

        _audioSource.PlayOneShot(clip);
    }
}