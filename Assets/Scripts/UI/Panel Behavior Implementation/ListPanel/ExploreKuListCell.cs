using UnityEngine;
using UnityEngine.UI;
using ExploreKu.DataClasses;

namespace ExploreKu.UnityComponents.UIBehaviors.PanelImplemtation
{

	public class ExploreKuListCell : MonoBehaviour
	{
		[SerializeField]
		private Image icon;
		[SerializeField]
		private Text label;
		[SerializeField]
		private Sprite[] iconSprites;

		private Location referencedLocation;


		public void UpdateInformation(Location location)
		{
			referencedLocation = location;
			label.text = location.name;
			icon.sprite = iconSprites[(int)location.locatable_type];
		}

		public void Reset()
		{
			label.text = "";
			icon.sprite = iconSprites[0];
			referencedLocation = null;
		}

		public void Disappear()
		{
			gameObject.SetActive(false);
		}

		public void Appear()
		{
			gameObject.SetActive(true);
		}

		public void GotoDesignatedPanel()
		{
			if(referencedLocation == null)
				return;

			ExploreKuStateSaver.selectedId = referencedLocation.id;
			switch(referencedLocation.locatable_type)
			{
				case LocatableType.Building:
					UIStateController.Instance.GotoPanel("Information Panel");
					break;

				default:
					Debug.LogWarning("ExploreKuListCell: Given location type has not given an action: "+ referencedLocation.locatable_type.ToString());
					break;
			}
		}
	}
}
