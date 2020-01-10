using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroy : MonoBehaviour
{

	public float lifeTime = 2;

	private float creationTime;
	private GameObject lucHolder;
	private GameObject smokeHolder;

	public Vector3 dir;
	public GameObject lucPrefab;
	public GameObject smokePrefab;

	public AudioClip MusicClip;
	public AudioSource MusicSource;

    // Start is called before the first frame update
    void Start()
    {
		this.lucHolder = GameObject.Find("lucHolder");
		this.smokeHolder = GameObject.Find("smokeHolder");

        this.creationTime = Time.time;
		this.GetComponent<Rigidbody>().velocity = this.dir;
		
		Vector3 lucPos = new Vector3(
			this.transform.position.x,
			this.transform.position.y + 5,
			this.transform.position.z + 5
		);
		
		Vector3 lucDim = this.transform.position + Vector3.Normalize(this.dir) * 10;

		// luc
		GameObject luc = Object.Instantiate(lucPrefab, lucDim, Quaternion.identity);
		luc.transform.SetParent(lucHolder.transform);

		// dim
		GameObject smok = Object.Instantiate(smokePrefab, lucDim, Quaternion.identity);
		smok.transform.rotation = Quaternion.LookRotation(this.dir * 2, Vector3.right);
		smok.transform.SetParent(smokeHolder.transform);
		
		MusicSource = GetComponent<AudioSource>();
		MusicSource.clip = MusicClip;
		MusicSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time - this.creationTime > this.lifeTime)
			Destroy(gameObject);
    }



	void OnTriggerEnter(Collider other) {
		if(other.tag == "EnemyLadja") {
			other.GetComponent<EnemyLadja>().zniziLajf();
			Destroy(gameObject.GetComponent<MeshCollider>());
            Destroy(gameObject.GetComponent<MeshRenderer>());
		}

	} // trigger




} // class
