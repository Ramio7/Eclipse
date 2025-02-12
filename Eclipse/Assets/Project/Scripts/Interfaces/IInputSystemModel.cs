using UnityEngine;

public interface IInputSystemModel : IModel
{
    void SetKey(KeyCode keyCode);
    void SetAxis(float horizontalAxisValue, float verticalAxisValue);
}
