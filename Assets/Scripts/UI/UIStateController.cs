using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace ExploreKu.UnityComponents.UIBehaviors
{
	public class UIStateController : MonoBehaviour
	{
		public static UIStateController Instance
		{
			get;
			private set;
		}

		private static Dictionary<string, UIPanelBase> alivePanels = new Dictionary<string, UIPanelBase>();
		private static Stack<UIPanelBase> panelDepthTracker = new Stack<UIPanelBase>();
		private static IEnumerator currentActiveRoutine = null;

		private static RectTransform uiCanvasRectTransform;
		[SerializeField]
		private  RectTransform specifiedUICanvasRectTransform;
		[SerializeField]
		private GraphicRaycaster graphicRaycaster;
		[SerializeField]
		private GameObject bottomLayer;

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
			Instance = this;

			if(specifiedUICanvasRectTransform == null)
				throw new System.ArgumentNullException("UI Canvas is unspecified", "specifiedUiCanvas");

			uiCanvasRectTransform = specifiedUICanvasRectTransform;
		}

		int flickFingerId = -1;
		float timer = 0;
		Vector2 touchDownCoordinate;

		void Update()
		{
			if(panelDepthTracker.Count == 0) return;

#if UNITY_EDITOR
			if(Input.GetKeyUp(KeyCode.Escape))
			{
				GoBackToPreviousPanel();
			}
#endif

			if(Input.touchCount != 1) return;
			Touch t = Input.GetTouch(0);

			if(panelDepthTracker.Count > 1) goto DetectSwipeBack;

			var result = new List<RaycastResult>();
			PointerEventData ped = new PointerEventData(null);
			ped.position = t.position;
			graphicRaycaster.Raycast(ped, result);
			if(result.Count == 0)
			{
				Debug.Log("Tapped On Blank");
				GoBackToPreviousPanel();
				return;
			}

		DetectSwipeBack:

			if(t.fingerId != flickFingerId && t.phase == TouchPhase.Began)
			{
				flickFingerId = t.fingerId;
				touchDownCoordinate = t.position;
				return;
			}

			if(t.fingerId == flickFingerId)
			{
				Vector2 distance;
				switch(t.phase)
				{
				case TouchPhase.Moved:
					distance  = t.position - touchDownCoordinate;
					if(Mathf.Abs(Vector2.Angle(distance, Vector2.right)) >= 25) goto TouchCanceled;
					break;

				case TouchPhase.Ended:
					distance = t.position - touchDownCoordinate;
					bool isSwipeLeft = Mathf.Abs(distance.x  / Screen.width) > 0.2f && Mathf.Abs(Vector2.Angle(distance, Vector2.right)) < 10;
					if(isSwipeLeft) GoBackToPreviousPanel();
					goto TouchCanceled;

				case TouchPhase.Canceled:
				TouchCanceled:
					flickFingerId = -1;
					timer = 0;
					break;
				}

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