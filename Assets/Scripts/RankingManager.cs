using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;


public class RankingManager : MonoBehaviour
{

    public static string gameDataProjectFilePath = "/Resources/ranking.json";
    private static GameObject rankingObject;

    public Text rankingTextFirst;
    public Text rankingTextSecond; 
    public Text rankingTextThird;
    public Text rankingTextFourFourth;
    public Text rankingTextFifth;

    void Start()
    {
        rankingObject = GameObject.Find("_RANKING");
        rankingObject.SetActive(true);

        loadJSONFile();
        this.showRanking();
    }

    public static void addGroupToRank()     {         Group currentGroup = new Group(GameConfig.groupName, GameConfig.groupTimerDelta);         Rank rank = getRank();         List<Group> auxList = new List<Group>();         if (rank != null)         {             if (rank.groups.Count == 0)
            {                 auxList.Add(currentGroup);             }
            else
            {                 for (int i = 0; i <= rank.groups.Count && auxList.Count < 5; i++)                 {
                    if (i == rank.groups.Count)
                    {
                        auxList.Add(currentGroup);
                    }
                    else
                    {
                        Group groupInPosition = rank.groups[i];
                        if (currentGroup.timerDelta < groupInPosition.timerDelta)
                        {
                            Group aux = groupInPosition;
                            auxList.Add(currentGroup);
                            currentGroup = aux;
                        }
                        else
                        {
                            auxList.Add(groupInPosition);
                        }
                    }

                }             }          }         rank.groups = auxList;         saveJSONFile(rank);     }

    void showRanking()
    {
        Rank rank = getRank();
        if(rank.groups.Count >= 1)
        {
            rankingTextFirst.text += "1º Lugar - Equipe: " + rank.groups[0].name + " - Tempo: " + this.convertTime(rank.groups[0].timerDelta);
        }
        if (rank.groups.Count >= 2)
        {
            rankingTextSecond.text += "2º Lugar - Equipe: " + rank.groups[1].name + " - Tempo: " + this.convertTime(rank.groups[1].timerDelta);
        }
        if (rank.groups.Count >= 3)
        {
            rankingTextThird.text += "3º Lugar - Equipe: " + rank.groups[2].name + " - Tempo: " + this.convertTime(rank.groups[2].timerDelta);
        }
        if (rank.groups.Count >= 4)
        {
            rankingTextFourFourth.text += "4º Lugar - Equipe: " + rank.groups[3].name + " - Tempo: " + this.convertTime(rank.groups[3].timerDelta);
        }
        if (rank.groups.Count == 5)
        {
            rankingTextFifth.text += "5º Lugar - Equipe: " + rank.groups[4].name + " - Tempo: " + this.convertTime(rank.groups[4].timerDelta);
        }
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