using UnityEditor;
using UnityEngine;

namespace Application_Manager.Events.Editor {
    [CustomEditor(typeof(ApplicationEvent), editorForChildClasses: true)]
    public class EventEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            GUI.enabled = Application.isPlaying;

            ApplicationEvent e = target as ApplicationEvent;
            if (GUILayout.Button("Raise"))
                e.Raise();
        }
    }
}