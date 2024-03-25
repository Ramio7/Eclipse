using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/" + nameof(GameScriptableObject), fileName = nameof(GameScriptableObject))]
public class GameScriptableObject : BaseScriptableObject
{
    public GameView GameObjectPrefab {  get; private set; }
}
