using UnityEngine;
using UnityEngine.Rendering;

public class SettingsService : MonoBehaviour
{
    private Volume _graphicsVolume;
    private AudioSource _audioSource;
    private SettingsMenuModel.GameSettings _gameSettings;


    private void FindGlobalVolumeAndAudioSource()
    {
        _graphicsVolume = EntryPointView.Instance.gameObject.GetComponent<Volume>();
        _audioSource = EntryPointView.Instance.gameObject.GetComponent<AudioSource>();
    }
}
