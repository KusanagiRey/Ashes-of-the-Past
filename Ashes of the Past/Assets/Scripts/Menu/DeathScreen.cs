using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public static DeathScreen instance;

    public GameObject deathScreen;
    public GameObject Player;

    private void Awake() 
    {
        instance = this;
    }

    public void DeathScreenOn()
    {
        deathScreen.SetActive(true);
        Time.timeScale = 0f;
        Player.GetComponent<CharacterMovement>().enabled = false;
        Player.GetComponent<PlayerCombat>().enabled = false;
    }

    public void ReloadScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level1");
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
