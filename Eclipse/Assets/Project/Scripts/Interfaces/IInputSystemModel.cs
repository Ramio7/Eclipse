using System.Collections.Generic;
using UnityEngine;

public interface IInputSystemModel : IModel
{
    Dictionary<KeyCode, IAbility> KeysMethodsPairs {  get; }
}
