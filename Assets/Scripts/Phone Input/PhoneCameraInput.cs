using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PhoneCameraInput : MonoBehaviour {

	public RawImage PlaySpace;
	public RectTransform rectTransform;
	public Text ResolutionOutput;
	public AspectRatioFitter fitter;

	WebCamTexture inputTexture;

	IEnumerator Start()
	{
		yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);

		PlaySpace.color = Color.white;

#if UNITY_IPHONE
		transform.localEulerAngles = new Vector3(0, 180, -90);
#endif

		if (Application.HasUserAuthorization(UserAuthorization.WebCam))
		{
			inputTexture = new WebCamTexture();
			PlaySpace.texture = inputTexture;
			inputTexture.Play ();
		}
	}

	void Update()
	{
		if (inputTexture)
		{
			ResolutionOutput.text = "X" + inputTexture.width + " Y" + inputTexture.height;
			fitter.aspectRatio = (float)inputTexture.width / inputTexture.height;
		}
	}
}
