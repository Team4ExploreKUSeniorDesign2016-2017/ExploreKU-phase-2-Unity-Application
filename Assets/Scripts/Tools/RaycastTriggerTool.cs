using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;

public class RaycastTriggerTool : MonoBehaviour, IPointerClickHandler
{
	public int buildingId;
	public UnityEvent OnClick;

	// Use this for initialization
	public void OnPointerClick(PointerEventData data)
	{
		ExploreKuStateSaver.selectedId = buildingId;
		FindObjectOfType<ExploreKu.UnityComponents.UIBehaviors.UIStateController>().GotoPanel("Information Panel");
		//OnClick.Invoke();
	}
}
