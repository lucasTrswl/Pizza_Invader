using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameThemeController : MonoBehaviour
{

    public AudioSource gameTheme;
    public AudioSource speedTheme;
    public AudioSource pauseTheme;
    private bool isSpeedMode = false;
    private bool isMenu = false;



    private void UpdateSounds()
    {
        gameTheme.mute = isSpeedMode || isMenu;
        speedTheme.mute = !isSpeedMode || isMenu;
        pauseTheme.mute = isSpeedMode && !isMenu;
    }

    public void SetMenu(bool menu)
    {
        isMenu = menu;
        UpdateSounds();
    }

    public void SetSpeed(bool speed)
    {
        isSpeedMode = speed;
        UpdateSounds();
    }
}