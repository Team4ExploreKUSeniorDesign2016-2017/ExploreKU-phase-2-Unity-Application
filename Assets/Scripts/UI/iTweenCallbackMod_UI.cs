using UnityEngine;

public class iTweenCallbackMod_UI : MonoBehaviour {

	public RectTransform selfRectRef;
	public UnityEngine.UI.Graphic selfGraphicsRef;
	public CanvasGroup canvasGroupRef;

	void Awake () {
		if(selfRectRef == null)
			selfRectRef = gameObject.GetComponent<RectTransform> ();
		if(selfGraphicsRef == null)
			selfGraphicsRef = gameObject.GetComponent<UnityEngine.UI.Graphic> ();
		if(canvasGroupRef == null)
			canvasGroupRef = gameObject.GetComponent<CanvasGroup> ();
	}

	void wheniTweenUpdateUpdateSelfPosition(Vector2 updatedVec)
	{
		selfRectRef.anchoredPosition = updatedVec;
	}

	void wheniTweenUpdateUpdateSelfEulerAngle(Vector3 updatedVec)
	{
		selfRectRef.eulerAngles = updatedVec;
	}

	void wheniTweenUpdateUpdateSelfColor(Color updatedColor)
	{
		selfGraphicsRef.color = updatedColor;
	}

	void wheniTweenUpdateUpdateCanvasGroupAlpha(float updatedAlpha)
	{
		canvasGroupRef.alpha = updatedAlpha;
	}
}
