using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;
using ExploreKu.UnityComponents.UIBehaviors;

public class RaycastTriggerTool : MonoBehaviour, IPointerClickHandler
{
	public int buildingId;
	public UnityEvent OnClick;

	// Use this for initialization
	public void OnPointerClick(PointerEventData data)
	{
		ExploreKuStateSaver.selectedId = buildingId;
		UIStateController.Instance.GotoPanel("Information Panel");
		//OnClick.Invoke();
	}
}
