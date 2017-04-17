using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ExploreKu.DataClasses;
using ExploreKu.UnityComponents.DataProcessing;

namespace ExploreKu.UnityComponents.UIBehaviors.PanelImplemtation
{
	[RequireComponent(typeof(iTweenCallbackMod_UI))]

	public class ExploreKuBusStopPanel : UIPanelBase
	{
		private class Triplet<T1, T2, T3>
		{
			public T1 first;
			public T2 second;
			public T3 third;

			public Triplet(T1 one, T2 two, T3 three)
			{
				first = one;
				second = two;
				third = three;
			}
		}

		[SerializeField]
		private float transitionTime = 0.5f;
		[SerializeField]
		private iTween.EaseType transitionEaseType = iTween.EaseType.easeOutCubic;
		[SerializeField]
		private Text titleText;
		[SerializeField]
		private Text usefulInfoText;
		[SerializeField]
		private Transform nextBusListTransform;
		[SerializeField]
		private ExploreKuNextBusCell nextBusCellTemplate;
		[SerializeField]
		private GameObject nextBusTableTitle;
		[SerializeField]
		private GameObject nextBusNoScheduleWarning;

		private BusStop focusedBusStop;
		private List<ExploreKuNextBusCell> nextBusCellPool;

		void Start()
		{
			nextBusCellPool = new List<ExploreKuNextBusCell>();
			nextBusCellPool.Add(nextBusCellTemplate);
		}

		protected sealed override IEnumerator ShowSelfProcedure()
		{
			DataProcessTool.Instance.GetLocation<BusStop>(ExploreKuStateSaver.selectedId, RefreshInformation);

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

		private void RefreshInformation(BusStop b)
		{
			focusedBusStop = b;
			titleText.text = b.name;
			usefulInfoText.text = BuildUsefulInfoString(b);
			RefreshNextBusStopList(b);
		}

		private string BuildUsefulInfoString(BusStop b)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Bus Stop Number: " + b.locatable.number);
			return sb.ToString();
		}

		private void RefreshNextBusStopList(BusStop b)
		{
			var validNextBusList = new List<Triplet<string, string, string>>();

			System.DateTime now = System.DateTime.Now;
			foreach (var routeTimeTable in b.locatable.arrivalTimes)
			{
				foreach (var schedule in routeTimeTable.Value)
				{

					for (int i = 0; i < schedule.Value.Length; i++)
					{
						if (schedule.Value[i] > now)
						{
							validNextBusList.Add(new Triplet<string, string, string>(routeTimeTable.Key, schedule.Key, schedule.Value[i].ToString("hh:mm tt", System.Globalization.CultureInfo.InvariantCulture)));
							break;
						}
					}
				}
			}

			nextBusNoScheduleWarning.SetActive(validNextBusList.Count == 0);
			nextBusTableTitle.SetActive(validNextBusList.Count != 0);

			while (validNextBusList.Count > nextBusCellPool.Count)
			{
				GameObject go = Instantiate(nextBusCellTemplate.gameObject, nextBusListTransform);
				nextBusCellPool.Add(go.GetComponent<ExploreKuNextBusCell>());
			}

			int counter = 0;
			foreach (var info in validNextBusList)
			{
				nextBusCellPool[counter].parent = this;
				nextBusCellPool[counter].Appear();
				nextBusCellPool[counter].RouteName = info.first;
				nextBusCellPool[counter].ScheduleName = info.second;
				nextBusCellPool[counter].NextBusTime = info.second + ": " +info.third;
				counter++;
			}

			for(; counter < nextBusCellPool.Count; counter++)
			{
				nextBusCellPool[counter].Disappear();
			}
		}

		public void SendTextToCheckSchedule()
		{
			if (focusedBusStop == null) return;

			const string lawrenceTransitPhoneNumber = "+17853122414";

#if UNITY_IOS
			const string textMessageFormat = "sms:{0}&body={1}";
#else
			const string textMessageFormat = "sms:{0}?body={1}";
#endif

			string textMessage = string.Format(textMessageFormat, lawrenceTransitPhoneNumber, focusedBusStop.locatable.number);
			Application.OpenURL(textMessage);
		}

		public void GotoNextBusesPanel(string scheduleName, string routeName)
		{
			ExploreKuStateSaver.selectedBusStop = focusedBusStop;
			ExploreKuStateSaver.selectedRouteName = routeName;
			ExploreKuStateSaver.selectedScheduleName = scheduleName;
			UIStateController.Instance.GotoPanel("Next Arrival Time Panel");
		}
	}
}


