using System.IO;
using UnityEngine;

public class KeyboardKeyBindSettingsModel : BaseModel
{
    private KeyBindSettings _savedSettings = new();
    private KeyBindSettings _tempSettings = new();

    private string _settingsFilePath = Application.dataPath + "/Project/Resources/KeyBindSettings.json";

    public ReactiveProperty<bool> settingsIsSaved = new(true);

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

        if (settingsIsSaved.GetValue() != true) DiscardSettings();
        settingsIsSaved?.Dispose();
        _savedSettings.Dispose();
        _tempSettings.Dispose();

        settingsIsSaved = null;
    }

    private void InitKeyBindSettings()
    {
        _savedSettings.Init();
        _tempSettings.Init();

        if (!CheckSettingsFile())
        {
            CreateSettingsFile();
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
        settingsIsSaved.SetValue(false);

        JsonData<KeyCode[][]>.Save(_tempSettings.keyCodes, _settingsFilePath);
        _savedSettings.SetFromSettings(_tempSettings);

        settingsIsSaved.SetValue(_savedSettings.IsEqual(_tempSettings));
    }

    public bool LoadSettings()
    {
        settingsIsSaved.SetValue(false);

        var tempKeyBindSettings = JsonData<KeyCode[][]>.Load(_settingsFilePath);

        if (tempKeyBindSettings != null)
        {
            _savedSettings.keyCodes = tempKeyBindSettings;
            _tempSettings.keyCodes = tempKeyBindSettings;
            settingsIsSaved.SetValue(tempKeyBindSettings == _savedSettings.keyCodes);
        }

        return settingsIsSaved.GetValue();
    }

    public void DiscardSettings()
    {
        _tempSettings.SetFromSettings(_savedSettings);
        settingsIsSaved.SetValue(true);
    }

    public void SetKeyBind(KeyCode[] keyCode, IAbility ability)
    {
        _tempSettings.SetAbility(ability, keyCode);
        settingsIsSaved.SetValue(false);
    }
}
