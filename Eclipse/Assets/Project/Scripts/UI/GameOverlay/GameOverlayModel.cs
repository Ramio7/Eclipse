using UnityEngine;

public class GameOverlayModel : BaseUIModel
{
    public GameOverlayModel(IScriptableObject gameData, Canvas canvas) : base(gameData, canvas)
    {
        Init(gameData, canvas);
    }

    protected override void Init(IScriptableObject modelData, Canvas canvas)
    {
        throw new System.NotImplementedException();
    }

    protected override void Init(IScriptableObject modelData)
    {
        throw new System.NotImplementedException();
    }
}
