using UnityEngine;
using UnityEngine.UI;

public class MenuUIManager : MonoBehaviour {

    GameObject startMenuCanvas;
    GameObject insertNameCanvas;
    GameObject insertPasswordRankingCanvas;
    GameObject exitCanvas;
    GameObject howToPlayCanvas;

    public InputField nameInputField;
    public InputField passwordInputField;

    public Text textPasswordStatus;

    public void Awake()
    {
        startMenuCanvas = GameObject.Find("StartMenuCanvas");
        insertNameCanvas = GameObject.Find("InsertNameCanvas");
        exitCanvas = GameObject.Find("ExitCanvas");
        howToPlayCanvas = GameObject.Find("HowToPlayCanvas");
        insertPasswordRankingCanvas = GameObject.Find("PasswordRankingCanvas");

        startMenuCanvas.SetActive(true);
        insertNameCanvas.SetActive(false);
        insertPasswordRankingCanvas.SetActive(false);
        exitCanvas.SetActive(false);
        howToPlayCanvas.SetActive(false);
    }

    public void StartPasswordRankingCanvas()
    {
        startMenuCanvas.SetActive(false);
        passwordInputField.inputType = InputField.InputType.Password;
        insertPasswordRankingCanvas.SetActive(true);
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

    public void ShowRanking()
    {
        if (passwordInputField.text == GameConfig.password)
        {
            Application.LoadLevel("Ranking");
        } else
        {
            textPasswordStatus.text = "Senha incorreta! Tente novamente.";
        }
    }

    public void ExitClick()
    {
        exitCanvas.SetActive(true);
    }

    public void ExitCancelClick()
    {
        exitCanvas.SetActive(false);
    }

    public void HowToPlayClick(bool active)
    {
        howToPlayCanvas.SetActive(active);
    }

    public void ExitConfirmClick()
    {
        Application.Quit();
    }
}
