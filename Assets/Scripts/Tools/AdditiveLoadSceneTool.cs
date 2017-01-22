using UnityEngine;
using UnityEngine.SceneManagement;

public class AdditiveLoadSceneTool : MonoBehaviour
{
	public string sceneName;

	void Awake ()
	{
		SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
	}
}
