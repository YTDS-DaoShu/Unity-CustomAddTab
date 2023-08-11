using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

[InitializeOnLoad]
public class CustomAddTab
{
    static CustomAddTab()
    {
        Assembly assembly = Assembly.GetAssembly(typeof(Editor));
        Type hostView = assembly.GetType("UnityEditor.HostView");
        FieldInfo k_PaneTypes = hostView.GetField("k_PaneTypes", BindingFlags.Static | BindingFlags.NonPublic);

        k_PaneTypes.SetValue(null, new Type[]
        {
            typeof(SceneView),
            typeof(TestWindow),
            //assembly.GetType("UnityEditor.GameView"),
            //assembly.GetType("UnityEditor.InspectorWindow"),
            //assembly.GetType("UnityEditor.SceneHierarchyWindow"),
            //assembly.GetType("UnityEditor.ProjectBrowser"),
            //assembly.GetType("UnityEditor.ProfilerWindow"),
            //assembly.GetType("UnityEditor.AnimationWindow"),
        });
    }
    public class TestWindow : EditorWindow
    {
        public void Awake()
        {
            Debug.Log("CustomAddTab");
        }
    }
}