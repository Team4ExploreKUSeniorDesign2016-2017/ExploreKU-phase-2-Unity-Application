using UnityEngine;

public class SetFrameRateTool : MonoBehaviour {

	public int frameRate = 60;

	// Use this for initialization
	void Awake()
	{
		ApplicationChrome.navigationBarState = ApplicationChrome.States.Visible;
		ApplicationChrome.statusBarState = ApplicationChrome.States.Visible;
		Application.targetFrameRate = frameRate;
	}
}
