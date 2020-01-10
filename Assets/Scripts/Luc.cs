using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Luc : MonoBehaviour
{

	public float lifeTime = 0.2f;
	private float creationTime;

    // Start is called before the first frame update
    void Start()
    {
        this.creationTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
		if(Time.time - this.creationTime > this.lifeTime)
			Destroy(gameObject);   
    }
}
