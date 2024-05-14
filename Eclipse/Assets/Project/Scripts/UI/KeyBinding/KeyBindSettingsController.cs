public class KeyBindSettingsController : BaseController
{
    private new KeyBindSettingsModel _model;
    private new KeyBindSettingsView _view;

    public KeyBindSettingsController(KeyBindSettingsView view, KeyBindSettingsScriptableObject defaults) : base(view)
    {
        _view = view;
        _model = new(defaults, _view.Canvas);
    }

    public override void Init()
    {

    }

    public override void Dispose()
    {
        _model.Dispose();

        _view = null;
        _model = null;
    }
}
