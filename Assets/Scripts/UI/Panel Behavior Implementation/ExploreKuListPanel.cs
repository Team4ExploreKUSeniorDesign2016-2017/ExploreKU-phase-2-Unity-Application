using UnityEngine;
using System.Collections;

namespace ExploreKu.UnityComponents.UIBehaviors.PanelImplemtation
{
	[RequireComponent(typeof(iTweenCallbackMod_UI))]
	public class ExploreKuListPanel : UIPanelBase
	{
		[SerializeField]
		private float transitionTime = 0.5f;
		[SerializeField]
		private iTween.EaseType transitionEaseType = iTween.EaseType.easeOutCubic;

		protected sealed override IEnumerator ShowSelfProcedure()
		{
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


