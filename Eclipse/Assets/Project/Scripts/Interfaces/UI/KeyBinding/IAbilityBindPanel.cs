using TMPro;
using UnityEngine;
using UnityEngine.UI;

public interface IAbilityBindPanel : IUIView
{
    Button AbilityButton { get; }
    TMP_Text AbilityName { get; }
    KeyCode AbilityKey { get; set; }
}
