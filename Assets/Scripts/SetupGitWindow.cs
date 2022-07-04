using UnityEditor;
using UnityEngine;

public class SetupGitWindow : EditorWindow {
    private static EditorWindow _editorWindow;
    private string _repoURl = "";
    private string _branch = "";
    private string _username = "";
    private string _password = "";

    [MenuItem("/Git/Open")]
    public static void ShowWindow() {
        if (_editorWindow != null) _editorWindow.Close();
        _editorWindow = GetWindow(typeof(SetupGitWindow));
        _editorWindow.titleContent = new GUIContent("Git");
    }

    private void OnGUI() {
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Repository URL");
        _repoURl = GUILayout.TextField(_repoURl);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Username");
        _username = GUILayout.TextField(_username);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Password");
        _password = GUILayout.TextField(_password);
        EditorGUILayout.EndHorizontal();
        if (GUILayout.Button("Setup Git")) {
            GitManager.Setup(_repoURl, _username, _password);
        }
    }
}