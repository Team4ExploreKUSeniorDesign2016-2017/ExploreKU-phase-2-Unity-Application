/**

	K4UIPoolingList.cs -- a UI list controller template from Project K4 "polytone"

	Written by Tommy Li
	Twitter: @heshuimu
	GitHub: @heshuimu

 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class K4UIPoolingList<DataType, CellType>: MonoBehaviour where CellType : IK4UIPoolingListCell<DataType>
{
	[SerializeField]
	private Transform listContentTransform;
	[SerializeField]
	private bool isTemplatePrefab;
	[SerializeField]
	private GameObject cellTemplate;

	protected List<CellType> listCellPool = new List<CellType>();
	private bool isTemplateReused;

	public void UpdateList(ICollection<DataType> dataCollection)
	{
		if(cellTemplate == null)
		{
			Debug.LogErrorFormat("{0}, cellTemplate is null. Did you forget to set it in the Inspector??", name);
			return;
		}

		if(!isTemplateReused && !isTemplatePrefab)
		{
			CellType cellCtrl = cellTemplate.GetComponent<CellType>();
			if(cellCtrl == null)
			{
				Debug.LogErrorFormat("{0}: Cell Template {1} does not have the controller implementing IK4UIPoolingListCell. ", name, cellTemplate.name);
				return;
			}
			listCellPool.Add(cellCtrl);
			isTemplateReused = true;
		}

		while(listCellPool.Count < dataCollection.Count)
		{
			GameObject go = Instantiate(cellTemplate, listContentTransform);
			CellType cellCtrl = go.GetComponent<CellType>();
			if(cellCtrl == null)
			{
				Destroy(go);
				Debug.LogErrorFormat("{0}: Cell Template {1} does not have the controller implementing IK4UIPoolingListCell. ", name, cellTemplate.name);
				return;
			}
			go.transform.SetParent(listContentTransform);
			listCellPool.Add(cellCtrl);
		}

		int index = 0;

		foreach(DataType d in dataCollection)
		{
			listCellPool[index].Show();
			listCellPool[index].UpdateInformation(index, d);
			index++;
		}

		while(index < listCellPool.Count)
		{
			listCellPool[index].Hide();
			index++;
		}
	}
}
