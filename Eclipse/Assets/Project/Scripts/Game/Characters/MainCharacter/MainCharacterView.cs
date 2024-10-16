public class MainCharacterView : BaseCharacterView, IMortalCharacter
{
    private int _health = 0;
    public int Health { get => _health; private set => _health = value; }

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
