using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroy : MonoBehaviour
{

	public float lifeTime = 2;

	private float creationTime;

	public Vector3 dir;


    // Start is called before the first frame update
    void Start()
    {

        this.creationTime = Time.time;
		
		//this.GetComponent<Rigidbody>().AddForce(this.dir);
		this.GetComponent<Rigidbody>().velocity = this.dir;

		Debug.Log(this.dir);

		Debug.Log(this.GetComponent<Rigidbody>().velocity);

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - this.creationTime > this.lifeTime)
			Destroy(gameObject);
    }
}
