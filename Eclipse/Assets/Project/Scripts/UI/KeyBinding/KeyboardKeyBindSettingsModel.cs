using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class KeyboardKeyBindSettingsModel : BaseModel
{
    private KeyboardKeyBindSettings _savedSettings = new();
    private KeyboardKeyBindSettings _tempSettings = new();

    private KeyCode _keyCodeFromInput;
    private Button _selectedButton;
    private event System.Action<KeyCode, Button> _onInput;

    private string _settingsFilePath = Application.dataPath + "/Project/Resources/KeyboardKeyBindSettings.json";

    public ReactiveProperty<bool> SettingsIsSaved = new(true);
    public KeyboardKeyBindSettings KeyBindSettings { get => _savedSettings; }

    public KeyboardKeyBindSettingsModel(IScriptableObject defaultSettings) : base()
    {
        Init(defaultSettings);
    }

    protected void Init(IScriptableObject modelData)
    {
        var defaults = modelData as KeyboardKeyBindSettingsScriptableObject;
        InitKeyBindSettings(defaults);
    }

    public override void Dispose()
    {
        DiscardSettings();
        SettingsIsSaved.Dispose();
        KeyBindSettings.Dispose();
        _tempSettings.Dispose();

        SettingsIsSaved = null;
    }

    private void InitKeyBindSettings(KeyboardKeyBindSettingsScriptableObject defaults)
    {
        if (!CheckSettingsFile())
        {
            _savedSettings.Set(defaults.JumpKey, defaults.ShiftKey, defaults.CrouchKey, defaults.SlideKey,
                defaults.FirstAbilityKey, defaults.SecondAbilityKey, defaults.ThirdAbilityKey, defaults.FourthAbilityKey, defaults.UseTalkKey, defaults.SomeAbilityKey);
            _tempSettings.Set(defaults.JumpKey, defaults.ShiftKey, defaults.CrouchKey, defaults.SlideKey,
                    defaults.FirstAbilityKey, defaults.SecondAbilityKey, defaults.ThirdAbilityKey, defaults.FourthAbilityKey, defaults.UseTalkKey, defaults.SomeAbilityKey);
            CreateSettingsFile();
            SaveSettings();
        }
        else
        {
            LoadSettings();
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
        JsonData<KeyboardKeyBindSettings>.Save(_tempSettings, _settingsFilePath);
        _savedSettings.Set(_tempSettings);
        SettingsIsSaved.SetValue(true);
    }

    private bool LoadSettings()
    {
        var tempKeyBindSettings = JsonData<KeyboardKeyBindSettings>.Load(_settingsFilePath);
        _savedSettings.Set(tempKeyBindSettings.JumpKey, tempKeyBindSettings.ShiftKey, tempKeyBindSettings.CrouchKey, tempKeyBindSettings.SlideKey,
            tempKeyBindSettings.FirstAbilityKey, tempKeyBindSettings.SecondAbilityKey, tempKeyBindSettings.ThirdAbilityKey, tempKeyBindSettings.FourthAbilityKey,
            tempKeyBindSettings.UseTalkKey, tempKeyBindSettings.SomeAbilityKey);
        _tempSettings.Set(tempKeyBindSettings.JumpKey, tempKeyBindSettings.ShiftKey, tempKeyBindSettings.CrouchKey, tempKeyBindSettings.SlideKey,
            tempKeyBindSettings.FirstAbilityKey, tempKeyBindSettings.SecondAbilityKey, tempKeyBindSettings.ThirdAbilityKey, tempKeyBindSettings.FourthAbilityKey,
            tempKeyBindSettings.UseTalkKey, tempKeyBindSettings.SomeAbilityKey);
        return tempKeyBindSettings.IsEqual(_savedSettings);
    }

    public void DiscardSettings()
    {
        _tempSettings.Set(KeyBindSettings);
        SettingsIsSaved.SetValue(true);
    }

    public void InitKeyBindProcess(Button button)
    {
        _selectedButton = button;

        _onInput += SetKeyBind;

        EntryPointView.OnGuiUpdate += AwaitKeyInput;
    }

    private void AwaitKeyInput()
    {
        if (Event.current.type != EventType.KeyUp) return;
        else _keyCodeFromInput = Event.current.keyCode;

        EntryPointView.OnGuiUpdate -= AwaitKeyInput;

        _onInput?.Invoke(_keyCodeFromInput, _selectedButton);
        _onInput -= SetKeyBind;
    }

    private void SetKeyBind(KeyCode keyCode, Button button)
    {
        _tempSettings.SetField(button.name.Replace("Button", "Key"), keyCode);
        var tmp_text = button.GetComponentInChildren<TMP_Text>();
        if (tmp_text != null) tmp_text.text = keyCode.ToString();
        else throw new("No text component found");
    }
}
