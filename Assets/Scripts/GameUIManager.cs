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
    private static GameObject statesInfo;

    Preview preview;

    public Text foundText;
    public Text timerText;
    public GameObject endObject;
    public Text finalTimeText;
    public Text previewText;
    public GameObject[] hidePanelsOnEnd;
    public Text backButtonText;

    int found = 0;
    const int max = 26;
    float timerDelta = 0;
    bool finishedGame = false;
    bool startedGame = false;
    bool infosModeGame = false;

    Dictionary<string, string> statesUrls = new Dictionary<string, string>();

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

        loadStatesUrl();

    }

    void loadStatesUrl()
    {
        statesUrls.Add("AC", StatesUrl.AC);
        statesUrls.Add("AM", StatesUrl.AM);
        statesUrls.Add("SC", StatesUrl.SC);
        statesUrls.Add("RS", StatesUrl.RS);
        statesUrls.Add("PR", StatesUrl.PR);
        statesUrls.Add("SP", StatesUrl.SP);
        statesUrls.Add("MT", StatesUrl.MT);
        statesUrls.Add("RO", StatesUrl.RO);
        statesUrls.Add("PA", StatesUrl.PA);
        statesUrls.Add("MA", StatesUrl.MA);
        statesUrls.Add("TO", StatesUrl.TO);
        statesUrls.Add("PI", StatesUrl.PI);
        statesUrls.Add("GO", StatesUrl.GO);
        statesUrls.Add("MS", StatesUrl.MS);
        statesUrls.Add("MG", StatesUrl.MG);
        statesUrls.Add("RJ", StatesUrl.RJ);
        statesUrls.Add("ES", StatesUrl.ES);
        statesUrls.Add("BA", StatesUrl.BA);
        statesUrls.Add("AL", StatesUrl.AL);
        statesUrls.Add("RR", StatesUrl.RR);
        statesUrls.Add("CE", StatesUrl.CE);
        statesUrls.Add("AP", StatesUrl.AP);
        statesUrls.Add("PB", StatesUrl.PB);
        statesUrls.Add("PE", StatesUrl.PE);
        statesUrls.Add("SE", StatesUrl.SE);
        statesUrls.Add("RN", StatesUrl.RN);
    }

    void UpdateText()
    {
        foundText.text = "Estados encontrados: " + found;
        timerText.text = "Tempo: " + GetTime();
        previewText.text = "AJUDA (" + (GameConfig.previewLimit - GameConfig.countOfPreviews).ToString() + ")";
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

    public void openUrl(string url)
    {
        if (infosModeGame)
        {
            Application.OpenURL(url);
        }
    }

    public void Update()
    {
        if (infosModeGame)
        {
            // Input.touches.Any(x=>x.phase==TouchPhase.Began)
            if (Input.GetMouseButtonDown(0))
            {
                Camera cam = Camera.main;
                Vector2 origin = Vector2.zero;
                Vector2 dir = Vector2.zero;
                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(origin, dir);
                if (hit)
                {
                    string url = statesUrls[hit.collider.name];
                    openUrl(url);
                }
            }
        }

        if (startedGame && !finishedGame)
        {
            UpdateText();
            timerDelta += Time.deltaTime;
        }
    }

    public void BackClick()
    {
        if (infosModeGame)
        {
            BackConfirmClick();
        } else
        {
            backCanvas.SetActive(true);
        }
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

    public void infosModeClick()
    {
        infosModeGame = true;
        endObject.SetActive(false);
        backButton.SetActive(true);
        backButtonText.text = "VOLTAR PARA O MENU";
    }

    public void PreviewClick()
    {
        if (GameConfig.countOfPreviews < GameConfig.previewLimit)
        {
            GameConfig.countOfPreviews++;
            StartCoroutine(preview.ShowPreview());
        }
    }
}
