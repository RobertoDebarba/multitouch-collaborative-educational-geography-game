using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;


public class RankingManager : MonoBehaviour
{

    public static string gameDataProjectFilePath = "/Others/ranking.json";
    private static GameObject rankingObject;
    public Text rankingText;

    void Start()
    {
        rankingObject = GameObject.Find("_RANKING");
        rankingObject.SetActive(true);

        loadJSONFile();
        this.showRanking();
    }

    public static void addGroupToRank()
    {
        List<Group> tempList = new List<Group>();
        Group currentGroup = new Group(GameConfig.groupName, GameConfig.groupTimerDelta);
        List<Group> groups = new List<Group>();
        Rank rank = getRank();
        if (rank != null)
        {
            groups = new List<Group>(rank.groups);
        }
        if (groups.Count > 0)
        {
            groups.ForEach(group =>
            {
                if (group.timerDelta > currentGroup.timerDelta)
                {
                    tempList.Add(currentGroup);
                }
                tempList.Add(group);
            });
        } else
        {
            tempList.Add(currentGroup);
        }
        rank = new Rank(tempList.GetRange(0, 5).ToArray());
        saveJSONFile(rank);
    }

    void showRanking()
    {
        Rank rank = getRank();
        List<Group> groups = new List<Group>(rank.groups);
        int position = 0;
        groups.ForEach(group =>
        {
            rankingText.text += ++position + "º Lugar - Equipe: " + group.name + " - Tempo: " + this.convertTime(group.timerDelta);
        });
    }

    static Rank getRank()
    {
        Rank rank = new Rank();
        string rankJSON = loadJSONFile();
        if (rankJSON != null)
        {
            rank = JsonUtility.FromJson<Rank>(rankJSON);
        }
        return rank;
    }

    public void backMenu()
    {
        Application.LoadLevel("Menu");
    }

    static string loadJSONFile()
    {
        string filePath = Application.dataPath + gameDataProjectFilePath;
        if (File.Exists(filePath))
        {
            return File.ReadAllText(filePath);
        }
        return null;
    }

    static void saveJSONFile(Rank rank)
    {
        string dataAsJson = JsonUtility.ToJson(rank, true);
        string filePath = Application.dataPath + gameDataProjectFilePath;
        File.WriteAllText(filePath, dataAsJson);
    }

    string convertTime(float timerDelta)
    {
        int seconds = (int)(timerDelta % 60);
        int minutes = (int)(timerDelta / 60);
        return (minutes < 10 ? "0" : "") + minutes + ":" + (seconds < 10 ? "0" : "") + seconds;
    }

}