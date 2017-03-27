using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
using ExploreKu.DataClasses;
using ExploreKu.UnityComponents.DataProcessing;

namespace ExploreKu.UnityComponents.UIBehaviors.PanelImplemtation
{
	[RequireComponent(typeof(iTweenCallbackMod_UI))]
	public class ExploreKuBusStopPanel : UIPanelBase
	{
		[SerializeField]
		private float transitionTime = 0.5f;
		[SerializeField]
		private iTween.EaseType transitionEaseType = iTween.EaseType.easeOutCubic;
		[SerializeField]
		private Text titleText;
		[SerializeField]
		private Text usefulInfoText;
		[SerializeField]
		private RawImage titleImage;
		private BusStop focusedBusStop;

		protected sealed override IEnumerator ShowSelfProcedure()
		{
			DataProcessTool.Instance.GetLocation<BusStop>(ExploreKuStateSaver.selectedId, RefreshInformation);

			Rect panelRect = UIStateController.GetUICanvasRect();

			iTween.ValueTo (gameObject, iTween.Hash (
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

			iTween.ValueTo (gameObject, iTween.Hash (
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
		}

		private string BuildUsefulInfoString(BusStop b)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Bus Stop Number: " + b.locatable.number);
			return sb.ToString();
		}

		public void SendTextToCheckSchedule()
		{
			if(focusedBusStop == null) return;

			const string lawrenceTransitPhoneNumber = "+17853122414";

			#if UNITY_ANDROID
			const string textMessageFormat = "sms:{0}?body={1}";
			#elif UNITY_IOS
			const string textMessageFormat = "sms:{0};body={1}";
			#endif

			string textMessage = string.Format(textMessageFormat, lawrenceTransitPhoneNumber, focusedBusStop.locatable.number);
			Application.OpenURL(textMessage);
		}
	}
}


