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

    public GameObject[] toClose;

    public bool gameActive = false;

    private PlayerMovement playerMovement;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameActive)
        {
            velocity.text = "Velocity: " + playerMovement.shipsSpeed;
            speedGear.text = "Speed gear: " + (playerMovement.speedGear - 2);
            rotationGear.text = "Rotation gear: " + (playerMovement.rotationGear - 2);
        }
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
