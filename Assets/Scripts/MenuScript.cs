using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public Canvas quitMenu;
    public Canvas startMenu;
    public Canvas tutorialMenu;
    public Button startText;
    public Button exitText;

	// Use this for initialization
	void Start () {
        quitMenu = quitMenu.GetComponent<Canvas>();
        startText = startText.GetComponent<Button>();
        exitText = startText.GetComponent<Button>();
        tutorialMenu = tutorialMenu.GetComponent<Canvas>();
        startMenu = startMenu.GetComponent<Canvas>();
        quitMenu.enabled = false;
        tutorialMenu.enabled = false;
    }

    public void TutorialPressed()
    {
        startMenu.enabled = false;
        tutorialMenu.enabled = true;
    }

    public void OkayPressed()
    {
        startMenu.enabled = true;
        tutorialMenu.enabled = false;
    }

    public void ExitPress()
    {
        quitMenu.enabled = true;
        startText.enabled = false;
        exitText.enabled = false;
    }

    public void NoPresss()
    {
        quitMenu.enabled = false;
        startText.enabled = true;
        exitText.enabled = true;
    }

    public void StartLevel()
    {
        SceneManager.LoadScene("game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
