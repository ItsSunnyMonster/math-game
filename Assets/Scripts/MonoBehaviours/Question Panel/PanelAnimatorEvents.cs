//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using MonoBehaviours.Player;
using UnityEngine;

namespace MonoBehaviours.Question_Panel
{
    public class PanelAnimatorEvents : MonoBehaviour
    {
        public PlayerMovement playerMovement;
        public MouseLook mouseLook;
        
        //called when question panel is opened
        public void DisablePlayerInteraction()
        {
            //unlock cursor
            Cursor.lockState = CursorLockMode.None;
            
            //disable player interactions
            mouseLook.enabled = false;
            playerMovement.enabled = false;
        }

        //called when question panel is closed
        public void EnablePlayerInteraction()
        {
            //lock cursor
            Cursor.lockState = CursorLockMode.Locked;
            
            //enable player interactions
            playerMovement.enabled = true;
            mouseLook.enabled = true;
        }
    }
}
