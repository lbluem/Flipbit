using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KutiSceneManager : MonoBehaviour {

	[SerializeField]
	private static string menuSceneName = "KutiGameMenu";

	[SerializeField]
	private static string loadingScreenName = "KutiLoadingTransition";

	[SerializeField]
	private static float minimalLoadTime = 2;



	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	static void OnBeforeSceneLoadRuntimeMethod()
	{
		Debug.Log("Before first scene loaded");
	}


	public static void Loadlevel(string sceneName)
	{
		SceneManager.LoadScene(loadingScreenName);
		var go = new GameObject();
		var loader = go.AddComponent<LoadDummy>();
		go.AddComponent<ScenePersistentObject>();
		loader.StartCoroutine(LoadNewScene(sceneName,go));


	}

	// The coroutine runs on its own at the same time as Update() and takes an integer indicating which scene to load.
	private static IEnumerator LoadNewScene(string sceneName, GameObject loaderdummy)
	{

		// This line waits for 3 seconds before executing the next line in the coroutine.
		// This line is only necessary for this demo. The scenes are so simple that they load too fast to read the "Loading..." text.
		yield return new WaitForSeconds(minimalLoadTime);

		// Start an asynchronous operation to load the scene that was passed to the LoadNewScene coroutine.
		AsyncOperation async = SceneManager.LoadSceneAsync(sceneName);

		// While the asynchronous operation to load the new scene is not yet complete, continue waiting until it's done.
		while (!async.isDone)
		{
			yield return null;
		}
		Destroy(loaderdummy);

        // Unload Assets Test:
        // TODO: Check side effects with KUBA in general
        Resources.UnloadUnusedAssets();
    }


	/// <summary>
	/// Private class that is used as dummy to start a coroutine from static context
	/// </summary>
	private class LoadDummy : MonoBehaviour
	{

	}
}
