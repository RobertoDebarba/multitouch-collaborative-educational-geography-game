using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using System;

public class RankingManager : MonoBehaviour
{

    public static string gameDataProjectFilePath = "/Resources/ranking.json";
    private static GameObject rankingObject;

    public Text rankingGeneralText;
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

    public static void addGroupToRank()
    {
        Group currentGroup = new Group(GameConfig.groupName, GameConfig.groupTimerDelta);
        Rank rank = getRank();
        
        if (rank != null)
        {
            List<Group> auxList = new List<Group>();
            List<Group> groupList = null;
            switch (GameConfig.difficulty)
            {
                case 1:
                    groupList = rank.easy;
                    break;
                case 2:
                    groupList = rank.medium;
                    break;
                case 3:
                    groupList = rank.hard;
                    break;
            }

            if (groupList.Count == 0)
            {
                auxList.Add(currentGroup);
            }
            else
            {
                for (int i = 0; i <= groupList.Count && auxList.Count < 3; i++)
                {
                    if (i == groupList.Count)
                    {
                        auxList.Add(currentGroup);
                    }
                    else
                    {
                        Group groupInPosition = groupList[i];
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

                }
            }

            groupList.Clear();
            groupList.AddRange(auxList);
            
            saveJSONFile(rank);
        }
    }

    void showRanking()
    {
        Rank rank = getRank();

        if (rank.easy.Count > 0)
        {
            rankingGeneralText.text += "Fácil\n";
            for (int i = 0; i < Math.Min(rank.easy.Count, 3); i++)
            {
                var group = rank.easy[i];
                rankingGeneralText.text += (i + 1) + "º Lugar - Equipe: " + group.name + " - Tempo: " + this.convertTime(group.timerDelta) + "\n";
            }
        }

        if (rank.medium.Count > 0)
        {
            rankingGeneralText.text += "\nMédio\n";
            for (int i = 0; i < Math.Min(rank.medium.Count, 3); i++)
            {
                var group = rank.medium[i];
                rankingGeneralText.text += (i + 1) + "º Lugar - Equipe: " + group.name + " - Tempo: " + this.convertTime(group.timerDelta) + "\n";
            }
        }

        if (rank.hard.Count > 0)
        {
            rankingGeneralText.text += "\nDifícil\n";
            for (int i = 0; i < Math.Min(rank.hard.Count, 3); i++)
            {
                var group = rank.hard[i];
                rankingGeneralText.text += (i + 1) + "º Lugar - Equipe: " + group.name + " - Tempo: " + this.convertTime(group.timerDelta) + "\n";
            }
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