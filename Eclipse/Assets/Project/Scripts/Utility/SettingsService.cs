using System;
using UnityEngine.Audio;
using UnityEngine.Rendering;

public class SettingsService : IDisposable
{
    private VolumeProfile _graphicsVolume;
    private AudioMixer _mixer;
    private SettingsMenuModel _model;

    private bool _isOnAutoUpdate = false;

    public SettingsService(ref SettingsMenuModel model)
    {
        _model = model;
        
        FindGraphicsVolumeAndAudioMixer();
    }

    public void Dispose()
    {
        _graphicsVolume = null;
        _mixer = null;
        _model = null;
    }

    private void FindGraphicsVolumeAndAudioMixer()
    {
        _graphicsVolume = EntryPointView.Instance.VolumeProfile;
        _mixer = EntryPointView.Instance.AudioMixer;
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
        UpdateAudioMixer();
        UpdateVolumeProfile();
    }

    private void UpdateAudioMixer()
    {
        _mixer.SetFloat("MasterVolume", _model.GameSettings.MasterVolume);
        _mixer.SetFloat("MusicVolume", _model.GameSettings.MusicVolume);
        _mixer.SetFloat("VoiceVolume", _model.GameSettings.VoiceVolume);
        _mixer.SetFloat("SoundVolume", _model.GameSettings.SoundVolume);
        _mixer.SetFloat("EffectVolume", _model.GameSettings.EffectVolume);
    }

    private void UpdateVolumeProfile()
    {

    }
}
