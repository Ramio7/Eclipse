using UnityEngine;

public class GameModel : BaseScriptableObjectOrientedModel
{
    private GameObject _girlPrefab;
    private GameOverlayView _overlayView;

    public GameObject GirlPrefab { get => _girlPrefab; }
    public GameOverlayView OverlayView { get => _overlayView; }

    public GameModel(IScriptableObject gameData) : base(gameData)
    {
        Init(gameData);
    }

    public override void Init(IScriptableObject modelData)
    {
        base.Init(modelData);
        var tempGameData = modelData as GameScriptableObject;
        _girlPrefab = tempGameData.GirlPrefab;
        _overlayView = tempGameData.OverlayView;
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
