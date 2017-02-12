using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;

public class RaycastTriggerTool : MonoBehaviour, IPointerClickHandler
{
	public UnityEvent OnClick;

	// Use this for initialization
	public void OnPointerClick(PointerEventData data)
	{
		FindObjectOfType<ExploreKu.UnityComponents.UIBehaviors.UIStateController>().GotoPanel("Information Panel");
		//OnClick.Invoke();
	}
}
