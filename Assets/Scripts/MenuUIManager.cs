using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TouchScript;
using TouchScript.Layers.UI;

public class MenuUIManager : MonoBehaviour {

    GameObject startMenuCanvas;
    GameObject insertNameCanvas;
    GameObject insertPasswordRankingCanvas;
    GameObject exitCanvas;
    GameObject howToPlayCanvas;
    Button rankingButton;
    TMP_InputField passwordField;
    Button playButton;
    TMP_InputField nameField;

    public Text textPasswordStatus;

    public void Awake()
    {
        startMenuCanvas = GameObject.Find("StartMenuCanvas");
        insertNameCanvas = GameObject.Find("InsertNameCanvas");
        exitCanvas = GameObject.Find("ExitCanvas");
        howToPlayCanvas = GameObject.Find("HowToPlayCanvas");
        insertPasswordRankingCanvas = GameObject.Find("PasswordRankingCanvas");
        rankingButton = GameObject.Find("RankingButton").GetComponent<Button>();
        passwordField = GameObject.Find("PasswordField").GetComponent<TMP_InputField>();
        playButton = GameObject.Find("PlayButton").GetComponent<Button>();
        nameField = GameObject.Find("NameField").GetComponent<TMP_InputField>();

        rankingButton.interactable = false;
        playButton.interactable = false;

        startMenuCanvas.SetActive(true);
        insertNameCanvas.SetActive(false);
        insertPasswordRankingCanvas.SetActive(false);
        exitCanvas.SetActive(false);
        howToPlayCanvas.SetActive(false);
    }

    public void StartPasswordRankingCanvas()
    {
        startMenuCanvas.SetActive(false);
        passwordField.inputType = TMP_InputField.InputType.Password;
        insertPasswordRankingCanvas.SetActive(true);
    }

    public void SelectLevel(int difficulty)
    {

        configureGameConfig(difficulty);

        startMenuCanvas.SetActive(false);
        insertNameCanvas.SetActive(true);
    }

    public static void configureGameConfig(int difficulty)
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
        GameConfig.groupName = nameField.text;
        Application.LoadLevel("Game");
    }

    public void ShowRanking()
    {
        if (passwordField.text == GameConfig.password)
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

    public void OnPasswordChanged()
    {
        if (passwordField.text == null || passwordField.text.Trim().Length == 0)
        {
            rankingButton.interactable = false;
        }
        else
        {
            rankingButton.interactable = true;
        }
    }

    public void OnNameChanged()
    {
        if (nameField.text == null || nameField.text.Trim().Length == 0)
        {
            playButton.interactable = false;
        }
        else
        {
            playButton.interactable = true;
        }
    }

    public void OpenKeyboard()
    {
        System.Diagnostics.Process.Start("osk.exe");
    }

    public void ClickBackFromPassword()
    {
        Application.LoadLevel("Menu");
    }
}
