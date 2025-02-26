using System;
using UnityEngine;

public class ContactsPoller : IInitiable, IDisposable
{
    private const float _collisionThresh = 0.5f;
    private ContactPoint2D[] _contacts = new ContactPoint2D[10];
    private int _contactsCount;
    private Collider2D _collider2D;
    private ReactiveProperty<CharacterEnviromentState> _enviromentState;

    public ContactsPoller(Collider2D collider2D, ReactiveProperty<CharacterEnviromentState> enviromentState)
    {
        _collider2D = collider2D;
        _enviromentState = enviromentState;
        Init();
    }

    public void Init()
    {
        GameEvents.OnUpdate += OnUpdate;
    }

    public void Dispose()
    {
        GameEvents.OnUpdate -= OnUpdate;
        _collider2D = null;
        _enviromentState = null;
    }

    private void OnUpdate()
    {
        _contactsCount = _collider2D.GetContacts(_contacts);

        if (_contactsCount == 0) 
            _enviromentState.SetValue(CharacterEnviromentState.InAir);

        for (int i = 0; i < _contactsCount; i++)
        {
            var normal = _contacts[i].normal;
            var rigidBody = _contacts[i].rigidbody;
            if (normal.y > _collisionThresh) _enviromentState.SetValue(CharacterEnviromentState.Grounded);
            if (normal.y < -_collisionThresh) _enviromentState.SetValue(CharacterEnviromentState.UpperContact);
            if (normal.x > _collisionThresh && rigidBody == null)
                _enviromentState.SetValue(CharacterEnviromentState.LeftContact);
            if (normal.x < -_collisionThresh && rigidBody == null)
                _enviromentState.SetValue(CharacterEnviromentState.RightContact);
        }
    }
}
