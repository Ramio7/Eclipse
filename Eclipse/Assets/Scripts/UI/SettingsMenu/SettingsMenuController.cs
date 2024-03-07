public class SettingsMenuController : BaseController
{
    private new SettingsMenuView _view;
    private new SettingsMenuModel _model;

    public SettingsMenuController(SettingsMenuView view, SettingsMenuScriptableObject settingsDefaults) : base(view)
    {
        _view = view;
        _model = new(settingsDefaults);
        Init();
    }

    public override void Init()
    {
        base.Init();
    }

    public override void Dispose()
    {
        base.Dispose();

        _model.Dispose();

        _view = null;
        _model = null;
    }
}
