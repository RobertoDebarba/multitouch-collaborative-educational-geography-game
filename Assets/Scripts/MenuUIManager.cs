using UnityEngine;

public class MenuUIManager : MonoBehaviour {

    GameObject startMenuCanvas;
    GameObject insertNameCanvas;
    GameObject exitCanvas;

    int selectedDifficulty = 0;

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
        selectedDifficulty = difficulty;

        startMenuCanvas.SetActive(false);
        insertNameCanvas.SetActive(true);
    }

    public void StartGame()
    {
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
