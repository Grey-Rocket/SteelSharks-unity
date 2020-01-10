using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody parentRb;

    private Rigidbody thisRb;

    public int speedGear = 2;
    private float nextSpeedShift = -1;

    public int rotationGear = 2;
    private float nextRotationShift = -1;

    [SerializeField]
    private float inputDelay = 0.65f;

    [SerializeField]
    private float[] gearSpeeds = new float[] {-10f,-5f, 0f, 10f, 15f};
    private float[] moveSpeed = new float[] {  3f,1.5f, 2f, 3f, 5f};

    [SerializeField]
    private float[] gearRotation = new float[] { -0.015f, -0.01f , 0, 0.01f, 0.015f };

    private float currentRotaionSpeed = 0f;

    [SerializeField]
    private float rotationGainSpeed = 0.0001f;

    public float shipsSpeed = 0f;

    public UIHandler uiHandler;

    // Start is called before the first frame update
    void Start()
    {

        uiHandler = GameObject.FindWithTag("GameController").GetComponent<UIHandler>();
        parentRb = transform.parent.GetComponent<Rigidbody>();

        //here be bugs
        //thisRb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        if (uiHandler.gameActive)
        {

            if (Input.GetKey(KeyCode.Escape))
                Screen.lockCursor = false;
            else
                Screen.lockCursor = true;

        }
        else
        {
            Screen.lockCursor = false;
        }

        //Debug.Log(transform.forward + " vs " + parentRb.velocity + " ships speed " + shipsSpeed);
    }

    private void FixedUpdate()
    {
        if (uiHandler.gameActive)
        {
            moveShip();
            shipsSpeed = Vector3.Dot(transform.forward, parentRb.velocity);
            turnShip();
        }
    }

    private void turnShip()
    {
        //rotation
        if (nextRotationShift < Time.time)
        {
            if (Input.GetAxisRaw("Horizontal") > 0 && rotationGear < 4)
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

        if (currentRotaionSpeed < gearRotation[rotationGear]) {
            currentRotaionSpeed += rotationGainSpeed;
        }
        else if (currentRotaionSpeed > gearRotation[rotationGear]) {
            currentRotaionSpeed -= rotationGainSpeed;
        }

        if (shipsSpeed > 0)
        {
            this.transform.Rotate(0, currentRotaionSpeed * parentRb.velocity.magnitude, 0);
        }
        else if (shipsSpeed < 0)
        {
            this.transform.Rotate(0, -currentRotaionSpeed * parentRb.velocity.magnitude, 0);
        }

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

                if (rotationGear > 2)
                {
                    rotationGear--;
                }
                else if (rotationGear < 2)
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

                if (rotationGear > 2)
                {
                    rotationGear--;
                }
                else if (rotationGear < 2)
                {
                    rotationGear++;
                }
            }
        }

        if (shipsSpeed < gearSpeeds[speedGear])
        {
            parentRb.AddForce(transform.forward * moveSpeed[speedGear]);

            //under construction
            //thisRb.AddForce(transform.forward * moveSpeed);
        }
        else if (shipsSpeed > gearSpeeds[speedGear])
        {
            parentRb.AddForce(transform.forward * (-moveSpeed[speedGear]/2));
            
            //under construction
            //thisRb.AddForce(-transform.forward * moveSpeed);
        }

    }
}
