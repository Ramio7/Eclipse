using UnityEngine;

public interface IInputSystemModel : IModel
{
    void GetKey(KeyCode keyCode);
    void GetAxis(float horizontalAxisValue, float verticalAxisValue);
}
