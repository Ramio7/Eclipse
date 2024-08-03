using TMPro;
using UnityEngine;

public class LocationPanelView : BaseUIView, ILocationPanelView
{
    [SerializeField] private TMP_Text _locationName;

    public TMP_Text LocationName { get => _locationName; private set => _locationName = value; }
}
