using System.IO;
using UnityEngine;

public class KeyboardKeyBindSettingsModel : BaseScriptableObjectOrientedModel
{
    private KeyBindSettings _savedSettings = new();
    private KeyBindSettings _tempSettings = new();

    private string _settingsFilePath = Application.dataPath + "/Project/Resources/KeyBindSettings.json";

    public ReactiveProperty<bool> SettingsIsSaved = new(true);
    public KeyBindSettings KeyBindSettings { get => _savedSettings; private set => _savedSettings = value; }
    public KeyBindSettings TempSettings { get => _tempSettings; private set => _tempSettings = value; }

    public KeyboardKeyBindSettingsModel(IScriptableObject defaultSettings) : base(defaultSettings)
    {
        Init(defaultSettings);
    }

    public override void Init(IScriptableObject modelData)
    {
        var defaults = modelData as KeyboardKeyBindSettingsScriptableObject;
        InitKeyBindSettings(defaults);
    }

    public override void Dispose()
    {
        base.Dispose();
        if (SettingsIsSaved.GetValue() != true) DiscardSettings();
        SettingsIsSaved?.Dispose();
        _savedSettings.Dispose();
        _tempSettings.Dispose();

        SettingsIsSaved = null;
    }

    private void InitKeyBindSettings(KeyboardKeyBindSettingsScriptableObject defaults)
    {
        _savedSettings.Init();
        _tempSettings.Init();

        KeyBindSettings.SetFromScriptable(defaults);

        Debug.Log(KeyBindSettings.ToString());
        /*if (!CheckSettingsFile())
        {
            KeyBindSettings.Set(defaults.JumpKey, defaults.ShiftKey, defaults.CrouchKey, defaults.SlideKey,
                defaults.FirstAbilityKey, defaults.SecondAbilityKey, defaults.ThirdAbilityKey, defaults.FourthAbilityKey, defaults.UseTalkKey, defaults.MoveAbilityKey);
            TempSettings.Set(defaults.JumpKey, defaults.ShiftKey, defaults.CrouchKey, defaults.SlideKey,
                    defaults.FirstAbilityKey, defaults.SecondAbilityKey, defaults.ThirdAbilityKey, defaults.FourthAbilityKey, defaults.UseTalkKey, defaults.MoveAbilityKey);
            CreateSettingsFile();
            SaveSettings();
        }
        else
        {
            LoadSettings();
        }*/
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
        /*JsonData<KeyBindSettings>.Save(TempSettings, _settingsFilePath);
        KeyBindSettings.Set(TempSettings);
        SettingsIsSaved.SetValue(true);*/
    }

    private bool LoadSettings()
    {
        /*var tempKeyBindSettings = JsonData<KeyBindSettings>.Load(_settingsFilePath);
        KeyBindSettings.Set(tempKeyBindSettings.JumpKey, tempKeyBindSettings.ShiftKey, tempKeyBindSettings.CrouchKey, tempKeyBindSettings.SlideKey,
            tempKeyBindSettings.FirstAbilityKey, tempKeyBindSettings.SecondAbilityKey, tempKeyBindSettings.ThirdAbilityKey, tempKeyBindSettings.FourthAbilityKey,
            tempKeyBindSettings.UseTalkKey, tempKeyBindSettings.MoveAbilityKey);
        TempSettings.Set(tempKeyBindSettings.JumpKey, tempKeyBindSettings.ShiftKey, tempKeyBindSettings.CrouchKey, tempKeyBindSettings.SlideKey,
            tempKeyBindSettings.FirstAbilityKey, tempKeyBindSettings.SecondAbilityKey, tempKeyBindSettings.ThirdAbilityKey, tempKeyBindSettings.FourthAbilityKey,
            tempKeyBindSettings.UseTalkKey, tempKeyBindSettings.MoveAbilityKey);
        return tempKeyBindSettings.IsEqual(_savedSettings);*/
        return true;
    }

    public void DiscardSettings()
    {
        /*TempSettings.Set(KeyBindSettings);
        SettingsIsSaved.SetValue(true);*/
    }

    public void SetKeyBind(KeyCode[] keyCode, IAbility ability) => _tempSettings.SetAbility(ability, keyCode);
}
