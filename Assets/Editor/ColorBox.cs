
using UnityEditor;
using UnityEngine;

public class ColorBox : EditorWindow {
    private string _hexCode;

    [MenuItem("Window/ColorBox")]
    static void Open() {
        GetWindow<ColorBox>();
    }

    private void OnGUI() {
        var originColor = GUI.color;
        
        GUI.color = EditorGUIUtility.isProSkin? Color.white : Color.black;

        EditorGUILayout.Space();
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("ColorBox", new GUIStyle {
            fontSize = 40,
            padding = new RectOffset(10, 0, 0, 0),
            normal = new GUIStyleState {
                textColor = Color.white
            }
        });

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        EditorGUILayout.LabelField("Color hex code to C# color class code", new GUIStyle {
            fontSize = 16,
            padding = new RectOffset(10, 0, 0, 0),
            normal = new GUIStyleState {
                textColor = Color.white
            }
        });

        GUI.color = Color.white;

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();

        _hexCode = EditorGUILayout.TextField("Input Hex Color", _hexCode, new GUILayoutOption[]{});

        if(_hexCode != null){
            var hex = _hexCode;
            if (!hex.StartsWith("#"))
                hex = $"#{hex}";

            if (ColorUtility.TryParseHtmlString(hex, out var color)) {
                EditorGUILayout.ColorField("Color", color);
                EditorGUILayout.TextField("Result (Color)", $"new Color({color.r:0.###}f, {color.g:0.###}f, {color.b:0.###}f, {color.a:0.###}f)", new GUILayoutOption[]{});
                EditorGUILayout.TextField("Result (Color32)",
                    $"new Color32({Mathf.RoundToInt(color.r * 255f)}, {Mathf.RoundToInt(color.g * 255f)}, {Mathf.RoundToInt(color.b * 255f)}, {Mathf.RoundToInt(color.a * 255f)})",
                    new GUILayoutOption[] { });
            }
        }

        GUI.color = originColor;
    }
    
    
}
