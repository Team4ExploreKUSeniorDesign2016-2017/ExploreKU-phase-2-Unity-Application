using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using ExploreKu.DataClasses;
using ExploreKu.UnityComponents.DataProcessing;

namespace ExploreKu.UnityComponents.UIBehaviors.PanelImplemtation
{
	[RequireComponent(typeof(iTweenCallbackMod_UI))]
	public class ExploreKuListPanel : UIPanelBase
	{
		[SerializeField]
		private float transitionTime = 0.5f;
		[SerializeField]
		private iTween.EaseType transitionEaseType = iTween.EaseType.easeOutCubic;

		[SerializeField]
		private Text titleText;
		[SerializeField]
		private ExploreKuListCell cellTemplate;
		[SerializeField]
		private Transform listContentRootTransform;
		private List<ExploreKuListCell> cellCtrlList = null;

		protected sealed override IEnumerator ShowSelfProcedure()
		{
			RefreshListContent();
			titleText.text = ExploreKuStateSaver.listViewDisplayType.ToString();

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

		void RefreshListContent()
		{
			if(cellCtrlList == null)
			{
				cellCtrlList = new List<ExploreKuListCell>();
				cellCtrlList.Add(cellTemplate);
			}

			Location[] filteredLocations = DataProcessTool.Instance.GetAllLocationsOfType<Location>(ExploreKuStateSaver.listViewDisplayType);

			while(cellCtrlList.Count < filteredLocations.Length)
			{
				GameObject go = Instantiate(cellTemplate.gameObject);
				go.transform.SetParent(listContentRootTransform, false);
				ExploreKuListCell cell = go.GetComponent<ExploreKuListCell>();
				cellCtrlList.Add(cell);
			}

			int i = 0;
			foreach(Location l in filteredLocations)
			{
				cellCtrlList[i].Appear();
				cellCtrlList[i].UpdateInformation(l);
				i++;
			}

			for(;i < cellCtrlList.Count; i++)
			{
				cellCtrlList[i].Disappear();
			}
		}
	}
}


