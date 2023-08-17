using RedPanda.Project.UI.Common;
using UnityEditor;
using UnityEditor.UI;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace RedPanda.Project.Editor
{
    [CustomEditor(typeof(CustomButton))]
    public class CustomButtonEditor : ButtonEditor
    {
        private SerializedProperty m_InteractableProperty;
    
        protected override void OnEnable()
        {
            m_InteractableProperty = serializedObject.FindProperty("m_Interactable");
        }
    
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();
    
            var duration = new PropertyField(serializedObject.FindProperty(CustomButton.Duration));
    
            root.Add(new IMGUIContainer(OnInspectorGUI));
            root.Add(duration);
    
            return root;
        }
    
        public override void OnInspectorGUI()
        {
            serializedObject.Update();
    
            EditorGUILayout.PropertyField(m_InteractableProperty);
    
            serializedObject.ApplyModifiedProperties();
        }
    }
}
