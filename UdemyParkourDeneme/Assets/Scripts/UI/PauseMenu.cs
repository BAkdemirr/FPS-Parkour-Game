using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private bool isGamePaused = false;
    public GameObject pauseMenu_obj;
    public bool isGameOver = false;

    public GameObject player, pistol;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)  
        {
            if (!isGamePaused) 
            {
                Pause();
            }
            else
            {
                Resume();
            }
        }
    }

    private void Pause()
    {
        Time.timeScale = 0;

        // Disable playermovement and pistol
        player.GetComponent<PlayerMovement>().enabled = false;
        pistol.GetComponent<WeaponControl>().enabled = false;

        // Set cursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        pauseMenu_obj.SetActive(true);
        isGamePaused = true;
    }

    private void Resume()
    {
        Time.timeScale = 1;

        // Set Cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Enable playermovement and pistol
        player.GetComponent<PlayerMovement>().enabled = true;
        pistol.GetComponent<WeaponControl>().enabled = true;

        pauseMenu_obj.SetActive(false);
        isGamePaused = false;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void OpenMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

}
