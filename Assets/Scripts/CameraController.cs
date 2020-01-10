using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private int rotSpeed = 100;

    private Vector3 shipCenter;

    public Vector3 targetPoint;

    public TurretScript frontTurret;

    public TurretScript backTurret;

    private float lowPoint = 5f;

    private float highPoint = 20f;

    // Start is called before the first frame update
    void Start()
    {
        frontTurret = transform.parent.GetChild(0).GetChild(0).GetChild(0).GetComponent<TurretScript>();
        backTurret = transform.parent.GetChild(0).GetChild(0).GetChild(1).GetComponent<TurretScript>();

        targetPoint = calculatePoint();

        frontTurret.targetPoint = targetPoint;
        backTurret.targetPoint = targetPoint;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        shipCenter = this.transform.parent.position;        
        
        this.transform.RotateAround(shipCenter, Vector3.up, rotSpeed* Input.GetAxis("Mouse X") * Time.deltaTime);
        
        this.transform.RotateAround(shipCenter, transform.rotation * Vector3.left, rotSpeed * Input.GetAxis("Mouse Y") * Time.deltaTime);
        
        while (this.transform.position.y < lowPoint) {
            this.transform.RotateAround(shipCenter, transform.rotation * Vector3.left,  5* -Time.deltaTime);
        }

        while (this.transform.position.y > highPoint) {
            this.transform.RotateAround(shipCenter, transform.rotation * Vector3.left, 5 * Time.deltaTime);
        }
        

        this.transform.LookAt(shipCenter);

        targetPoint = calculatePoint();

        
        float angle = calcAngle();
        //Debug.Log(angle + " " + transform.position.y );

        frontTurret.targetPoint = targetPoint;
        frontTurret.angle = angle - 5f;

        backTurret.targetPoint = targetPoint;
        backTurret.angle = angle -3 ;
    }

    private float calcAngle()
    { 
        return (transform.position.y- highPoint) /(0f-highPoint) * (20f - lowPoint) + lowPoint;
    }

    private Vector3 calculatePoint()
    {
        return (transform.position + transform.forward * 100);
        
    }
}
