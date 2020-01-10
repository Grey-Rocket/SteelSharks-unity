using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    private CameraController  playerCameraScript;

    private GameObject turretFront;
    private GameObject turretBack;

    private Vector3 targetPoint;

    [SerializeField]
    private float rotationSpeed = 0.6f;

    [SerializeField]
    private float frontRotationLimit = 130;
    private float frontRotation = 0;

    [SerializeField]
    private float backRotationLimit = 140;
    private float backRotation = 0;

    //private float 

    // Start is called before the first frame update
    void Start()
    {
        playerCameraScript = GameObject.FindGameObjectWithTag("Player").transform.GetChild(1).gameObject.GetComponent<CameraController>(); ;
        turretFront = transform.GetChild(0).GetChild(0).gameObject;

        turretBack = transform.GetChild(0).GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        targetPoint = playerCameraScript.targetPoint;

        //turretFront.transform.LookAt(new Vector3(targetPoint.x, 0, targetPoint.z));
        //turretBack.transform.LookAt(new Vector3(targetPoint.x, 0, targetPoint.z));

        turnTurret(turretFront, "front");
        turnTurret(turretBack, "back");
    }


    private void turnTurret(GameObject turret, string turretName)
    {

        Vector3 directionVect = new Vector3(
            targetPoint.x - turret.transform.position.x,
            0,
            targetPoint.z - turret.transform.position.z);

        float angle = Vector3.Angle(turret.transform.forward, directionVect);

        float sideOfShip = Vector3.Cross(this.transform.forward, directionVect).y;
        float sideOfTurret = Vector3.Cross(turret.transform.forward, directionVect).y;
        float turretAndShip = Vector3.Cross(this.transform.forward, turret.transform.forward).y;

        switch (turretName)
        {
            case ("front"):

                if (angle > 1)
                {
                    if (sideOfShip > 0)
                    {
                        if (turretAndShip >= 0)
                        {
                            if (sideOfTurret < 0 && frontRotation > -frontRotationLimit)
                            {
                                frontRotation -= rotationSpeed;
                                turret.transform.Rotate(0, -rotationSpeed, 0);
                            }
                            else if (sideOfTurret > 0 && frontRotation < frontRotationLimit)
                            {
                                frontRotation += rotationSpeed;
                                turret.transform.Rotate(0, rotationSpeed, 0);
                            }
                        }
                        else
                        {
                            frontRotation += rotationSpeed;
                            turret.transform.Rotate(0, rotationSpeed, 0);
                        }
                    }

                    else if (sideOfShip < 0)
                    {
                        if (turretAndShip <= 0) {
                            if (sideOfTurret > 0 && frontRotation < frontRotationLimit)
                            {
                                frontRotation += rotationSpeed;
                                turret.transform.Rotate(0, rotationSpeed, 0);
                            }
                            else if (sideOfTurret < 0 && frontRotation > -frontRotationLimit)
                            {
                                frontRotation -= rotationSpeed;
                                turret.transform.Rotate(0, -rotationSpeed, 0);
                            }
                        }
                        else
                        {
                            frontRotation -= rotationSpeed;
                            turret.transform.Rotate(0, -rotationSpeed, 0);
                        }
                    }
                }

                break;

            case ("back"):

                if (angle > 1)
                {
                    if (sideOfShip > 0)
                    {
                        if (turretAndShip >= 0)
                        {
                            if (sideOfTurret < 0 && backRotation > -backRotationLimit)
                            {
                                backRotation -= rotationSpeed;
                                turret.transform.Rotate(0, -rotationSpeed, 0);
                            }
                            else if (sideOfTurret > 0 && backRotation < backRotationLimit)
                            {
                                backRotation = rotationSpeed;
                                turret.transform.Rotate(0, rotationSpeed, 0);
                            }

                        }
                        else
                        {
                            backRotation -= rotationSpeed;
                            turret.transform.Rotate(0, -rotationSpeed, 0);
                        }
                    }

                    else if (sideOfShip < 0)
                    {
                        if (turretAndShip <= 0)
                        {
                            if (sideOfTurret > 0 && backRotation < backRotationLimit)
                            {
                                backRotation += rotationSpeed;
                                turret.transform.Rotate(0, rotationSpeed, 0);
                            }
                            else if (sideOfTurret < 0 && backRotation > -backRotationLimit)
                            {
                                backRotation -= rotationSpeed;
                                turret.transform.Rotate(0, -rotationSpeed, 0);
                            }
                        }
                        else
                        {
                            backRotation += rotationSpeed;
                            turret.transform.Rotate(0, rotationSpeed, 0);
                        }

                    }
                }
         break;
        }
    }

}
