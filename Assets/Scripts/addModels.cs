using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

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
		Firebase.Storage.StorageReference path_reference = storage.GetReference ("t1/wk1/y8bi001mdl1/dna");

		string local_url = "Assets/Resources/dna";

		// Download to the local filesystem
		path_reference.GetFileAsync (local_url).ContinueWith (task => {
			if (!task.IsFaulted && !task.IsCanceled) {
				Debug.Log ("File downloaded.");
				// instantiate the model here

			}
		});

		string url = "https://firebasestorage.googleapis.com/v0/b/vised-8c24e.appspot.com/o/t1%2Fwk1%2Fy8bi001mdl1%2Fdna?alt=media&token=18ae4325-36e2-4895-8f9d-629f3af7008f";
		WWW www = new WWW(url);
		StartCoroutine(WaitForReq(www));
		}

		IEnumerator WaitForReq(WWW www)
		{
		yield return www;
		AssetBundle bundle = www.assetBundle;
		if(www.error == null){
			GameObject dna = (GameObject)bundle.LoadAsset("dna");
			Instantiate (dna); // **Change its position and rotation 
			}
		else{
			Debug.Log(www.error);
			}
		}



	
	// Update is called once per frame
	void Update () {
		
	}
}
