﻿using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

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
            //新增窗口项 NewWindowTabs
            typeof(TestButton),
            assembly.GetType("UnityEditor.ConsoleWindow"),
            //默认窗口项 DefaultWindowTabs
            typeof(SceneView),
            assembly.GetType("UnityEditor.GameView"),
            assembly.GetType("UnityEditor.InspectorWindow"),
            assembly.GetType("UnityEditor.SceneHierarchyWindow"),
            assembly.GetType("UnityEditor.ProjectBrowser"),
            assembly.GetType("UnityEditor.ProfilerWindow"),
            assembly.GetType("UnityEditor.AnimationWindow"),
        });
    }
}
public class TestButton : EditorWindow
{
    void CreateGUI()
    {
        //关闭窗口以实现按钮功能 Close window for button functionality
        Debug.Log("CustomAddTab");
        this.Close();
    }
}