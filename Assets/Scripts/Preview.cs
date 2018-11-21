using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Preview : MonoBehaviour {

    public static GameObject previewObject;
    private static GameObject canvasObject;
    private static GameObject statesObject;
    private static Text previewTimeText;

    private static float timerDelta = 0;
    
    // Use this for initialization
    void Start () {
        previewObject = GameObject.Find("_PREVIEW");
        canvasObject = GameObject.Find("Canvas");
        statesObject = GameObject.Find("States");
        previewTimeText = GameObject.Find("PreviewTimeText").GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        timerDelta += Time.deltaTime;

        previewTimeText.text = GetRemainingTimeString();
    }

    public IEnumerator ShowPreview()
    {
        timerDelta = 0;

        canvasObject.SetActive(false);
        statesObject.SetActive(false);
        previewObject.SetActive(true);

        yield return LoadInterval();

        canvasObject.SetActive(true);
        statesObject.SetActive(true);
        previewObject.SetActive(false);
    }

    private IEnumerator LoadInterval()
    {

        yield return new WaitForSeconds(GameConfig.previewTimeInSeconds);

    }

    private string GetRemainingTimeString()
    {
        int totalSeconds = GameConfig.previewTimeInSeconds;

        int elapsedSeconds = (int)(timerDelta % 60);
        int remainingSeconds = totalSeconds - elapsedSeconds;

        return "00:" + (remainingSeconds < 10 ? "0" : "") + remainingSeconds;
    }


}
