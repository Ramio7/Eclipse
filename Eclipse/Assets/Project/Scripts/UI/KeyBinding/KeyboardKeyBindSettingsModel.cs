using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class KeyboardKeyBindSettingsModel : BaseModel
{
    private KeyBindSettings _savedSettings = new();
    private KeyBindSettings _tempSettings = new();
    private ReactiveProperty<bool> _settingsIsSaved = new(true);

    private string _settingsFilePath = Application.dataPath + "/Project/Resources/KeyBindSettings.json";
    
    public KeyBindSettings KeyBindSettings { get => _savedSettings; private set => _savedSettings = value; }
    public KeyBindSettings TempSettings { get => _tempSettings; private set => _tempSettings = value; }

    public KeyboardKeyBindSettingsModel() : base()
    {
        Init();
    }

    protected new void Init()
    {
        InitKeyBindSettings();
    }

    public override void Dispose()
    {
        base.Dispose();

        if (_settingsIsSaved.GetValue() != true) DiscardSettings();
        _settingsIsSaved?.Dispose();
        _savedSettings.Dispose();
        _tempSettings.Dispose();

        _settingsIsSaved = null;
    }

    private void InitKeyBindSettings()
    {
        _savedSettings.Init();
        _tempSettings.Init();

        if (!CheckSettingsFile())
        {
            CreateSettingsFile();
        }
        else LoadSettings();
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
        JsonDictionaryData<Dictionary<IAbility, KeyCode[]>, IAbility, KeyCode[]>.Save(_tempSettings.AbilityKyes, _settingsFilePath);
        _savedSettings.SetFromSettings(_tempSettings);
        _settingsIsSaved.SetValue(true);
    }

    private bool LoadSettings()
    {
        var tempKeyBindSettings = JsonDictionaryData<Dictionary<IAbility, KeyCode[]>, IAbility, KeyCode[]>.Load(_settingsFilePath);

        if (tempKeyBindSettings != null)
        {
            _savedSettings.SetDictionary(tempKeyBindSettings);
            _tempSettings.SetDictionary(tempKeyBindSettings);
            return tempKeyBindSettings == _savedSettings.AbilityKyes;
        }
        else throw new System.ArgumentNullException(nameof(tempKeyBindSettings));
    }

    public void DiscardSettings()
    {
        _tempSettings.SetFromSettings(_savedSettings);
        _settingsIsSaved.SetValue(true);
    }

    public void SetKeyBind(KeyCode[] keyCode, IAbility ability)
    {
        _tempSettings.SetAbility(ability, keyCode);
        _settingsIsSaved.SetValue(false);
    }
}
