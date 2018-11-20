using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;


public class RankingManager : MonoBehaviour
{

    public static string gameDataProjectFilePath = "/Others/ranking.json";
    private static GameObject rankingObject;
    private static Text rankingText;

    void Start()
    {
        rankingObject = GameObject.Find("_RANKING");
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
        int count = 0;
        if (groups.Count > 0)
        {
            groups.ForEach(group =>
            {
                if (count < 5)
                {
                    if (currentGroup.timerDelta < group.timerDelta)
                    {
                        tempList.Add(currentGroup);
                        currentGroup = group;
                    }
                    else
                    {
                        tempList.Add(group);
                    }
                    count++;
                }
            });
        } else
        {
            tempList.Add(currentGroup);
        }
        rank = new Rank(tempList.ToArray());
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
        return null;
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
        Debug.Log("teste" + dataAsJson);
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