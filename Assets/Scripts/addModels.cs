using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addModels: MonoBehaviour {
	// to check if model has been instantiated
	public bool instantiated_ = false;
	// Use this for initialization


	void Start () {
		
		// call the model adder function
		StartCoroutine ("WaitForReq");

		}

		IEnumerator WaitForReq()
		{
		
		// Get a reference to the storage service, using the default Firebase App
		Firebase.Storage.FirebaseStorage storage = Firebase.Storage.FirebaseStorage.DefaultInstance;

		// Create a reference with an initial file path and name
		Firebase.Storage.StorageReference path_reference = storage.GetReference ("t1/wk1/y8bi001mdl1/earth");

		// Fetch the download URL
		Debug.Log (path_reference.GetDownloadUrlAsync());

		GameObject ARCamera = GameObject.Find ("ImageTarget");
		string url = "https://firebasestorage.googleapis.com/v0/b/vised-8c24e.appspot.com/o/t1%2Fwk1%2Fy8bi001mdl1%2Fearth?alt=media&token=a163829e-a6a1-4f0c-95d5-1f827e2faa02";
		WWW www = WWW.LoadFromCacheOrDownload (url, 1);//"file:///" + Application.dataPath + "/AssetBundles/earth", 1);
		yield return www;

		AssetBundle assetBundle = www.assetBundle;
		AssetBundleRequest request = assetBundle.LoadAssetAsync<GameObject>("Earth 2K");

		yield return request;

		GameObject earth = request.asset as GameObject;
		// transform position and add rotation
		earth.transform.localScale = new Vector3(18, 18, 18);
		earth.transform.position = new Vector3 (0, 1, 0);
		Instantiate<GameObject> (earth, transform.parent = ARCamera.transform);

		instantiated_ = true;

		}

	
	// Update is called once per frame
	void Update () {
		float speed = 8f;
		if (instantiated_ == true) {
			GameObject earth = GameObject.Find ("Earth 2K(Clone)");
			earth.transform.Rotate (Vector3.up, speed * Time.deltaTime);
		}

	}
}