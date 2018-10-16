using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGeneratorKota : MonoBehaviour {

	//public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;
	//private float platformWidth;

	private float[] platformWidths;

	private int platformSelector;
	//public float[] platformHeights;
	 //public GameObject[] thePlatforms;
	public ObjectPooler[] theObjectPools;


	//public ObjectPooler theObjectPool;

	// Use this for initialization
	void Start () {
		//platformWidth = thePlatform.GetComponent<SpriteRenderer> ().bounds.size.x;

		platformWidths = new float[theObjectPools.Length];

		for (int i = 0; i < theObjectPools.Length; i++) {
			platformWidths [i] = theObjectPools [i].pooledObject.GetComponent<SpriteRenderer> ().bounds.size.x;
		}

		//platformHeights =  new float[theObjectPools.
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x) {

			platformSelector = Random.Range (0, theObjectPools.Length);


			transform.position = new Vector3 (transform.position.x + (platformWidths [platformSelector]/2) + distanceBetween, transform.position.y, transform.position.z);

			//Instantiate (thePlatform, transform.position, transform.rotation);

			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject ();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

			transform.position = new Vector3 (transform.position.x + (platformWidths [platformSelector]/2), transform.position.y, transform.position.z);

		}



	}
}
