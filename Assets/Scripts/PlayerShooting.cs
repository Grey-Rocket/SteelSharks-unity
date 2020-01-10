using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

	//private float time = Time.time;
	
	private Vector3 kannon;

	private GameObject projectileHolder;
	
	private GameObject lucHolder;

	public float projectileSpeed = 100f;

	public GameObject ballPrefab;
	public GameObject lucPrefab;
	
    // Start is called before the first frame update
    void Start()
    {
        projectileHolder = GameObject.Find("projectileHolder");
		lucHolder = GameObject.Find("lucHolder");
    }

    // Update is called once per frame
    void Update()
    {
	
		Debug.Log(this.kannon);

		if(Input.GetButtonDown("Fire1"))
			shoot();

    }

	
	public void shoot() {
		
		this.kannon = this.transform.forward;

		Vector3 pos1 = new Vector3(
			this.transform.position.x - 2,
			this.transform.position.y,
			this.transform.position.z
		);
		GameObject instance1 = Object.Instantiate(ballPrefab, pos1, Quaternion.identity);
		instance1.GetComponent<BallDestroy>().dir = this.kannon * this.projectileSpeed;
		instance1.transform.SetParent(projectileHolder.transform);
		

		Vector3 luc1Pos = new Vector3(
			this.transform.position.x - 2,
			this.transform.position.y + 5,
			this.transform.position.z + 5
		);
		GameObject luc1 = Object.Instantiate(lucPrefab, luc1Pos, Quaternion.identity);
		luc1.transform.SetParent(lucHolder.transform);
	



		// pos2 = position topa (center position)
		GameObject instance2 = Object.Instantiate(ballPrefab, this.transform.position, Quaternion.identity);
		instance2.GetComponent<BallDestroy>().dir = this.kannon * this.projectileSpeed;
		instance2.transform.SetParent(projectileHolder.transform);




		
		Vector3 pos3 = new Vector3(
			this.transform.position.x + 2,
			this.transform.position.y,
			this.transform.position.z
		);
		GameObject instance3 = Object.Instantiate(ballPrefab, pos3, Quaternion.identity);
		instance3.GetComponent<BallDestroy>().dir = this.kannon * this.projectileSpeed;
		instance3.transform.SetParent(projectileHolder.transform);


	}


}
