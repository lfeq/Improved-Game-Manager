using System;
using System.Collections.Generic;
using System.IO;
using Application_Manager.Events;
using Application_Manager.Improved_Game_Manager.Runtime.Editor;
using Application_Manager.States;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CreateStateWindow : EditorWindow {
    [SerializeField] private VisualTreeAsset m_VisualTreeAsset = default;

    private TextField m_textField;
    private TextField m_pathField;
    private PopupField<Type> m_popupField;

    [MenuItem("Window/Application Manager/Create State")]
    public static void ShowExample() {
        CreateStateWindow wnd = GetWindow<CreateStateWindow>();
        wnd.titleContent = new GUIContent("Create State Window");
    }

    public void CreateGUI() {
        // Each editor window contains a root VisualElement object
        VisualElement root = rootVisualElement;

        // VisualElements objects can contain other VisualElement following a tree hierarchy.
        VisualElement label = new Label("Create a new state");
        root.Add(label);

        // // Get the list of concrete BaseState names.
        // List<string> stateOptions = ReflectionHelper.GetConcreteStateNames();
        //
        // var dropdown = new DropdownField("State Type", stateOptions, 0);
        // root.Add(dropdown);
        List<Type> stateTypes = ReflectionHelper.GetConcreteStates();
        m_popupField = new PopupField<Type>("State Type", stateTypes, stateTypes[0],
            t => t.Name, t => t.Name);
        root.Add(m_popupField);
        m_textField = new TextField("State Name") {
            textEdition = {
                placeholder = "Enter state name",
                hidePlaceholderOnFocus = true
            },
            multiline = true,
            maxLength = 50
        };
        root.Add(m_textField);
        m_pathField = new TextField("Path") {
            textEdition = {
                placeholder = "Assets/Data/Application States",
                hidePlaceholderOnFocus = true
            },
            multiline = true,
            maxLength = 50
        };
        root.Add(m_pathField);
        var createButton = new Button();
        createButton.RegisterCallback<ClickEvent>(CreateState);
        createButton.text = "Create";
        root.Add(createButton);

        // Instantiate UXML
        VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
        root.Add(labelFromUXML);
    }

    private void CreateState(ClickEvent t_clickEvent) {
        // Path to create new states
        string path;
        path = string.IsNullOrEmpty(m_pathField.value) ? "Assets/Data/Application States" : m_pathField.value;
        if (!Directory.Exists(path)) {
            Directory.CreateDirectory(path);
            AssetDatabase.Refresh();
        }

        // Create State, Event, and Event Listener
        var newApplicationEvent = CreateInstance<ApplicationEvent>();
        var newApplicationEventListener = CreateInstance<ApplicationEventListener>();
        var newStateSO = CreateInstance(m_popupField.value);
        newApplicationEventListener.Event = newApplicationEvent;
        var newState = newStateSO as BaseState;
        if (newState != null) {
            newState.eventListener = newApplicationEventListener;
            newState.stateName = m_textField.value;
        }

        // Create States as Assets
        if (!Directory.Exists($"{path}/Application Events")) {
            Directory.CreateDirectory($"{path}/Application Events");
        }
        if (!Directory.Exists($"{path}/Application Event Listeners")) {
            Directory.CreateDirectory($"{path}/Application Event Listeners");
        }
        if (!Directory.Exists($"{path}/Application States")) {
            Directory.CreateDirectory($"{path}/Application States");
        }
        AssetDatabase.CreateAsset(newApplicationEvent,
            $"{path}/Application Events/Change To {m_textField.value} State Event.asset");
        AssetDatabase.CreateAsset(newApplicationEventListener,
            $"{path}/Application Event Listeners/On Change to {m_textField.value} State.asset");
        AssetDatabase.CreateAsset(newStateSO, $"{path}/Application States/{m_textField.value} State.asset");
        AssetDatabase.SaveAssets();
        Debug.LogWarning(
            $"remember to assign the state to transition to in the On Change to {m_textField.value} State inspector.");
    }
}