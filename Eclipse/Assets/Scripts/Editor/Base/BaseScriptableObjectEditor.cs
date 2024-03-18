using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BaseScriptableObject)), CanEditMultipleObjects]
public class BaseScriptableObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var fillTheFieldsMethod = serializedObject.targetObject.GetType().GetMethod("FillTheFields");
        var methodParams = fillTheFieldsMethod.GetParameters();

        GUILayout.BeginVertical();
        var buttonLayoutOptions = new GUILayoutOption[]
        {
            GUILayout.Height(30),
            GUILayout.ExpandWidth(true),
        };
        if (GUILayout.Button("Fill the fields", buttonLayoutOptions)) fillTheFieldsMethod.Invoke(serializedObject.targetObject, methodParams);
        GUILayout.EndVertical();
    }
}
