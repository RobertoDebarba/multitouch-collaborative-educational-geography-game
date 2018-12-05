using UnityEngine;

[System.Serializable]
public class Group {

    public string name;
    public float timerDelta;
    
    public Group()
    {

    }

    public Group(string name, float timerDelta)
    {
        this.name = name;
        this.timerDelta = timerDelta;
    }

}
