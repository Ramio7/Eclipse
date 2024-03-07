using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuView : MonoBehaviour, IView
{
    [SerializeField] private SettingsMenuScriptableObject _settingsDefaults;

    [SerializeField] private Slider _masterSoundVolumeSlider;
    [SerializeField] private Slider _soundVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _effectVolumeSlider;
    [SerializeField] private Slider _voiceVolumeSlider;
    [SerializeField] private Slider _brightnessVolumeSlider;
    [SerializeField] private Slider _contrastRatioSlider;
    [SerializeField] private Toggle _subtitlesToogle;

    private SettingsMenuController _controller;

    public List<Action> Actions => throw new NotImplementedException();

    private void OnEnable()
    {
        _controller = new(this, _settingsDefaults);
    }

    private void OnDestroy()
    {
        _controller.Dispose();

        _controller = null;
    }
}
