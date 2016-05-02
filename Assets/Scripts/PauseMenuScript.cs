using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PauseMenuScript : MonoBehaviour
{
    public string levelToLoad;
    public bool paused = false;

    private void Start()
    {
        Time.timeScale = 1; //Set the timeScale back to 1 for Restart option to work  
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape)) //check if Escape key/Back key is pressed
        {
            if (paused)
                paused = false;  //unpause the game if already paused
            else
                paused = true;  //pause the game if not paused
        }

        if (paused)
        {
            Time.timeScale = 0;  //set the timeScale to 0 so that all the procedings are halted
            PowerupScript.paused = true;
            ObstacleScript.paused = true;
            GGScript.paused = true;
        }
        else
        {
            Time.timeScale = 1;  //set it back to 1 on unpausing the game
            PowerupScript.paused = false;
            ObstacleScript.paused = false;
            GGScript.paused = false;
        }

    }

    private void OnGUI()
    {

        if (paused)
        {

            GUI.Box(new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2), "PAUSED");

            if (GUI.Button(new Rect(Screen.width / 4 + 10, Screen.height / 4 + Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "RESUME"))
            {
                paused = false;
            }

            if (GUI.Button(new Rect(Screen.width / 4 + 10, Screen.height / 4 + 2 * Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "RESTART"))
            {
                SceneManager.LoadScene("game");
            }

            if (GUI.Button(new Rect(Screen.width / 4 + 10, Screen.height / 4 + 3 * Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "MAIN MENU"))
            {
                SceneManager.LoadScene(levelToLoad);
            }
        }
    }
}