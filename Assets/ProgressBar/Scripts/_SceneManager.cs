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
		LoadScene(SceneName.TownScene);
	}

	public enum SceneName
	{
		TestLoading,
		Test3MenuScene,
		TownScene
	}

	public static SceneName sceneToLoad;

	public static void LoadScene(SceneName sceneName)
	{
		sceneToLoad = sceneName;
		SceneManager.LoadScene(SceneName.TestLoading.ToString());
	}
}
