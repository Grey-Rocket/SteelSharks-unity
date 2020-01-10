using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroy : MonoBehaviour
{

	public float lifeTime = 2;

	private float creationTime;
	private GameObject lucHolder;

	public Vector3 dir;
	public GameObject lucPrefab;

    // Start is called before the first frame update
    void Start()
    {
		this.lucHolder = GameObject.Find("lucHolder");
        this.creationTime = Time.time;
		this.GetComponent<Rigidbody>().velocity = this.dir;
		
		Vector3 lucPos = new Vector3(
			this.transform.position.x,
			this.transform.position.y + 5,
			this.transform.position.z + 5
		);
		
		GameObject luc = Object.Instantiate(lucPrefab, lucPos, Quaternion.identity);
		luc.transform.SetParent(lucHolder.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - this.creationTime > this.lifeTime)
			Destroy(gameObject);
    }
}
