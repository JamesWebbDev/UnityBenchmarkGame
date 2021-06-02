﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflexButtons : MonoBehaviour
{
    // Links Buttons to Test
    public ReflexTest reflexTest;
    // How far until player can no longer reach
    private float rayLength = 4f;
    // Has button been clicked?
    private bool beenClicked = false;

    // Throwaway 'one-time' boolean
    private bool hasRun = false;

    // Looking for button GameObjects
    public GameObject topLeft;
    public GameObject bottomLeft;
    public GameObject topMiddle;
    public GameObject bottomRight;
    public GameObject topRight;

    // Looking for light GameObjects
    public GameObject tlLight;
    public GameObject blLight;
    public GameObject tmLight;
    public GameObject brLight;
    public GameObject trLight;


    [HideInInspector]
    public int randomNumber;
    private int oldRandomNumber;

    // Time given to play game
    public float gameTimer = 10;


    // Start is called before the first frame update
    void Start()
    {
        tlLight.SetActive(false);
        blLight.SetActive(false);
        tmLight.SetActive(false);
        brLight.SetActive(false);
        trLight.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (reflexTest.playing == true)
        {
            gameTimer = gameTimer - Time.deltaTime;
        }

        ReflexGame();

        if (reflexTest.score == 0 && hasRun == false)
        {
            randomNumber = Random.Range(1, 6);
            LitButtons();
            hasRun = true;
        }
    }    

    // The Reflex Game
    void ReflexGame()
    { 
        // Establishes a temporary Ray pointing out of camera
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

         // Establishes that attached object can be hit by Raycast
            RaycastHit hit;
            
        // IF Raycast is over object AND Object Tag is ReflexButton AND Mouse0 is down AND beenClicked is false...
        if (Physics.Raycast(ray, out hit, rayLength) && hit.transform.tag == "ReflexButton" && Input.GetKey(KeyCode.Mouse0) && beenClicked == false)
        {

            beenClicked = true;
            //Debug.Log(randomNumber);

            // Specify which button is pressed.
            if (hit.transform.gameObject == topLeft && randomNumber == 1)
            {
                PressedButton();

                //Debug.Log("TopLeft has been pressed once!");
            }
            else if (hit.transform.gameObject == bottomLeft && randomNumber == 2)
            {
                PressedButton();

                //Debug.Log("BottomLeft has been pressed once!");
            }
            else if (hit.transform.gameObject == topMiddle && randomNumber == 3)
            {
                PressedButton();

                //Debug.Log("TopMiddle has been pressed once!");
            }
            else if (hit.transform.gameObject == bottomRight && randomNumber == 4)
            {
                PressedButton();

                //Debug.Log("BottomRight has been pressed once!");
            }
            else if (hit.transform.gameObject == topRight && randomNumber == 5)
            {
                PressedButton();

                //Debug.Log("TopRight has been pressed once!");
            }

            Debug.Log(reflexTest.score + " point/s!");

            beenClicked = false;
        }
    }

    // What happens when you press a button
    void PressedButton()
    {
        // Gives new random number
        NewButton();

        // Lights selected button
        LitButtons();
        // Increments score by 1
        reflexTest.score++;
    }

    // Find a new button
    void NewButton()
    {
        oldRandomNumber = randomNumber;

        randomNumber = Random.Range(1, 6);

        while (oldRandomNumber == randomNumber)
        {
            randomNumber = Random.Range(1, 6);
        }

    }

    // Light up the new button
    public void LitButtons()
    {
        switch (randomNumber)
        {
            case 1:
                tlLight.SetActive(true);
                blLight.SetActive(false);
                tmLight.SetActive(false);
                brLight.SetActive(false);
                trLight.SetActive(false);
                break;
            case 2:
                blLight.SetActive(true);
                tlLight.SetActive(false);
                tmLight.SetActive(false);
                brLight.SetActive(false);
                trLight.SetActive(false);
                break;
            case 3:
                tmLight.SetActive(true);
                tlLight.SetActive(false);
                blLight.SetActive(false);
                brLight.SetActive(false);
                trLight.SetActive(false);
                break;
            case 4:
                brLight.SetActive(true);
                tlLight.SetActive(false);
                blLight.SetActive(false);
                tmLight.SetActive(false);
                trLight.SetActive(false);
                break;
            case 5:
                trLight.SetActive(true);
                tlLight.SetActive(false);
                blLight.SetActive(false);
                tmLight.SetActive(false);
                brLight.SetActive(false);
                break;
        }
    }
}