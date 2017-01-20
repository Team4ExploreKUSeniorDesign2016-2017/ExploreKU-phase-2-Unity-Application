using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExploreKu.UnityComponents
{
	static class UIStateController
	{
		static Dictionary<string, UIPanelBase> alivePanels = new Dictionary<string, UIPanelBase>();
		static Stack<UIPanelBase> panelDepthTracker = new Stack<UIPanelBase>();

		public static void RegisterPanel(string name, UIPanelBase panel)
		{
			if(panel == null)
				throw new System.ArgumentNullException("panel");

			alivePanels.Add(name, panel);
		}

		public static void UnregisterPanel(string name)
		{
			alivePanels.Remove(name);
		}
	}

	public abstract class UIPanelBase : MonoBehaviour
	{
		protected enum DisplayState
		{
			Shown,
			Hidden
		}

		private DisplayState currentState;
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


