using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public string gameLevel;
    public string optionsLevel;

    private void OnGUI()
    {

        GUI.Box(new Rect(Screen.width / 4, Screen.height / 4, Screen.width / 2, Screen.height / 2), "MAIN MENU");

        if (GUI.Button(new Rect(Screen.width / 4 + 10, Screen.height / 4 + Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "PLAY"))
        {
            string test = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene("game");
        }

        if (GUI.Button(new Rect(Screen.width / 4 + 10, Screen.height / 4 + 2 * Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "OPTIONS"))
        {
            SceneManager.LoadScene(optionsLevel);
        }

        if (GUI.Button(new Rect(Screen.width / 4 + 10, Screen.height / 4 + 3 * Screen.height / 10 + 10, Screen.width / 2 - 20, Screen.height / 10), "EXIT"))
        {
            Application.Quit();
        }
    }
}
