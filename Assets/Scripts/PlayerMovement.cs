using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody parentRb;

    private Rigidbody thisRb;

    [SerializeField]
    private int speedGear = 2;
    private float nextSpeedShift = -1;

    [SerializeField]
    private int rotationGear = 3;
    private float nextRotationShift = -1;

    [SerializeField]
    private float inputDelay = 0.75f;

    [SerializeField]
    private float[] gearSpeeds = new float[] {-15f,-10f, 0f, 15f, 30f};
    private float moveSpeed = 2f;

    [SerializeField]
    private float[] gearRotation = new float[] { -0.015f, -0.01f, -0.005f , 0, 0.005f, 0.01f, 0.015f };

    // Start is called before the first frame update
    void Start()
    {

        parentRb = transform.parent.GetComponent<Rigidbody>();

        //here be bugs
        //thisRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

        moveShip();

        turnShip();


    }

    private void turnShip()
    {
        //rotation
        if (nextRotationShift < Time.time)
        {
            if (Input.GetAxisRaw("Horizontal") > 0 && rotationGear < 6)
            {
                rotationGear++;
                nextRotationShift = Time.time + inputDelay;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0 && rotationGear > 0)
            {
                rotationGear--;
                nextRotationShift = Time.time + inputDelay;
            }
        }

        this.transform.Rotate(0,gearRotation[rotationGear] * parentRb.velocity.magnitude, 0);

        //here be bugs
        //thisRb.AddTorque(new Vector3(0,2,0)) ;

    }

    private void moveShip()
    {
        //speed
        if (nextSpeedShift < Time.time)
        {

            if (Input.GetAxisRaw("Vertical") > 0)
            {
                if (speedGear < 4) {
                    speedGear++;

                }

                if (rotationGear > 3)
                {
                    rotationGear--;
                }
                else if (rotationGear < 3)
                {
                    rotationGear++;
                }
                //Debug.Log(nextSpeedShift);

                nextSpeedShift = Time.time + inputDelay;
            }
            
            else if (Input.GetAxisRaw("Vertical") < 0)
            {
                if (speedGear > 0)
                {
                    speedGear--;
                }

                nextSpeedShift = Time.time + inputDelay;

                if (rotationGear > 3)
                {
                    rotationGear--;
                }
                else if (rotationGear < 3)
                {
                    rotationGear++;
                }
            }
        }

        if (parentRb.velocity.z < gearSpeeds[speedGear])
        {
            parentRb.AddForce(transform.forward * moveSpeed);

            //under construction
            //thisRb.AddForce(transform.forward * moveSpeed);
        }
        else if (parentRb.velocity.z > gearSpeeds[speedGear])
        {
            parentRb.AddForce(-transform.forward * moveSpeed / 2);
            
            //under construction
            //thisRb.AddForce(-transform.forward * moveSpeed);
        }

    }
}
