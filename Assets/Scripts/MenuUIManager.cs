using UnityEngine;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour {

    GameObject startMenuCanvas;
    GameObject insertNameCanvas;
    GameObject exitCanvas;

    public InputField nameInputField;

    public void Awake()
    {
        startMenuCanvas = GameObject.Find("StartMenuCanvas");
        insertNameCanvas = GameObject.Find("InsertNameCanvas");
        exitCanvas = GameObject.Find("ExitCanvas");

        startMenuCanvas.SetActive(true);
        insertNameCanvas.SetActive(false);
        exitCanvas.SetActive(false);
    }

    public void SelectLevel(int difficulty)
    {

        configureGameConfig(difficulty);

        startMenuCanvas.SetActive(false);
        insertNameCanvas.SetActive(true);
    }

    private void configureGameConfig(int difficulty)
    {
        print(difficulty);
        GameConfig.difficulty = difficulty;
        GameConfig.countOfPreviews = 0;
        if (difficulty == 1)
        {
            GameConfig.previewLimit = 3;
            GameConfig.previewTimeInSeconds = 7;
        }
        else if (difficulty == 2)
        {
            GameConfig.previewLimit = 2;
            GameConfig.previewTimeInSeconds = 5;
        }
        else
        {
            GameConfig.previewLimit = 1;
            GameConfig.previewTimeInSeconds = 3;
        }
    }

    public void StartGame()
    {
        GameConfig.groupName = nameInputField.text;
        Application.LoadLevel("Game");
    }

    public void ExitClick()
    {
        exitCanvas.SetActive(true);
    }

    public void ExitCancelClick()
    {
        exitCanvas.SetActive(false);
    }

    public void ExitConfirmClick()
    {
        Application.Quit();
    }
}
