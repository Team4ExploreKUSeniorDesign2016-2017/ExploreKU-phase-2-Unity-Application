using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PhoneCameraInput : MonoBehaviour {

	public RawImage PlaySpace;
	public RectTransform rectTransform;
	public Text ResolutionOutput;

	WebCamTexture inputTexture;

	IEnumerator Start() 
	{
		yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);

		if (Application.HasUserAuthorization(UserAuthorization.WebCam)) 
		{
			inputTexture = new WebCamTexture (720, 1280);
			PlaySpace.texture = inputTexture;

			inputTexture.Play ();
		}
	}

	void Update()
	{
		if (inputTexture) 
		{
			ResolutionOutput.text = "X" + inputTexture.width + " Y" + inputTexture.height;
		}
	}
}
