using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Tester : MonoBehaviour
{
    [MenuItem("Support/Run Test")]
    public static void RunTest()
    {
        EditorBuildSettingsScene[] scenesAdded = EditorBuildSettings.scenes;
        if (scenesAdded.Length == 0)
            Debug.Log("No scenes added to build settings");
        else
            Debug.Log(($"Scenes added to build settings: {scenesAdded.Length}"));
        RunnerApiCalls.SwitchPlatform();
        RunnerApiCalls.RunTests();
    }
}
