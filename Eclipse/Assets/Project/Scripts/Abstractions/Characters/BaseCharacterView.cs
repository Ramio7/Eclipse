using System;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(SpriteLibrary), typeof(SpriteResolver))]
public abstract class BaseCharacterView : MonoBehaviour, ICharacter, IView
{
    protected new Rigidbody2D rigidbody;
    protected new Collider2D collider;
    protected ReactiveProperty<CharacterEnviromentState> enviromentState;
    protected ReactiveProperty<CharacterAbilitiesState> abilitiesState;
    protected List<IAbility> abilities = new();

    [SerializeField] private CharacterEnviromentState _currentEnvState;
    [SerializeField] private CharacterAbilitiesState _currentAbState;
    private ContactsPoller _contactsPooler;

    public Rigidbody2D Rigidbody { get => rigidbody; private set => rigidbody = value; }
    public Collider2D Collider { get => collider; private set => collider = value; }
    public ReactiveProperty<CharacterEnviromentState> EnviromentState { get => enviromentState; private set => enviromentState = value; }
    public ReactiveProperty<CharacterAbilitiesState> AbilityState { get => abilitiesState; set => abilitiesState = value; }
    public List<IAbility> Abilities { get => abilities; private set => abilities = value; }
    public GameObject GameObject { get => gameObject; }

    public event Action<BaseCharacterView> BaseCharacterInitiated;

    private void Start()
    {
        GetComponentsFromMonoBehaviour();
        InitStates();

        _contactsPooler = new(collider, enviromentState);
        BaseCharacterInitiated.Invoke(this);
        
        enviromentState.OnValueChanged.AddListener(ChangeEnvValue);
        abilitiesState.OnValueChanged.AddListener(ChangeAbValue);
    }

    protected virtual void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 7) enviromentState.SetValue(CharacterEnviromentState.CanUseEnviroment);
    }

    private void OnDestroy()
    {
        enviromentState.OnValueChanged.RemoveListener(ChangeEnvValue);
        abilitiesState.OnValueChanged.RemoveListener(ChangeAbValue);

        enviromentState.Dispose();
        abilitiesState.Dispose();
        _contactsPooler.Dispose();
        abilities.Clear();

        _contactsPooler = null;
        enviromentState = null;
        abilitiesState = null;
        rigidbody = null;
        collider = null;
        abilities = null;
    }

    private void ChangeEnvValue(CharacterEnviromentState enviromentState)
    {
        _currentEnvState = enviromentState;
        if (_currentEnvState == CharacterEnviromentState.Grounded)
        {
            abilitiesState.SetValue(CharacterAbilitiesState.None);
            AbilityCash.ActiveAbility = null;
        }
    }

    private void ChangeAbValue(CharacterAbilitiesState abState) => _currentAbState = abState;

    private void GetComponentsFromMonoBehaviour()
    {
        collider = GetComponent<Collider2D>();
        rigidbody = GetComponent<Rigidbody2D>();
        var abilities = GetComponents<IAbilityView>();
        foreach (var ability in abilities) this.abilities.Add(ability.Ability);
    }

    private void InitStates()
    {
        enviromentState = new(CharacterEnviromentState.Grounded);
        abilitiesState = new(CharacterAbilitiesState.None);
    }
}
