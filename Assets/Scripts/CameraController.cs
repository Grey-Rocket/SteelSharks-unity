using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private int rotSpeed = 100;

    private Vector3 shipCenter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        shipCenter = this.transform.parent.position;        
        
        this.transform.RotateAround(shipCenter, Vector3.up, rotSpeed* Input.GetAxis("Mouse X") * Time.deltaTime);
        
        this.transform.RotateAround(shipCenter, transform.rotation * Vector3.left, rotSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime);
        
        while (this.transform.position.y < 2f) {
            this.transform.RotateAround(shipCenter, transform.rotation * Vector3.left,  5* -Time.deltaTime);
        }

        while (this.transform.position.y > 17f) {
            this.transform.RotateAround(shipCenter, transform.rotation * Vector3.left, 5 * Time.deltaTime);
        }
        

        this.transform.LookAt(shipCenter);
    }
}
