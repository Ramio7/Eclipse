using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameObjectController : IController
{
    void Init(IScriptableObject data, IView view);
}
