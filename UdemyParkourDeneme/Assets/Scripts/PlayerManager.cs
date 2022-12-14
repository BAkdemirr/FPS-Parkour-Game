using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool player_alive = true;
    public GameObject death_effect;

    public GameObject hand;
    public GameObject crosshair;

    public GameObject gameOverMenu;

    public PauseMenu pause_m;

    public void Death()
    {
        if (player_alive)
        {
            player_alive = false;

            // Disable Pause Menu
            pause_m.isGameOver = true;

            // particle effect
            Instantiate(death_effect, transform.position, Quaternion.identity);

            // disable player
            GetComponent<PlayerMovement>().enabled = false;
            hand.SetActive(false);
            crosshair.SetActive(false);

            // cursor activate
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;

            // Enable GameOver UI
            gameOverMenu.SetActive(true);
        }
    }
}
