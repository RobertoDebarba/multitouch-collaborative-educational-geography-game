using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUIManager : MonoBehaviour {

    private static GameObject collisionParent;
    private static GameObject stateParent;
    private static GameObject foundParent;
    private static GameObject endParent;
    private static GameObject backCanvas;
    private static GameObject backButton;
    private static GameObject helpButton;

    Preview preview;

    public Text foundText;
    public Text timerText;
    public GameObject endObject;
    public Text finalTimeText;
    public GameObject[] hidePanelsOnEnd;

    int found = 0;
    const int max = 26;
    float timerDelta = 0;
    bool finishedGame = false;
    bool startedGame = false;

    public void StartTimer()
    {
        startedGame = true;
    }

    public void Start()
    {
        preview = new Preview();

        if (stateParent == null) {
            stateParent = GameObject.Find("States");
        }

        if (collisionParent == null)
        {
            collisionParent = GameObject.Find("Collision");
        }

        if (foundParent == null)
        {
            foundParent = GameObject.Find("_FOUND");
        }

        if (endParent == null)
        {
            endParent = GameObject.Find("_END");
        }

        if (backCanvas == null)
        {
            backCanvas = GameObject.Find("BackCanvas");
        }

        if (helpButton == null)
        {
            helpButton = GameObject.Find("HelpButton");
        }

        if (backButton == null)
        {
            backButton = GameObject.Find("BackButton");
        }

        if (backCanvas != null && endParent != null)
        {
            backCanvas.SetActive(false);
            endParent.SetActive(false);
        }
    }

    void UpdateText()
    {
        foundText.text = "Estados encontrados: " + found;
        timerText.text = "Tempo: " + GetTime();
    }

    string GetTime()
    {
        int seconds = (int)(timerDelta % 60);
        int minutes = (int)(timerDelta / 60);
        return (minutes < 10 ? "0" : "") + minutes + ":" + (seconds < 10 ? "0" : "") + seconds;
    }

    public void ReleasedPiece(State stateSnap)
    {
        var stateObj = stateParent.transform.Find(stateSnap.Name);
        var stateCollider = stateObj.gameObject.GetComponent<CircleCollider2D>();

        var collisionObj = collisionParent.transform.Find(stateSnap.Name);
        if (collisionObj == null)
            return;

        var collisionCollider = collisionObj.gameObject.GetComponent<CircleCollider2D>();
        if (collisionCollider == null)
            return;

        var colliding = new Collider2D[10];
        var returns = collisionCollider.OverlapCollider(new ContactFilter2D(), colliding);
        for (int i = 0; i < returns; i++)
        {
            if (colliding[i] == stateCollider)
            {
                var snap = stateObj.GetComponent<State>();
                stateObj.transform.position = new Vector3(snap.X, snap.Y, stateObj.transform.position.z);
                stateObj.GetComponent<PolygonCollider2D>().enabled = false;
                stateObj.GetComponent<CircleCollider2D>().enabled = false;

                stateObj.SetParent(foundParent.transform, false);

                found++;

                if (found >= max)
                {
                    EndGame();
                }

                break;
            }
        }
    }

    void EndGame()
    {
        timerText.enabled = false;
        finishedGame = true;
        finalTimeText.text = "Tempo final: " + GetTime();
        endObject.SetActive(true);

        helpButton.SetActive(false);
        backButton.SetActive(false);

        foreach (var obj in hidePanelsOnEnd)
        {
            Debug.Log(obj);
            obj.SetActive(false);
        }
    }

    public void Update()
    {
        if (startedGame && !finishedGame)
        {
            UpdateText();
            timerDelta += Time.deltaTime;
        }
    }

    public void BackClick()
    {
        backCanvas.SetActive(true);
    }

    public void BackCancelClick()
    {
        backCanvas.SetActive(false);
    }

    public void BackConfirmClick()
    {
        Application.LoadLevel("Menu");
    }

    public void PlayAgainClick()
    {
        Application.LoadLevel("Game");
    }

    public void MenuClick()
    {
        Application.LoadLevel("Menu");
    }

    public void PreviewClick()
    {
        StartCoroutine(preview.ShowPreview());
    }
}
