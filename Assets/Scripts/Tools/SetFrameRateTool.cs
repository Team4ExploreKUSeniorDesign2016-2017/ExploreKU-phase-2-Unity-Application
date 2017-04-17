using UnityEngine;

public class SetFrameRateTool : MonoBehaviour {

	public int frameRate = 60;

	// Use this for initialization
	void Awake()
	{
		Application.targetFrameRate = frameRate;
	}
}
