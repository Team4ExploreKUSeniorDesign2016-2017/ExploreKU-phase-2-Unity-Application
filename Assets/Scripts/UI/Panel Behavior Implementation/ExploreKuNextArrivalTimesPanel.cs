using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using ExploreKu.DataClasses;

namespace ExploreKu.UnityComponents.UIBehaviors.PanelImplemtation
{
	[RequireComponent(typeof(iTweenCallbackMod_UI))]
	public class ExploreKuNextArrivalTimesPanel : UIPanelBase
	{
		[SerializeField]
		private float transitionTime = 0.5f;
		[SerializeField]
		private iTween.EaseType transitionEaseType = iTween.EaseType.easeOutCubic;
		[SerializeField]
		private Text titleText;
		[SerializeField]
		private Text nextBusesText;
		[SerializeField]
		private Text buttonText;
		private const string buttonDescriptionTemplate = "Check Next Buses For Route {0}";

		private BusStop focusedBusStop;
		private string focusedRouteName;
		private string focusedScheduleName;

		protected sealed override IEnumerator ShowSelfProcedure()
		{
			focusedBusStop = ExploreKuStateSaver.selectedBusStop;
			focusedScheduleName = ExploreKuStateSaver.selectedScheduleName;
			focusedRouteName = ExploreKuStateSaver.selectedRouteName;

			titleText.text = string.Format("Next Arrivals");
			nextBusesText.text = BuildNextBusString();
			buttonText.text = string.Format(buttonDescriptionTemplate, focusedRouteName);

			Rect panelRect = UIStateController.GetUICanvasRect();

			iTween.ValueTo(gameObject, iTween.Hash(
				"from", new Vector2(panelRect.width, 0),
				"to", new Vector2(0, 0),
				"time", transitionTime,
				"easetype", transitionEaseType,
				"onupdate", "wheniTweenUpdateUpdateSelfPosition",
				"onupdatetarget", gameObject));

			yield return new WaitForSeconds(transitionTime);
		}

		protected sealed override IEnumerator HideSelfProcedure()
		{
			Rect panelRect = UIStateController.GetUICanvasRect();

			iTween.ValueTo(gameObject, iTween.Hash(
				"from", new Vector2(0, 0),
				"to", new Vector2(panelRect.width, 0),
				"time", transitionTime,
				"easetype", transitionEaseType,
				"onupdate", "wheniTweenUpdateUpdateSelfPosition",
				"onupdatetarget", gameObject));

			yield return new WaitForSeconds(transitionTime);
		}

		private string BuildNextBusString()
		{
			StringBuilder sb = new StringBuilder();
			System.DateTime now = System.DateTime.Now;

			var schedule = focusedBusStop.locatable.arrivalTimes[focusedRouteName][focusedScheduleName];

			for (int i = 0; i < schedule.Length; i++)
			{
				if (schedule[i] > now)
				{
					sb.Append(schedule[i].ToString("hh:mm tt", System.Globalization.CultureInfo.InvariantCulture) + "\n");
				}
			}
			return sb.ToString();
		}

		public void SendTextToCheckSchedule()
		{
			if (focusedBusStop == null) return;

			const string lawrenceTransitPhoneNumber = "+17853122414";

#if UNITY_IOS
			const string textMessageFormat = "sms:{0}&body={1},{2}";
#else
			const string textMessageFormat = "sms:{0}?body={1},{2}";
#endif

			string textMessage = string.Format(textMessageFormat, lawrenceTransitPhoneNumber, focusedBusStop.locatable.number, focusedRouteName);
			Application.OpenURL(textMessage);
		}
	}
}


