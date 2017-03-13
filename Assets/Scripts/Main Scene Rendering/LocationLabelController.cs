using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using ExploreKu.DataClasses;
using TMPro;
using ExploreKu.UnityComponents.UIBehaviors;

public class LocationLabelController : MonoBehaviour, IPointerClickHandler {

	[SerializeField]
	private TextMeshPro label;
	[SerializeField]
	private SpriteRenderer sprite;
	[SerializeField]
	private Sprite[] labelIcons;
	private Location assignedLocation;

	public UnityEvent OnLabelClick;

	public void RefreshLabel(Location l)
	{
		assignedLocation = l;
		gameObject.name = l.name;
		label.text = l.name;
		sprite.sprite = labelIcons[(int)l.locatable_type];
		Vector3 uwc = GPSEncoder.GPSToUCS(l.latitudeFloat, l.longitudeFloat);
		uwc.y = l.altitudeFloat;
		transform.localPosition = uwc;
	}

	public void SetVisible(bool visible)
	{
		sprite.enabled = visible;
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		OnLabelClick.Invoke();
	}

	public void GotoPanelWithFocusedInformation()
	{
		ExploreKuStateSaver.selectedId = assignedLocation.id;
		switch(assignedLocation.locatable_type)
		{
			case LocatableType.Building:
				UIStateController.Instance.GotoPanel("Information Panel");
				break;
			default:
				Debug.LogWarning(assignedLocation.name + ": information is not assigned yet. ");
				break;
		}
	}
}
