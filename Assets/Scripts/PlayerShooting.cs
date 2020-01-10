using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

	//private float time = Time.time;
	
	private Vector3 kannon;

	private GameObject projectileHolder;

	public float projectileSpeed = 1000f;

	public GameObject ballPrefab;

    // Start is called before the first frame update
    void Start()
    {
        projectileHolder = GameObject.Find("projectileHolder");

    }

    // Update is called once per frame
    void Update()
    {
	
		Debug.Log(this.kannon);

		if(Input.GetButtonDown("Fire1"))
			shoot();

    }

	
	public void shoot() {
		
		Debug.Log("SHOOTTED");

		this.kannon = this.transform.forward;

		GameObject instance = Object.Instantiate(ballPrefab, this.transform.position, Quaternion.identity);
		instance.GetComponent<BallDestroy>().dir = this.kannon * this.projectileSpeed;

		instance.transform.SetParent(projectileHolder.transform);
	}


}
