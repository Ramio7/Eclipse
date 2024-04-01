using System;
using UnityEngine;
using UnityEngine.Rendering;

public class SettingsService : IDisposable
{
    private Volume _graphicsVolume;
    private AudioSource _audioSource;
    private SettingsMenuModel _model;

    private bool _isOnAutoUpdate;

    public SettingsService(ref SettingsMenuModel model)
    {
        _model = model;

        FindGlobalVolumeAndAudioSource();
    }

    public void Dispose()
    {
        _audioSource = null;
        _graphicsVolume = null;
    }

    private void FindGlobalVolumeAndAudioSource()
    {
        _graphicsVolume = EntryPointView.Instance.gameObject.GetComponent<Volume>();
        _audioSource = EntryPointView.Instance.gameObject.GetComponent<AudioSource>();
    }

    public void AutoUpdateSettings(bool settingsIsChanged)
    {
        if (!settingsIsChanged) return;
        else if (!_isOnAutoUpdate) EntryPointView.OnUpdate += UpdateSettings;
    }

    private void UpdateSettings()
    {
        _audioSource.volume = _model.GameSettings.MasterVolume;
    }
}
