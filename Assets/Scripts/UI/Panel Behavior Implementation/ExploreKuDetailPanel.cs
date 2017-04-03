using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Text;
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
		private Text usefulInfoText;
		[SerializeField]
		private Text descriptionText;
		[SerializeField]
		private RawImage titleImage;

		private IEnumerator loadImageProcedure = null;

		protected sealed override IEnumerator ShowSelfProcedure()
		{
			StopAllCoroutines();

			DataProcessTool.Instance.GetLocation<Building>(ExploreKuStateSaver.selectedId, RefreshInformation);

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

		private void RefreshInformation(Building b)
		{
			StartCoroutine(LoadImageFromSource(b.locatable.image));
			titleText.text = b.name;
			usefulInfoText.text = BuildUsefulInfoString(b);
			descriptionText.text = b.locatable.description;
		}

		private string BuildUsefulInfoString(Building b)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Amenities: ");
			foreach(Amenity a in b.locatable.amenities)
			{
				sb.AppendLine("\t" + a.name);
			}
			sb.AppendLine();
			sb.AppendLine("Departments: ");
			foreach(Department d in b.locatable.departments)
			{
				sb.AppendLine("\t" + d.name);
			}

			return sb.ToString();
		}

		IEnumerator LoadImageFromSource(string url)
		{
			WWW download = new WWW(url);
			yield return download;
			titleImage.texture = download.texture;
		}
	}
}


