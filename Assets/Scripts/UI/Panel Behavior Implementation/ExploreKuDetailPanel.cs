using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using ExploreKu.DataClasses;
using ExploreKu.UnityComponents.DataProcessing;

namespace ExploreKu.UnityComponents.UIBehaviors.PanelImplemtation
{
	[RequireComponent(typeof(iTweenCallbackMod_UI))]
	public class ExploreKuDetailPanel : UIPanelBase
	{
		[SerializeField]
		private float transitionTime = 0.5f;
		[SerializeField]
		private iTween.EaseType transitionEaseType = iTween.EaseType.easeOutCubic;
		[SerializeField]
		private Text titleText;
		[SerializeField]
		private Text descriptionText;
		[SerializeField]
		private RawImage titleImage;

		protected sealed override IEnumerator ShowSelfProcedure()
		{
			Building b = DataProcessTool.Instance.GetBuilding(ExploreKuStateSaver.selectedId);
			titleText.text = b.name;
			descriptionText.text = b.description;

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
	}
}


