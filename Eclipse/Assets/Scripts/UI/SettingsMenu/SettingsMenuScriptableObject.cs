using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(SettingsMenuScriptableObject), fileName = nameof(SettingsMenuScriptableObject))]
public class SettingsMenuScriptableObject : BaseScriptableObject
{
    [SerializeField, Range(0f, 100f)] private float _masterVolume;
    [SerializeField, Range(0f, 100f)] private float _defaultSoundVolume;
    [SerializeField, Range(0f, 100f)] private float _defaultMusicVolume;
    [SerializeField, Range(0f, 100f)] private float _defaultBrightnessVolume;
    [SerializeField, Range(0f, 100f)] private float _effectVolume;
    [SerializeField, Range(0f, 100f)] private float _voiceVolume;
    [SerializeField, Range(0f, 100f)] private float _contrastRatio;
    [SerializeField, Range(0f, 100f)] private bool _IsSubtitlesOn;

    public float DefaultSoundVolume { get => _defaultSoundVolume; }
    public float DefaultMusicVolume { get => _defaultMusicVolume; }
    public float DefaultBrightnessVolume { get => _defaultBrightnessVolume; }
    public float DefaultEffectVolume { get => _effectVolume; set => _effectVolume = value; }
    public float DefaultVoiceVolume { get => _voiceVolume; set => _voiceVolume = value; }
    public float DefaultContrastRatio { get => _contrastRatio; set => _contrastRatio = value; }
    public bool DefaultIsSubtitlesOn { get => _IsSubtitlesOn; set => _IsSubtitlesOn = value; }
    public float MasterVolume { get => _masterVolume; set => _masterVolume = value; }
}
