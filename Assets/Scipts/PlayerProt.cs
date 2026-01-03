using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProt : MonoBehaviour
{
    public Transform Player;

    public GameObject UiTablet;

    public GameObject spwanPointRoom1;
    public GameObject spwanPointRoom2;
    public GameObject spwanPointRoom3;
    public GameObject spwanPointRoom4;
    public GameObject spwanPointRoom5;

    public GameObject Room1;
    public GameObject Room2;
    public GameObject Room3;
    public GameObject Room4;
    public GameObject Room5;


    bool openTab;

    CharacterController characterController;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public MouseLook mouseLook;

    void Start()
    {
        openTab = false;
        UiTablet.SetActive(false);

        characterController = Player.GetComponent<CharacterController>();

        Room2.SetActive(false);
        Room3.SetActive(false);
        Room4.SetActive(false);
        Room5.SetActive(false);



       // Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);


    }

   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            
            if (openTab == false)
            {   
                mouseLook.enabled = false;
               // Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
                print("pressed");
                UiTablet.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = false;
                openTab = true;
            }
            else
            {
                mouseLook.enabled = true;
                UiTablet.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                openTab = false;
            }


        }
        //if (Input.GetKeyDown(KeyCode.E) && openTab == true)
        //{
        //    openTab = false;
        //    UiTablet.SetActive(false);
        //    Cursor.lockState = CursorLockMode.Locked;

        //}



        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            characterController.enabled = false;
            Player.position = spwanPointRoom1.transform.position;
            characterController.enabled = true;

            Room1.SetActive(true);
            Room2.SetActive(false);
            Room3.SetActive(false);
            Room4.SetActive(false);
            Room5.SetActive(false);

        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            characterController.enabled = false;
            Player.position = spwanPointRoom2.transform.position;
            characterController.enabled = true;

            Room1.SetActive(false);
            Room2.SetActive(true);
            Room3.SetActive(false);
            Room4.SetActive(false);
            Room5.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            characterController.enabled = false;
            Player.position = spwanPointRoom3.transform.position;
            characterController.enabled = true;

            Room1.SetActive(false);
            Room2.SetActive(false);
            Room3.SetActive(true);
            Room4.SetActive(false);
            Room5.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            characterController.enabled = false;
            Player.position = spwanPointRoom4.transform.position;
            characterController.enabled = true;

            Room1.SetActive(false);
            Room2.SetActive(false);
            Room3.SetActive(false);
            Room4.SetActive(true);
            Room5.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            characterController.enabled = false;
            Player.position = spwanPointRoom5.transform.position;
            characterController.enabled = true;

            Room1.SetActive(false);
            Room2.SetActive(false);
            Room3.SetActive(false);
            Room4.SetActive(false);
            Room5.SetActive(true);
        }



    }
}
