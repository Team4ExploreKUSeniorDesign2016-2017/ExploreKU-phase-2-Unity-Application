using System.Collections;
using UnityEngine;

namespace ExploreKu.UnityComponents
{
	public abstract class UIPanelBase : MonoBehaviour
	{
		protected enum DisplayState
		{
			Hidden = 0,
			Shown,
		}

		private DisplayState currentState = DisplayState.Hidden;
		private IEnumerator currentActiveCoroutine;

		public RectTransform rectTransform
		{
			get;
			protected set;
		}

		private void Awake()
		{
			UIStateController.RegisterPanel(gameObject.name, this);

			RectTransform thisRectTransform = GetComponent<RectTransform>();
			if(thisRectTransform == null)
				throw new System.Exception("No RectTransform is found on this GameObject: " + gameObject.name);
			rectTransform = thisRectTransform;
		}

		private void OnDestroy()
		{
			UIStateController.UnregisterPanel(gameObject.name);
		}

		public Coroutine HidePanel()
		{
			if(currentState != DisplayState.Hidden)
			{
				currentActiveCoroutine = HideSelfProcedure();
				currentState = DisplayState.Hidden;
				return StartCoroutine(currentActiveCoroutine);
			}

			return null;
		}

		public Coroutine ShowPanel()
		{
			if(currentState != DisplayState.Shown)
			{
				currentActiveCoroutine = ShowSelfProcedure();
				currentState = DisplayState.Shown;
				return StartCoroutine(currentActiveCoroutine);
			}

			return null;
		}

		protected abstract IEnumerator ShowSelfProcedure();
		protected abstract IEnumerator HideSelfProcedure();
	}
}


