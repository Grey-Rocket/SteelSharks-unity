using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyLadja : MonoBehaviour
{
	public Rigidbody rb;

	[SerializeField]
	public double maxVelocity = 100;

	[SerializeField]
	public double turnRate = 1;

	[SerializeField]
	public float accelerationRate = 3.0f;

	public GameObject playerShip;

	public int health = 3;

    private UIHandler uiHandler;

    // Start is called before the first frame update
    void Start()
    {
        uiHandler = GameObject.FindWithTag("GameController").GetComponent<UIHandler>();
        rb = GetComponent<Rigidbody>();
		playerShip = GameObject.FindWithTag("Player").transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (uiHandler.gameActive && health > 0)
        {
        
		    Vector3 doPlayerja = new Vector3(
			    playerShip.transform.position.x - rb.transform.position.x,
			    playerShip.transform.position.y - rb.transform.position.y,
			    playerShip.transform.position.z - rb.transform.position.z
		    );
	
		    doPlayerja  = normalizeVector(doPlayerja);
		    Vector3 fwd = normalizeVector(rb.transform.forward);
	
		    double rotationAngle = 
			    dotProduct(doPlayerja, fwd); 
			
            this.premakni();
		
		    rotationAngle = -0.125;
	        this.rotiraj(rotationAngle);
        }
    }

	public void premakni() {
		if(vectorLength(rb.velocity) < this.maxVelocity) {
			rb.AddForce(rb.transform.forward * this.accelerationRate);
		}
	}

	public void rotiraj(double rotationAngle) {
		rb.transform.Rotate(0.0f, (float)rotationAngle, 0.0f);
	}

	public Vector3 normalizeVector(Vector3 v) {
		double len = vectorLength(v);
		return new Vector3(
			v.x / (float) len,
			v.y / (float) len,
			v.z / (float) len
		);
	}

	public double vectorLength(Vector3 v) {
		return v.x * v.x + v.y * v.y + v.z * v.z;
	}	
	
	public double dotProduct(Vector3 a, Vector3 b) {
		return a.x * b.x 
			 + a.y * b.y
			 + a.z * b.z;
	}

	public void zniziLajf() {
        if (this.health > 0)
        {
            this.health--;
            if (this.health <= 0)
            {
                // sink
                rb.useGravity = true;
                rb.constraints = RigidbodyConstraints.None;


                if (transform.childCount >= 3)
                {
                    Destroy(transform.GetChild(2).gameObject);
                }

                uiHandler.ShipKilled();

            }

        }

	}
}




