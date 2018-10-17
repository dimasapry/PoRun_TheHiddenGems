using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KayuPlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	private float distanceBetween;
	private float platformWidth;
	public float distanceBetweenMin;
	public float distanceBetweenMax;

	public float randomAloeEnemyThreshold;
	public ObjectPooler aloeEnemyPool;

	public float randomMbakEnemyThreshold;
	public ObjectPooler mbakEnemyPool;


	public ObjectPooler theObjectPool;

	// Use this for initialization
	void Start () {
		platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
	}

	// Update is called once per frame
	void Update () {
		if (transform.position.x < generationPoint.position.x) {
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			transform.position = new Vector3 (transform.position.x + (platformWidth / 2) + distanceBetween, transform.position.y, transform.position.z);

			//Instantiate (thePlatform, transform.position, transform.rotation);

			GameObject newPlatform = theObjectPool.GetPooledObject ();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

		
			if (Random.Range (0f, 100f) < randomAloeEnemyThreshold) 
			{
				GameObject newAloeEnemy = aloeEnemyPool.GetPooledObject ();
				float aloeEnemyXPosition = Random.Range (-platformWidth / 2 +8f, platformWidth / 2-8f);
				Vector3 aloeEnemyPosition = new Vector3 (aloeEnemyXPosition, 2.76f, 0f);
				newAloeEnemy.transform.position = transform.position + aloeEnemyPosition;
				newAloeEnemy.transform.rotation = transform.rotation;
				newAloeEnemy.SetActive (true);
			} 


			if (Random.Range (0f, 100f) < randomMbakEnemyThreshold) 
			{
				GameObject newMbakEnemy = mbakEnemyPool.GetPooledObject ();
				float mbakEnemyXPosition = Random.Range (-platformWidth / 2+8f, platformWidth / 2-8f);
				Vector3 mbakEnemyPosition = new Vector3 (mbakEnemyXPosition, 9.5f, 0f);
				newMbakEnemy.transform.position = transform.position + mbakEnemyPosition;
				newMbakEnemy.transform.rotation = transform.rotation;
				newMbakEnemy.SetActive (true);
			
			}

			transform.position = new Vector3 (transform.position.x + (platformWidth / 2), transform.position.y, transform.position.z);

		}

	}

}
