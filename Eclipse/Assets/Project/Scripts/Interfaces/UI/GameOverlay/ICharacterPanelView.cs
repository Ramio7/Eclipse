using TMPro;
using UnityEngine.UI;

public interface ICharacterPanelView : IUIView
{
    Image CharacterIcon { get; }
    Slider HPSlider { get; }
    Slider MPSlider { get; }
    TMP_Text CharacterName {  get; }
}
