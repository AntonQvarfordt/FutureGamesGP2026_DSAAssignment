using Environment;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(Computer))]
public class ComputerEditor : Editor
{
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
    }
    //public override VisualElement CreateInspectorGUI() {
    //    // Create a new VisualElement to be the root of our Inspector UI.
    //    VisualElement myInspector = new VisualElement();

    //    // Add a simple label.
    //    myInspector.Add(new Label("This is a custom Inspector"));

    //    // Return the finished Inspector UI.
    //    return myInspector;
    //}
}
