using UnityEngine.UI;

public class MainMenuModel : BaseScriptableObjectOrientedModel
{
    public MainMenuModel(MainMenuScriptableObject data) : base(data)
    {
        
    }

    public override void Init(IScriptableObject modelData)
    {
        
    }

    public override void Dispose()
    {
        base.Dispose();
    }

    public void SwitchActiveButton(Button buttonToActivate, Button buttonToDisable)
    {
        buttonToActivate.gameObject.SetActive(true);
        buttonToDisable.gameObject.SetActive(false);
    }
}
