//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using TMPro;
using UnityEngine;

public class PanelAnimatorEvents : MonoBehaviour
{ 
    public MouseLook playerMouseLook;
    public PlayerMovement playerMovement;
    public TMP_InputField panelInputField;


    public void DisablePlayerInteraction()
    {
        Cursor.lockState = CursorLockMode.None;
        playerMouseLook.enabled = false;
        playerMovement.enabled = false;
    }

    public void EnablePlayerInteraction()
    {
        Cursor.lockState = CursorLockMode.Locked;
        playerMouseLook.enabled = true;
        playerMovement.enabled = true;
    }
}
