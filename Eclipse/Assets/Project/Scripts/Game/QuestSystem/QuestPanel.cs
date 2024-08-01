using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuestPanel : MonoBehaviour, IQuestPanel
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private TMP_Text _questInfo;
    [SerializeField] private Toggle _toggle;

    public void SetVisible(bool isVisible) => _canvas.enabled = isVisible;
    public void SetQuestInfo(string questInfo) => _questInfo.text = questInfo;
    public void SetCompleted(bool completed) => _toggle.isOn = completed;
}
