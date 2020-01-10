using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

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

    public GameObject victory;
    public GameObject defeat;

    public GameObject restart;

    public bool gameActive = false;

    private PlayerMovement playerMovement;

    public PlayerShooting firstTur;
    public PlayerShooting secondTur;

    // Start is called before the first frame update
    void Start()
    {
        firstTur = GameObject.FindWithTag("Player").transform.GetChild(0).GetChild(0).GetChild(0).GetChild(0).gameObject.GetComponent<PlayerShooting>();
        secondTur = GameObject.FindWithTag("Player").transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).gameObject.GetComponent<PlayerShooting>();
        playerMovement = GameObject.FindWithTag("Player").transform.GetChild(0).GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (numOfTime < 0)
        {
            gameActive = false;
            defeat.SetActive(true);
            restart.SetActive(true);
            //loose
        }

        if (numOfShips <= 0)
        {
            gameActive = false;

            victory.SetActive(true);
            restart.SetActive(true);
            //display victory
        }

        if (gameActive)
        {
            //Debug.Log(firstTur.KdajLahkoUstrelim() + " drugi: " + secondTur.KdajLahkoUstrelim());

            if (nextTime < 0)
            {
                nextTime = Time.time + period;
            }

            velocity.text = "Velocity: " + Mathf.RoundToInt(playerMovement.shipsSpeed);
            speedGear.text = "Speed gear: " + (playerMovement.speedGear - 2);
            rotationGear.text = "Rotation gear: " + (playerMovement.rotationGear - 2);

            timeRemaining.text = "Time remaining: " + numOfTime;

            int prviTop = firstTur.KdajLahkoUstrelim();
            int drugiTop = secondTur.KdajLahkoUstrelim();

            if (prviTop > 0)
            {
                frontKannon.text = "Front Kannon: Reloading " + prviTop;
            }
            else
            {
                frontKannon.text = "Front Kannon: Can fire";
            }

            if (drugiTop > 0)
            {
                backKannon.text = "Back Kannon: Reloading " + prviTop;
            }
            else
            {
                backKannon.text = "Back Kannon: Can fire";
            }

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

    public void Restart()
    {
        SceneManager.LoadScene("mainScene");
    }
}
