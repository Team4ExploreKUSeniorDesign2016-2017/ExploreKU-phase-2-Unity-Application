using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ExploreKu.UnityComponents
{
	public class UIStateController : MonoBehaviour
	{
		private static Dictionary<string, UIPanelBase> alivePanels = new Dictionary<string, UIPanelBase>();
		private static Stack<UIPanelBase> panelDepthTracker = new Stack<UIPanelBase>();
		private static IEnumerator currentActiveRoutine = null;

		private static RectTransform uiCanvasRectTransform;
		[SerializeField]
		private  RectTransform specifiedUICanvasRectTransform;

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

		public static bool CheckActiveRoutineExistence()
		{
			return currentActiveRoutine != null;
		}

		public static Rect GetUICanvasRect()
		{
			return uiCanvasRectTransform.rect;
		}

		void Awake()
		{
			if(specifiedUICanvasRectTransform == null)
				throw new System.ArgumentNullException("UI Canvas is unspecified", "specifiedUiCanvas");

			uiCanvasRectTransform = specifiedUICanvasRectTransform;
		}

		void Update()
		{
			if(Input.GetKeyUp(KeyCode.Escape))
			{
				GoBackToPreviousPanel();
			}
		}

		public void GotoPanel(string name)
		{
			if(currentActiveRoutine != null)
			{
				Debug.Log("There is an active transition. Transition to " + "\"" + name + "\""+ " is ignored");
				return;
			}

			UIPanelBase targetPanel;
			if(!alivePanels.TryGetValue(name, out targetPanel))
				throw new System.ArgumentException("Could not find the panel entity with the given name", "name");
			if(targetPanel == null)
				throw new System.Exception("Panel associated with the name has already disappeared. ");

			UIPanelBase topPanelOnStack = panelDepthTracker.Count > 0 ? panelDepthTracker.Peek() : null;

			if(topPanelOnStack == targetPanel)
			{
				Debug.Log("Top panel is exactly the target panel. Transition to " + "\"" + name + "\""+ " is ignored");
				return;
			}
			currentActiveRoutine = ExchangePanelRoutine
			(
				topPanelOnStack,
				targetPanel
			);

			panelDepthTracker.Push(targetPanel);
			StartCoroutine(currentActiveRoutine);
		}

		public void GoBackToPreviousPanel()
		{
			if(currentActiveRoutine != null)
			{
				Debug.Log("There is an active transition. Call to go back to previous panel is ignored. ");
				return;
			}

			if(panelDepthTracker.Count == 0)
			{
				Debug.Log("There is no panel in the hierachy. Call to go back to previous panel is ignored. ");
				return;
			}

			UIPanelBase topPanel = panelDepthTracker.Pop();
			UIPanelBase immediateBeneathPanel = panelDepthTracker.Count != 0 ? panelDepthTracker.Peek() : null;

			currentActiveRoutine = ExchangePanelRoutine(topPanel, immediateBeneathPanel);
			StartCoroutine(currentActiveRoutine);
		}

		private IEnumerator ExchangePanelRoutine(UIPanelBase toHide, UIPanelBase toShow)
		{
			if(toHide)
			{
				Coroutine toHideCoroutine = toHide.HidePanel();
					yield return toHideCoroutine;
			}

			if(toShow)
			{
				Coroutine toShowCoroutine = toShow.ShowPanel();
					yield return toShowCoroutine;
			}

			currentActiveRoutine = null;
		}
	}
}