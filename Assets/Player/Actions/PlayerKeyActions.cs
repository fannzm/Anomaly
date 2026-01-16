using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Player : MonoBehaviour
{
  /// <summary>
  /// All extra Actions that a Player can do
  ///   o)  opening tablet
  /// </summary>
    public GameObject UiTablet;
    bool openTab;

   
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public MouseLook mouseLook;

    public TabletUI tabletUI;

    void Start()
    {
        openTab = false;
        UiTablet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


    /////////////////////////////////////TABLET Action////////////////////////////////////////////////////////
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (openTab == false)
            {
               OpenTablet();
            }
            else
            {
                CloseTablet();
            }

        }
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    
    }

    public void OpenTablet()
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
    public void CloseTablet()
    {
        openTab = false;
        UiTablet.SetActive(false);
        mouseLook.enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
