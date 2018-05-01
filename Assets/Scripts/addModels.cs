using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;

public class addModels: MonoBehaviour {
	// to check if model has been instantiated
	public bool instantiated_ = false;
	// Use this for initialization
	public string url;
	void Start () {
		
		// call the model adder function
		StartCoroutine ("WaitForReq");

		}

		IEnumerator WaitForReq()
		{


		// Fetch the download URL
		//var task = path_reference.GetMetadataAsync();
		//string download_url = task.Result.DownloadUrl.ToString ();
		//Debug.Log (download_url);

		// Get a reference to the storage service, using the default Firebase App
		
		Firebase.Storage.FirebaseStorage storage = Firebase.Storage.FirebaseStorage.DefaultInstance;
		Firebase.Storage.StorageReference storage_ref =	storage.GetReferenceFromUrl("gs://vised-8c24e.appspot.com/t1/wk1/y8bi001mdl1/earth");
		Firebase.Storage.StorageReference path_reference = storage.GetReference("t1/wk1/y8bi001mdl1/earth");
		// Fetch the download URL
		
		//string uril = download_url.Result ();
		// Fetch the download URL
		
		// path_reference.GetDownloadUrlAsync().ContinueWith((Task<Uri> task) => {
		// if (!task.IsFaulted && !task.IsCanceled) {
		// 	Debug.Log("Download URL: " + task.Result);
		// 	url = Convert.ToString(task.Result);//task.Result;
		// 	Debug.Log("URL: " + url);
		// 	// ... now download the file via WWW or UnityWebRequest.
		// }
		// });
	
		GameObject ARCamera = GameObject.Find ("ImageTarget");
		url = "https://firebasestorage.googleapis.com/v0/b/vised-8c24e.appspot.com/o/t1%2Fwk1%2Fy8bi001mdl1%2Fheart?alt=media&token=0840a423-6aab-4452-841f-5927133ca478";
		//url = "https://firebasestorage.googleapis.com/v0/b/vised-8c24e.appspot.com/o/t1%2Fwk1%2Fy8bi001mdl1%2Fearth?alt=media&token=a163829e-a6a1-4f0c-95d5-1f827e2faa02";
		//url = "https://firebasestorage.googleapis.com/v0/b/vised-8c24e.appspot.com/o/t1%2Fwk1%2Fy8bi001mdl1%2Fbarbarian?alt=media&token=24df1fd1-4fa8-454f-8ec0-d0adae0cc25f";
		
		WWW www = WWW.LoadFromCacheOrDownload (url,1);//"file:///" + Application.dataPath + "/AssetBundles/earth", 1);
		yield return www;
		

		AssetBundle assetBundle = www.assetBundle;
		//AssetBundleRequest request = assetBundle.LoadAssetAsync<GameObject>("Earth 2K");
		AssetBundleRequest request = assetBundle.LoadAssetAsync<GameObject>("heart");
		//AssetBundleRequest request = assetBundle.LoadAssetAsync<GameObject>("Barbarian");

		
		yield return request;

		//GameObject earth = request.asset as GameObject;
		GameObject heart = request.asset as GameObject;
		//GameObject barbarian = request.asset as GameObject;
		

		// transform position and add rotation
		
		//earth.transform.localScale = new Vector3(18, 18, 18);
		heart.transform.localScale = new Vector3(2, 2, 2);
		//barbarian.transform.localScale = new Vector3(1,1,1);
		//earth.transform.position = new Vector3 (0, 1, 0);

		// finding and assigning the animation
		AssetBundleRequest request_1 = assetBundle.LoadAssetAsync<RuntimeAnimatorController>("heartController");
		//AssetBundleRequest request_1 = assetBundle.LoadAssetAsync<RuntimeAnimatorController>("Barbarian Animator Controller");
		yield return request_1;

		RuntimeAnimatorController controller = request_1.asset as RuntimeAnimatorController;
		Animator animator = heart.GetComponent<Animator>();
		//Animator animator = barbarian.GetComponent<Animator>();
		
		animator.runtimeAnimatorController = controller;
		Instantiate<GameObject> (heart, transform.parent = ARCamera.transform);
	
		instantiated_ = true;

		}
	// Update is called once per frame
	void Update () {
		float speed = 10f;
		if (instantiated_ == true) {
			GameObject earth = GameObject.Find ("heart(Clone)");
			earth.transform.Rotate (Vector3.up, speed * Time.deltaTime);
		}
	}
}