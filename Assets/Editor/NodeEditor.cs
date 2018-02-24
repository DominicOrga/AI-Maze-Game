using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(Node))]
public class NodeEditor : PropertyDrawer {

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
        EditorGUI.BeginProperty(position, label, property);

        label.text = label.text.Substring(8);

        EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        position.x += 25;
        EditorGUI.LabelField(position, new GUIContent("Row"));

        position.x += 35;
        Rect rowRect = new Rect(position.x, position.y, 50, position.height);
        property.FindPropertyRelative("row").intValue = EditorGUI.IntField(rowRect, property.FindPropertyRelative("row").intValue);

        position.x += 55;
        EditorGUI.LabelField(position, new GUIContent("Col"));

        position.x += 35;
        Rect colRect = new Rect(position.x, position.y, 50, position.height);
        property.FindPropertyRelative("col").intValue = EditorGUI.IntField(colRect, property.FindPropertyRelative("col").intValue);

        position.x += 55;
        EditorGUI.LabelField(position, new GUIContent("S"));

        position.x += 15;
        Rect sRect = new Rect(position.x, position.y, 25, position.height);
        EditorGUI.PropertyField(sRect, property.FindPropertyRelative("isStartNode"), GUIContent.none);

        position.x += 30;
        EditorGUI.LabelField(position, new GUIContent("G"));

        position.x += 15;
        Rect gRect = new Rect(position.x, position.y, 25, position.height);
        EditorGUI.PropertyField(gRect, property.FindPropertyRelative("isGoalNode"), GUIContent.none);

        EditorGUI.EndProperty();
    }
}
