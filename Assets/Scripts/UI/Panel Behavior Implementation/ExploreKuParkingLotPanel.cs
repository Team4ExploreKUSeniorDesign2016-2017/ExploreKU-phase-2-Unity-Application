using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using ExploreKu.DataClasses;
using ExploreKu.UnityComponents.DataProcessing;
using System;

namespace ExploreKu.UnityComponents.UIBehaviors.PanelImplemtation
{
	[RequireComponent(typeof(iTweenCallbackMod_UI))]

	public class ExploreKuParkingLotPanel : UIPanelBase
	{
		[SerializeField]
		private float transitionTime = 0.5f;
		[SerializeField]
		private iTween.EaseType transitionEaseType = iTween.EaseType.easeOutCubic;
		[SerializeField]
		private Text titleText;
		[SerializeField]
		private Text regulationText;
		[SerializeField]
		private Text noInfoWarningText;
		[SerializeField]
		private Text lotInfoText;
		[SerializeField]
		private ExploreKuParkingTypeCountList spaceList;

		private ParkingLot focusedParkingLot;

		protected override IEnumerator ShowSelfProcedure()
		{
			DataProcessTool.Instance.GetLocation<ParkingLot>(ExploreKuStateSaver.selectedId, RefreshInformation);

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

		protected override IEnumerator HideSelfProcedure()
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

		private void RefreshInformation(ParkingLot pl)
		{
			titleText.text = pl.name;
			var infoList = new List<ExploreKu.DataClasses.Locatables.ParkingSpaceTypeCounter>();
			foreach(var kvp in pl.locatable.parking_count)
			{
				if(kvp.Value != null)
				{
					infoList.Add(new ExploreKu.DataClasses.Locatables.ParkingSpaceTypeCounter(){type = kvp.Key, count = kvp.Value.Value});
				}
			}
			infoList.Sort((a,b) => ((int)a.type).CompareTo((int)b.type));
			noInfoWarningText.gameObject.SetActive(infoList.Count == 0);
			spaceList.UpdateList(infoList);

			var sb = new System.Text.StringBuilder();
			if(!string.IsNullOrEmpty(pl.locatable.restrictions)) sb.AppendLine(pl.locatable.restrictions);
			foreach(string s in pl.locatable.parking_exceptions) sb.AppendLine(s);

			regulationText.text = sb.ToString();

			lotInfoText.text = "Lot Number: " + pl.locatable.lot;
		}

		public void OpenMap()
		{
			if (focusedParkingLot == null) return;

			string urlFormat = "https://www.google.com/maps/place/Lot+{0},+Lawrence,+KS";

			string mapURL = string.Format(urlFormat, focusedParkingLot.locatable.lot);
			Application.OpenURL(mapURL);
		}
	}
}