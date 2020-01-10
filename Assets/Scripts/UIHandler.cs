using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{

    public TextMeshProUGUI velocity;
    public TextMeshProUGUI speedGear;
    public TextMeshProUGUI rotationGear;

    public TextMeshProUGUI frontKannon;
    public TextMeshProUGUI backKannon;
    public TextMeshProUGUI shipsRemaining;
    public TextMeshProUGUI timeRemaining;

    private int numOfTime = 240;
    private int numOfShips = 6;

    private float nextTime = -1.0f;
    private float period = 1f;

    public GameObject[] toClose;

    public bool gameActive = false;

    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        playerMovement = GameObject.FindWithTag("Player").transform.GetChild(0).GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfTime < 0)
        {
            gameActive = false;
            //loose
        }

        if (numOfShips <= 0)
        {
            gameActive = false;
            //display victory
        }

        if (gameActive)
        {
            if (nextTime < 0)
            {
                nextTime = Time.time + period;
            }

            velocity.text = "Velocity: " + Mathf.RoundToInt(playerMovement.shipsSpeed);
            speedGear.text = "Speed gear: " + (playerMovement.speedGear - 2);
            rotationGear.text = "Rotation gear: " + (playerMovement.rotationGear - 2);

            timeRemaining.text = "Time remaining: " + numOfTime;
        }

        if (gameActive && nextTime < Time.time)
        {
            nextTime = Time.time + period;
            numOfTime--;
        }
    }

    public void ShipKilled()
    {
        numOfShips--;
        shipsRemaining.text = "Ships remaining: " + numOfShips;
    }

    public void GotIt()
    {
        for (int i = 0; i < toClose.Length; i++)
        {
            toClose[i].SetActive(false);
        }
        gameActive = true;
    }
}
