using UnityEngine;
using UnityEngine.UI;
using ExploreKu.DataClasses.Locatables;
using System;

namespace ExploreKu.UnityComponents.UIBehaviors.PanelImplemtation
{
	public class ExploreKuParkingTypeCountListCell : MonoBehaviour, IK4UIPoolingListCell<ParkingSpaceTypeCounter>
	{
		[SerializeField]
		private Image icon;

		[SerializeField]
		private Text text;

		private ExploreKuParkingTypeCountList list;

		public void Hide()
		{
			gameObject.SetActive(false);
		}

		public void Show()
		{
			gameObject.SetActive(true);
		}

		public void UpdateInformation(int index, ParkingSpaceTypeCounter data)
		{
			list = FindObjectOfType<ExploreKuParkingTypeCountList>();
			icon.sprite = list.GetParkingLotIcon(data.type);
			text.text = string.Format("{0}: {1}", data.type, data.count);
		}
	}
}