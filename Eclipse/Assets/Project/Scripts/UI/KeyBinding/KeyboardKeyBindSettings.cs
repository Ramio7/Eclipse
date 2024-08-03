using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public struct KeyboardKeyBindSettings : IStruct
{
    public KeyCode JumpKey;
    public KeyCode ShiftKey;
    public KeyCode CrouchKey;
    public KeyCode SlideKey;
    public KeyCode FirstAbilityKey;
    public KeyCode SecondAbilityKey;
    public KeyCode ThirdAbilityKey;
    public KeyCode FourthAbilityKey;
    public KeyCode UseTalkKey;
    public KeyCode SomeAbilityKey;

    public Dictionary<string, KeyCode> Keys;

    public void Set(KeyCode jumpKey, KeyCode shiftKey, KeyCode crouchKey, KeyCode slideKey,
        KeyCode firstAbilityKey, KeyCode secondAbilityKey, KeyCode thirdAbilityKey, KeyCode fourthAbilityKey, KeyCode useTalkKey, KeyCode someAbilityKey)
    {
        JumpKey = jumpKey;
        ShiftKey = shiftKey;
        CrouchKey = crouchKey;
        SlideKey = slideKey;
        FirstAbilityKey = firstAbilityKey;
        SecondAbilityKey = secondAbilityKey;
        ThirdAbilityKey = thirdAbilityKey;
        FourthAbilityKey = fourthAbilityKey;
        UseTalkKey = useTalkKey;
        SomeAbilityKey = someAbilityKey;
        FillKeyList();
    }

    public void Set(KeyboardKeyBindSettings settings)
    {
        JumpKey = settings.JumpKey;
        ShiftKey = settings.ShiftKey;
        CrouchKey = settings.CrouchKey;
        SlideKey = settings.SlideKey;
        FirstAbilityKey = settings.FirstAbilityKey;
        SecondAbilityKey = settings.SecondAbilityKey;
        ThirdAbilityKey = settings.ThirdAbilityKey;
        FourthAbilityKey = settings.FourthAbilityKey;
        UseTalkKey = settings.UseTalkKey;
        SomeAbilityKey = settings.SomeAbilityKey;
        FillKeyList();
    }

    private void FillKeyList()
    {
        Keys ??= new(10);
        Keys?.Clear();
        var fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
        for (var i = 0; i < fields.Length - 1; i++)
        {
            var field = fields[i];
            var fieldName = field.Name;
            KeyCode fieldValue = KeyCode.None;
            switch (i)
            {
                case 0:
                    fieldValue = JumpKey;
                    break;
                case 1:
                    fieldValue = ShiftKey;
                    break;
                case 2:
                    fieldValue = CrouchKey;
                    break;
                case 3:
                    fieldValue = SlideKey;
                    break;
                case 4:
                    fieldValue = FirstAbilityKey;
                    break;
                case 5:
                    fieldValue = SecondAbilityKey;
                    break;
                case 6:
                    fieldValue = ThirdAbilityKey;
                    break;
                case 7:
                    fieldValue = FourthAbilityKey;
                    break;
                case 8:
                    fieldValue = UseTalkKey;
                    break;
                case 9:
                    fieldValue = SomeAbilityKey;
                    break;
                default:
                    Debug.LogWarning("Unsuspected value");
                    break;
            }
            Keys.Add(fieldName, fieldValue);
        }
    }

    public void Dispose()
    {
        JumpKey = KeyCode.None;
        ShiftKey = KeyCode.None;
        CrouchKey = KeyCode.None;
        SlideKey = KeyCode.None;
        FirstAbilityKey = KeyCode.None;
        SecondAbilityKey = KeyCode.None;
        ThirdAbilityKey = KeyCode.None;
        FourthAbilityKey = KeyCode.None;
        UseTalkKey = KeyCode.None;
        SomeAbilityKey = KeyCode.None;
    }

    public readonly bool IsEqual(KeyboardKeyBindSettings other)
    {
        return other.JumpKey == JumpKey && other.ShiftKey == ShiftKey
            && other.CrouchKey == CrouchKey && other.SlideKey == SlideKey
            && other.FirstAbilityKey == FirstAbilityKey && other.SecondAbilityKey == SecondAbilityKey
            && other.ThirdAbilityKey == ThirdAbilityKey && other.FourthAbilityKey == FourthAbilityKey
            && other.UseTalkKey == UseTalkKey && other.SomeAbilityKey == SomeAbilityKey;
    }

    public void SetField(string keyName, KeyCode keyCode)
    {
        Keys[keyName] = keyCode;

        var fields = GetType().GetFields(BindingFlags.Instance | BindingFlags.Public);
        for (var i = 0; i < fields.Length - 1; i++)
        {
            var field = fields[i];
            var fieldName = field.Name;
            if (fieldName == keyName)
            {
                switch (i)
                {
                    case 0:
                        JumpKey = keyCode;
                        break;
                    case 1:
                        ShiftKey = keyCode;
                        break;
                    case 2:
                        CrouchKey = keyCode;
                        break;
                    case 3:
                        SlideKey = keyCode;
                        break;
                    case 4:
                        FirstAbilityKey = keyCode;
                        break;
                    case 5:
                        SecondAbilityKey = keyCode;
                        break;
                    case 6:
                        ThirdAbilityKey = keyCode;
                        break;
                    case 7:
                        FourthAbilityKey = keyCode;
                        break;
                    case 8:
                        UseTalkKey = keyCode;
                        break;
                    case 9:
                        SomeAbilityKey = keyCode;
                        break;
                    default:
                        Debug.LogWarning("Unsuspected value");
                        break;
                }
                return;
            }
        }
    }

    public FieldInfo GetKeyField(string keyName) => GetType().GetField(keyName);
}
