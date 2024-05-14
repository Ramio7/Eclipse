using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyBindSettingsModel : IModel
{
    private GameState _gameState = GameState.KeyBindMenu;

    private KeyBindSettings _savedSettings = new();
    private KeyBindSettings _tempSettings = new();

    private string _settingsFilePath = Application.dataPath + "/Project/Resources/KeyBindSettings.json";

    public ReactiveProperty<bool> SettingsIsSaved = new(true);

    public KeyBindSettingsModel(IScriptableObject defaultSettings, Canvas keyBindSettingsMenuCanvas)
    {
        CanvasSelector.AddCanvas(_gameState, keyBindSettingsMenuCanvas);
        var defaults = defaultSettings as KeyBindSettingsScriptableObject;
        InitKeyBindSettings(defaults);
    }

    public KeyBindSettings KeyBindSettings { get => _savedSettings; }

    private void InitKeyBindSettings(KeyBindSettingsScriptableObject defaults)
    {
        if (!CheckSettingsFile())
        {
            _savedSettings.Set(defaults.JumpKey, defaults.ShiftKey, defaults.CrouchKey, defaults.SlideKey,
                defaults.FirstAbilityKey, defaults.SecondAbilityKey, defaults.ThirdAbilityKey, defaults.FourthAbilityKey, defaults.UseTalkKey, defaults.SomeAbilityKey);
            _tempSettings.Set(defaults.JumpKey, defaults.ShiftKey, defaults.CrouchKey, defaults.SlideKey,
                    defaults.FirstAbilityKey, defaults.SecondAbilityKey, defaults.ThirdAbilityKey, defaults.FourthAbilityKey, defaults.UseTalkKey, defaults.SomeAbilityKey);
            Debug.Log($"Settings file status is {CreateSettingsFile()}");
            SaveSettings();
        }
        else
        {
            Debug.Log($"Settings file is loaded: {LoadSettings()}");
        }
    }

    private bool CheckSettingsFile() => File.Exists(_settingsFilePath);

    private bool CreateSettingsFile()
    {
        var file = File.Create(_settingsFilePath);
        file.Close();
        return File.Exists(_settingsFilePath);
    }

    public void SaveSettings()
    {
        JsonData<KeyBindSettings>.Save(_tempSettings, _settingsFilePath);
        _savedSettings.Set(_tempSettings);
        SettingsIsSaved.SetValue(true);
    }

    private bool LoadSettings()
    {
        var tempKeyBindSettings = JsonData<KeyBindSettings>.Load(_settingsFilePath);
        _savedSettings.Set(tempKeyBindSettings.JumpKey, tempKeyBindSettings.ShiftKey, tempKeyBindSettings.CrouchKey, tempKeyBindSettings.SlideKey,
            tempKeyBindSettings.FirstAbilityKey, tempKeyBindSettings.SecondAbilityKey, tempKeyBindSettings.ThirdAbilityKey, tempKeyBindSettings.FourthAbilityKey,
            tempKeyBindSettings.UseTalkKey, tempKeyBindSettings.SomeAbilityKey);
        return tempKeyBindSettings.IsEqual(_savedSettings);
    }

    public void Dispose()
    {
        DiscardSettings();
        SettingsIsSaved.Dispose();
        KeyBindSettings.Dispose();
        _tempSettings.Dispose();

        SettingsIsSaved = null;
    }

    public void DiscardSettings()
    {
        _tempSettings.Set(KeyBindSettings);
        SettingsIsSaved.SetValue(true);
    }

    public void SetKeyBind(KeyCode keyCode, Button button)
    {
        _tempSettings.SetField(button.name.Replace("Button", "Key"), keyCode);
        button.GetComponent<TMP_Text>().text = keyCode.ToString();
    }
}
