using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSea : MonoBehaviour
{

    public GameObject seaPrefab;

    private GameObject seaHolder;

    public int seaTiles = 10;

    // Start is called before the first frame update
    void Start()
    {

        int seaLenght = (int)seaPrefab.transform.localScale.x * (int)seaPrefab.transform.localScale.x;

        seaHolder = GameObject.Find("seaHolder");

        int[] startPosition =new int[] { -seaTiles * (int)seaLenght/2 , -seaTiles * (int)seaLenght / 2 };

        for (int i = 0; i < seaTiles; i++) {
            for (int k = 0; k < seaTiles; k++) {
                GameObject instance = Object.Instantiate(seaPrefab, new Vector3(startPosition[0] + i * seaLenght, 1, startPosition[1] + k * seaLenght), Quaternion.identity);
                instance.transform.SetParent(seaHolder.transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
