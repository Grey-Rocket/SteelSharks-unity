using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public Vector3 targetPoint;
    public float angle;

    public Transform otherTurret;
    public bool frontTurret;

    //[SerializeField]
    private float rotationSpeed = 0.6f;

    public float rotationLimit = 130f;

    private float kannonRaiseDownLimit = 0f;
    private float currentKannonRaised = 0f;
    private float kannonRaiseUpLimit = 17f;

    //[SerializeField]
    private float raisingSpeed = 0.15f;

    private Vector3 kannonToKannon;

    private Transform kannon;

    private UIHandler uiHandler;

    // Start is called before the first frame update
    void Start()
    {
        uiHandler = GameObject.FindWithTag("GameController").GetComponent<UIHandler>();
        kannon = transform.GetChild(0);
        if (frontTurret)
        {
            otherTurret = transform.parent.GetChild(1);
        }
        else
        {
            otherTurret = transform.parent.GetChild(0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (uiHandler.gameActive)
        {
            rotateTurret();
            raiseAndLower();

        }
    }
    private void raiseAndLower()
    {

        if (angle > currentKannonRaised && currentKannonRaised < kannonRaiseUpLimit)
        {
            currentKannonRaised += raisingSpeed;
            kannon.Rotate(-raisingSpeed, 0, 0);
        }
        else if (angle < currentKannonRaised && currentKannonRaised > kannonRaiseDownLimit)
        {
            currentKannonRaised -= raisingSpeed;
            kannon.Rotate(raisingSpeed, 0, 0);
        }

    }

    private void rotateTurret()
    {

        Vector3 directionVect = new Vector3(
            targetPoint.x - this.transform.position.x,
            0,
            targetPoint.z - this.transform.position.z);

        kannonToKannon = new Vector3(transform.position.x, 0, transform.position.z) - new Vector3(otherTurret.position.x, 0, otherTurret.position.z);

        //this is for checking how far 
        float angleToTurret = Vector3.Angle(transform.forward, directionVect);

        float sideOfShip = Vector3.Cross(kannonToKannon, directionVect).y;
        float sideOfTurret = Vector3.Cross(transform.forward, directionVect).y;
        float turretAndShip = Vector3.Cross(kannonToKannon, transform.forward).y;

        //this is needed to check constraints
        float angShipTur = Vector3.Angle(kannonToKannon, transform.forward);

        if (angleToTurret > 1)
        {
            if (sideOfShip > 0)
            {

                if (turretAndShip >= 0)
                {
                    if (sideOfTurret >= 0 && angShipTur < rotationLimit)
                    {
                        transform.Rotate(0, rotationSpeed, 0);
                    }
                    else if (sideOfTurret < 0)
                    {
                        transform.Rotate(0, -rotationSpeed, 0);
                    }
                }
                else if (turretAndShip < 0)
                {
                    transform.Rotate(0, rotationSpeed, 0);
                }
            }
            else if (sideOfShip < 0)
            {
                if (turretAndShip <= 0)
                {
                    if (sideOfTurret <= 0 && angShipTur < rotationLimit)
                    {
                        transform.Rotate(0, -rotationSpeed, 0);
                    }
                    else if (sideOfTurret > 0)
                    {
                        transform.Rotate(0, rotationSpeed, 0);
                    }
                }
                else if (turretAndShip > 0)
                {
                    transform.Rotate(0, -rotationSpeed, 0);
                }
            }
        }
    }
}
