using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.TestRunner;
[assembly:TestRunCallback(typeof(TestListener))]

public class PlayModeTests : MonoBehaviour, IPrebuildSetup
{
	public void Setup()
	{
		AddSceneToBuildSettings("Assets/Scenes/Game1.unity");
		AddSceneToBuildSettings("Assets/Scenes/Game2.unity");
		AddSceneToBuildSettings("Assets/Scenes/Game3.unity");
	}

	// Helper function to set up the test Scene and set it as the active Scene
	static IEnumerator SetUpScene(string scene)
	{
		AsyncOperation loadOp = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);

		// yield until Scene has finished loading (async)
		yield return loadOp;

		// Set the Scene as the active Scene
		SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));
	}

	// Helper function to unload the test Scene
	static IEnumerator CleanUpScene(string scene)
	{
		AsyncOperation unloadOp = SceneManager.UnloadSceneAsync(scene);

		// yield until Scene has finished unloading (async)
		yield return unloadOp;
	}
	[UnityTest]
	public static IEnumerator Scene1()
	{
		yield return SetUpScene("Game1"); //you have to yield a frame until it�s accessible.

		Canvas canvas = FindObjectOfType<Canvas>();
		Assert.NotNull(canvas, "Couldn't find Canvas");
		GameObject emptyGO = new GameObject();
		Assert.NotNull(emptyGO, "Newly created empty GameObject not found");

		yield return CleanUpScene("Game1");
	}
	[UnityTest]
	public static IEnumerator Scene2()
	{
		yield return SetUpScene("Game2"); //you have to yield a frame until it�s accessible.

		GameObject cube = FindObjectOfType<Rigidbody>().gameObject;
		Assert.NotNull(cube, "Couldn't find cube");

		Vector3 iPos = cube.transform.position;
		yield return new WaitForSeconds(1f);
		Assert.NotZero(cube.GetComponent<Rigidbody>().velocity.magnitude, "Cube not moving");

		yield return CleanUpScene("Game2");
	}
	[UnityTest]
	public static IEnumerator Scene3()
	{
		yield return SetUpScene("Game3"); //you have to yield a frame until it�s accessible.

		Assert.AreEqual(SceneManager.GetActiveScene().name, "Game3", "Scene is not Game3");

		yield return CleanUpScene("Game3");
	}
	public static void AddSceneToBuildSettings(string path, bool enabled = true)
	{
#if UNITY_EDITOR
		List<EditorBuildSettingsScene> scenes = new List<EditorBuildSettingsScene>(EditorBuildSettings.scenes);
		scenes.Add(new EditorBuildSettingsScene(path, enabled));
		EditorBuildSettings.scenes = scenes.ToArray();
#endif
	}
}

public class TestListener : ITestRunCallback
{
	public void RunStarted(ITest testsToRun)
	{

	}

	public void RunFinished(ITestResult testResults)
	{
		Debug.Log($"Run finished with result {testResults.ResultState}.");
		DelayedCall();
	}

	public void TestStarted(ITest test)
	{

	}

	public void TestFinished(ITestResult result)
	{
		Application.runInBackground = false;
	}

	private async void  DelayedCall()
	{
		await Task.Delay(1000);
		Application.runInBackground = false;
		Debug.Log($"RunInBackGround was set to {Application.runInBackground}");
	}
}



