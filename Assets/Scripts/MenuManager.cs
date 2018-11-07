using UnityEngine;

public class MenuManager : MonoBehaviour {

    GameObject startMenuCanvas;
    GameObject insertNameCanvas;
    int selectedDifficulty = 0;

    public void Awake()
    {
        startMenuCanvas = GameObject.Find("StartMenuCanvas");
        insertNameCanvas = GameObject.Find("InsertNameCanvas");

        startMenuCanvas.SetActive(true);
        insertNameCanvas.SetActive(false);
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

    public void ExitGame()
    {
        Application.Quit();
    }
}
