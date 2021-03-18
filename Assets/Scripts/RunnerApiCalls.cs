using UnityEditor;
using UnityEditor.TestTools.TestRunner.Api;
using UnityEngine;

public class RunnerApiCalls : ScriptableObject
{
    public static void RunTests()
    {
        TestRunnerApi testRunnerApi = ScriptableObject.CreateInstance<TestRunnerApi>();
        testRunnerApi.RegisterCallbacks(new MyCallbacks());
        Filter editFilter = new Filter
        {
            testMode = TestMode.EditMode
        };
        testRunnerApi.Execute(new ExecutionSettings(editFilter));
    }
    public static void SwitchPlatform()
    {
        if (EditorUserBuildSettings.activeBuildTarget != BuildTarget.Android &&
            EditorUserBuildSettings.activeBuildTarget != BuildTarget.iOS)
        {
            EditorUserBuildSettings.SwitchActiveBuildTarget(
                BuildTargetGroup.Android
                ,BuildTarget.Android);
        }
    }
    private class MyCallbacks : ICallbacks
    {
        public void RunStarted(ITestAdaptor testsToRun)
        {
            Debug.Log($"Run {testsToRun.Name} started");
        }
        public void RunFinished(ITestResultAdaptor result)
        {
            Debug.Log($"Run {result.Name} finished\n{result.Output}");
        }
        public void TestStarted(ITestAdaptor test)
        {
            if (!test.HasChildren)
            {
                Debug.Log($"Test {test.Name} started");
            }
        }
        public void TestFinished(ITestResultAdaptor result)
        {
            Debug.Log($"Test {result.Name} finished\n{result.ResultState}");
        }
    }
}