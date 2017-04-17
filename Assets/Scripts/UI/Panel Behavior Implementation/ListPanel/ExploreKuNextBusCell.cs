using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ExploreKu.UnityComponents.UIBehaviors.PanelImplemtation
{
	public class ExploreKuNextBusCell : MonoBehaviour, IPointerDownHandler
	{
		[SerializeField]
		private Text routeNameLabel;
		[SerializeField]
		private Text nextBusTimeLabel;

		public string RouteName
		{
			get
			{
				return routeNameLabel.text;
			}
			set
			{
				routeNameLabel.text = value;
			}
		}

		public string NextBusTime
		{
			get
			{
				return nextBusTimeLabel.text;
			}
			set
			{
				nextBusTimeLabel.text = value;
			}
		}

		public string ScheduleName
		{
			get;
			set;
		}

		public ExploreKuBusStopPanel parent;

		public void Disappear()
		{
			gameObject.SetActive(false);
		}

		public void Appear()
		{
			gameObject.SetActive(true);
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			parent.GotoNextBusesPanel(ScheduleName, RouteName);
		}
	}
}
