//
// Copyright (c) SunnyMonster
// https://www.youtube.com/channel/UCbKQHYlzpR_pa5UL7JNP3kg/
//

using TMPro;
using UnityEngine;

public class PanelAnimatorEvents : MonoBehaviour
{
    public void DisablePlayerInteraction()
    {
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0f;
    }

    public void EnablePlayerInteraction()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Time.timeScale = 1f;
    }
}
