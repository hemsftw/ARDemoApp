using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addModels: MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject ARCamera = GameObject.Find ("ImageTarget");
		//SetParent (ARCamera);
		GameObject newGameObject;
		newGameObject = new GameObject ("NEW MODEL");
		newGameObject.transform.parent = ARCamera.transform;

		// Get a reference to the storage service, using the default Firebase App
		Firebase.Storage.FirebaseStorage storage = Firebase.Storage.FirebaseStorage.DefaultInstance;
		// Create a reference with an initial file path and name
		Firebase.Storage.StorageReference path_reference = storage.GetReference("t1/wk1/y8bi001mdl1/dna.dae");

		string local_url = "Assets/DownloadedModels/dna.dae";

		// Download to the local filesystem
		path_reference.GetFileAsync(local_url).ContinueWith(task => {
			if (!task.IsFaulted && !task.IsCanceled) {
				Debug.Log("File downloaded.");
				// instantiate the model here

			}
		});
		}
		
	GameObject model_1 = GameObject.Instantiate(Resources.Load("Assets/DownloadedModels/teAgCMol_400x400.jpg", typeof(GameObject))) as GameObject;


	
	// Update is called once per frame
	void Update () {
		
	}
}
