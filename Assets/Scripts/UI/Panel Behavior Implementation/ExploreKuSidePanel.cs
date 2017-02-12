using UnityEngine;
using System.Collections;

namespace ExploreKu.UnityComponents.UIBehaviors.PanelImplemtation
{
	[RequireComponent(typeof(iTweenCallbackMod_UI))]
	public class ExploreKuSidePanel : UIPanelBase
	{
		[SerializeField]
		private float transitionTime = 0.5f;
		[SerializeField]
		private iTween.EaseType transitionEaseType = iTween.EaseType.easeOutCubic;

		protected sealed override IEnumerator ShowSelfProcedure()
		{
			Rect panelRect = rectTransform.rect;

			iTween.ValueTo (gameObject, iTween.Hash (
				"from", rectTransform.anchoredPosition,
				"to", new Vector2(panelRect.width, 0),
				"time", transitionTime,
				"easetype", transitionEaseType,
				"onupdate", "wheniTweenUpdateUpdateSelfPosition",
				"onupdatetarget", gameObject));

			yield return new WaitForSeconds(transitionTime);
		}

		protected sealed override IEnumerator HideSelfProcedure()
		{
			iTween.ValueTo (gameObject, iTween.Hash (
				"from", rectTransform.anchoredPosition,
				"to", new Vector2(0, 0),
				"time", transitionTime,
				"easetype", transitionEaseType,
				"onupdate", "wheniTweenUpdateUpdateSelfPosition",
				"onupdatetarget", gameObject));

			yield return new WaitForSeconds(transitionTime);
		}
	}
}


