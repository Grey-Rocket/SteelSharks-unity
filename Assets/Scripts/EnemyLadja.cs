using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyLadja : MonoBehaviour
{

	public Rigidbody rb;

	[SerializeField]
	public float velocity = 50;


	public GameObject playerShip;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

		playerShip = GameObject.FindWithTag("Player");

		Debug.Log(playerShip.transform.position);

		Debug.Log(rb.transform.position);

    }

    // Update is called once per frame
    void Update()
    {

		Vector3 doPlayerja = new Vector3(
			
		);
		

		Vector3 premik = new Vector3();

		

        this.premakni(true);
	    this.rotiraj(0.125f);
    }

	// true = naprej, false = nazaj
	public void premakni(bool naprej) {
		if(vectorLength(rb.velocity) < velocity) {
			rb.AddForce(rb.transform.forward);
		}
	}

	public void rotiraj(float rotationAngle) {
		rb.transform.Rotate(0, rotationAngle, 0);
	}

	public double vectorLength(Vector3 v) {
		return Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);
	}	

}
