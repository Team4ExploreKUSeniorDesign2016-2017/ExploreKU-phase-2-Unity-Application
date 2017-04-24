/**

	IK4UIPoolingListCell.cs -- a UI list cell interface template from Project K4 "polytone"

	Written by Tommy Li
	Twitter: @heshuimu
	GitHub: @heshuimu

 */

public interface IK4UIPoolingListCell<DataType>
{
	void Show();
	void Hide();
	void UpdateInformation(int index, DataType data);
}