public interface IDamager
{
    public int Damage { get; }
    public void DoDamage(IMortalCharacter target);
}
