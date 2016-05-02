using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameControlScript : MonoBehaviour
{

    float timeRemaining = 10;
    float timeExtension = 3f;
    float timeDeduction = 5f;
    float rockDeduction = 10f;
    float totalTimeElapsed = 0;
    public float score = 0f;
    public bool isGameOver = false;
    public float difficulty = 1000f;
    public Material[] walls;
    public Material[] grounds;
    public GameObject wall1;
    public GameObject wall2;
    public GameObject ground;
    int index = 0;

    void Start()
    {
        Time.timeScale = 1;  // set the time scale to 1, to start the game world. This is needed if you restart the game from the game over menu
    }

    void Update()
    {
        if (isGameOver)
            return;

        totalTimeElapsed += Time.deltaTime;
        score = totalTimeElapsed * 100;
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            isGameOver = true;
        }
        if (score > difficulty)
        {
            difficulty += 1000f;
            PowerupScript.objectSpeed += -0.05f;
            ObstacleScript.objectSpeed += -0.05f;
            SpawnScript.spawnCycle *= 0.85f;
            SpawnScript2.spawnCycle *= 0.85f;

            if (walls.Length == 0 || grounds.Length == 0)
                return;

            // take a modulo with materials count so that animation repeats
            index = index % walls.Length;

            // assign it to the renderer
            wall1.GetComponent<Renderer>().material = walls[index];
            wall2.GetComponent<Renderer>().material = walls[index];
            ground.GetComponent<Renderer>().material = grounds[index];
            index++;
        }
    }

    public void PowerupCollected()
    {
        timeRemaining += timeExtension;
    }

    public void AlcoholCollected()
    {
        timeRemaining -= timeDeduction;
    }

    public void RockCollected()
    {
        timeRemaining -= rockDeduction;
    }

    void OnGUI()
    {
        //check if game is not over, if so, display the score and the time left
        if (!isGameOver)
        {
            GUI.Label(new Rect(10, 10, Screen.width / 5, Screen.height / 6), "TIME LEFT: " + ((int)timeRemaining).ToString());
            GUI.Label(new Rect(Screen.width - (Screen.width / 6), 10, Screen.width / 6, Screen.height / 6), "SCORE: " + ((int)score).ToString());
        }
        //if game over, display game over menu with score
        else
        {
            Time.timeScale = 0; //set the timescale to zero so as to stop the game world
                                //display the final score
            GUI.Box(new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2), "GAME OVER\nYOUR SCORE: " + (int)score);

            //restart the game on click
            if (GUI.Button(new Rect(Screen.width / 4 + 10, Screen.height / 4 + Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "RESTART"))
            {
                SceneManager.LoadScene("game");
            }

            //load the main menu, which as of now has not been created
            if (GUI.Button(new Rect(Screen.width / 4 + 10, Screen.height / 4 + 2 * Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "MAIN MENU"))
            {
                SceneManager.LoadScene("MainMenuScene");
            }

            //exit the game
            if (GUI.Button(new Rect(Screen.width / 4 + 10, Screen.height / 4 + 3 * Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "EXIT GAME"))
            {
                Application.Quit();
            }
        }
    }
}