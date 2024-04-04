using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class SettingsService : IDisposable
{
    private Volume _graphicsVolume;
    private AudioSource _mainAudioSource;
    private AudioSource _musicAudioSource;
    private AudioSource _voiceAudioSource;
    private List<AudioSource> _soundAudioSources;
    private List<AudioSource> _effectAudioSources;
    private SettingsMenuModel _model;

    private bool _isOnAutoUpdate = false;

    public SettingsService(ref SettingsMenuModel model)
    {
        _model = model;
        FindGlobalVolumeAndAudioSource();
    }

    public void Dispose()
    {
        _mainAudioSource = null;
        _graphicsVolume = null;
    }

    private void FindGlobalVolumeAndAudioSource()
    {
        _graphicsVolume = EntryPointView.Instance.gameObject.GetComponent<Volume>();
        _mainAudioSource = EntryPointView.Instance.gameObject.GetComponent<AudioSource>();
    }

    public void AutoUpdateSettings(bool settingsIsSaved)
    {
        if (settingsIsSaved)
        {
            EntryPointView.OnUpdate -= UpdateSettings;
            _isOnAutoUpdate = false;
        }
        else if (!_isOnAutoUpdate)
        {
            EntryPointView.OnUpdate += UpdateSettings;
            _isOnAutoUpdate = true;
        }
    }

    private void UpdateSettings()
    {
        _mainAudioSource.volume = _model.GameSettings.MasterVolume;
    }
}
