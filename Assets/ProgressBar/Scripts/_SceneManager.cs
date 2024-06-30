using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class _SceneManager : MonoBehaviour
{

	public void LoadTownScene()
	{
		LoadScene(SceneName.TestNPCScene);
	}

	public enum SceneName
	{
		TestLoading,
		Test3MenuScene,
		TestNPCScene
	}

	public static SceneName sceneToLoad;

	public static void LoadScene(SceneName sceneName)
	{
		sceneToLoad = sceneName;
		SceneManager.LoadScene(SceneName.TestLoading.ToString());
	}
}
