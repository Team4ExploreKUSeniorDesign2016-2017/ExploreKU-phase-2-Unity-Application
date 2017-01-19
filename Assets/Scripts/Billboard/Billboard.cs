using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour {

	Camera mainCamera;

	void Start()
	{
		mainCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.forward = -mainCamera.transform.forward;
	}
}
