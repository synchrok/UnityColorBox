
using UnityEditor;
using UnityEngine;

public class ColorBox : EditorWindow {
    private string _hexCode;
    private string _rValue;
    private string _gValue;
    private string _bValue;

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

        _hexCode = EditorGUILayout.TextField("Input Hex Color", _hexCode);

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("RGB");
        _rValue = EditorGUILayout.TextField(_rValue, GUILayout.ExpandWidth(true));
        _gValue = EditorGUILayout.TextField(_gValue, GUILayout.ExpandWidth(true));
        _bValue = EditorGUILayout.TextField(_bValue, GUILayout.ExpandWidth(true));
        EditorGUILayout.EndHorizontal();

        if (!string.IsNullOrEmpty(_hexCode)) {
            var hex = _hexCode;
            if (!hex.StartsWith("#"))
                hex = $"#{hex}";

            if (ColorUtility.TryParseHtmlString(hex, out var color)) {
                EditorGUILayout.ColorField("Color", color);
                EditorGUILayout.TextField("Result (Color)", $"new Color({color.r:0.###}f, {color.g:0.###}f, {color.b:0.###}f, {color.a:0.###}f)");
                EditorGUILayout.TextField("Result (Color32)",
                    $"new Color32({Mathf.RoundToInt(color.r * 255f)}, {Mathf.RoundToInt(color.g * 255f)}, {Mathf.RoundToInt(color.b * 255f)}, {Mathf.RoundToInt(color.a * 255f)})");
            }
        } else {
            if (int.TryParse(_rValue, out var r) && int.TryParse(_gValue, out var g) &&
                int.TryParse(_bValue, out var b)) {
                var color = new Color32((byte)r, (byte)g, (byte)b, 255);
                EditorGUILayout.ColorField("Color", color);
                var hex = ColorUtility.ToHtmlStringRGB(color);
                EditorGUILayout.TextField("Result (Hex)", hex);
            }
        }

        GUI.color = originColor;
    }
    
    
}
