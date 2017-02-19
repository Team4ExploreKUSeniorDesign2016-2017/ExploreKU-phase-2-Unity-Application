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

		public void UpdateInformation(Location location)
		{
			label.text = location.name;
		}

		public void Disappear()
		{
			gameObject.SetActive(false);
		}

		public void Appear()
		{
			gameObject.SetActive(true);
		}
	}
}
