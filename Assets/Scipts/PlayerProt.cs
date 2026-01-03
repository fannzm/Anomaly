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

    public TabletUI tabletUI;

    void Start()
    {
        openTab = false;
        UiTablet.SetActive(false);

        characterController = Player.GetComponent<CharacterController>();

        TeleportToRoom(1);

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
                tabletUI.ShowLockScreen();
                tabletUI.codeInputField.ActivateInputField();
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = false;
                openTab = true;
            }
            else
            {
                CloseTablet();
            }

        }
        //if (Input.GetKeyDown(KeyCode.E) && openTab == true)
        //{
        //    openTab = false;
        //    UiTablet.SetActive(false);
        //    Cursor.lockState = CursorLockMode.Locked;

        //}

        if(openTab == false)
        {
                if (Input.GetKeyDown(KeyCode.Alpha1)) TeleportToRoom(1);
                if (Input.GetKeyDown(KeyCode.Alpha2)) TeleportToRoom(2);
                if (Input.GetKeyDown(KeyCode.Alpha3)) TeleportToRoom(3);
                if (Input.GetKeyDown(KeyCode.Alpha4)) TeleportToRoom(4);
                if (Input.GetKeyDown(KeyCode.Alpha5)) TeleportToRoom(5);
        }       

        
    }

    public void TeleportToRoom(int roomNumber)
    {
        characterController.enabled = false;

        Room1.SetActive(false);
        Room2.SetActive(false);
        Room3.SetActive(false);
        Room4.SetActive(false);
        Room5.SetActive(false);

        GameObject activeRoom = null;
        GameObject activeSpawn = null;

        if (roomNumber == 1) { activeRoom = Room1; activeSpawn = spwanPointRoom1; }
        else if (roomNumber == 2) { activeRoom = Room2; activeSpawn = spwanPointRoom2; }
        else if (roomNumber == 3) { activeRoom = Room3; activeSpawn = spwanPointRoom3; }
        else if (roomNumber == 4) { activeRoom = Room4; activeSpawn = spwanPointRoom4; }
        else if (roomNumber == 5) { activeRoom = Room5; activeSpawn = spwanPointRoom5; }

        if (activeRoom != null && activeSpawn != null)
        {
            Player.position = activeSpawn.transform.position;
            Player.rotation = activeSpawn.transform.rotation;
            activeRoom.SetActive(true);

            RoomState rs = activeRoom.GetComponent<RoomState>();
            if (rs != null)
            {
                tabletUI.currentRoom = rs;
                tabletUI.gameManager.GenerateNewCode(rs);
            }
        }

        characterController.enabled = true;
    }

    public void CloseTablet()
    {
        openTab = false;
        UiTablet.SetActive(false);

        mouseLook.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
