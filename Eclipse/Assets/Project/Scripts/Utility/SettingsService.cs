using System;
using UnityEngine;
using UnityEngine.Rendering;

public class SettingsService : IDisposable
{
    private Volume _graphicsVolume;
    private AudioSource _audioSource;
    private GameSettings _gameSettings; //need to make it refferal

    public GameSettings GameSettings { get => _gameSettings; set => _gameSettings = value; }

    public SettingsService(GameSettings gameSettings)
    {
        _gameSettings = gameSettings;
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
        else
        {

        }
    }
}
