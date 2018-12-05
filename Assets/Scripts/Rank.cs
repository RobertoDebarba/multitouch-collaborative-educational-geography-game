using System.Collections.Generic;

[System.Serializable]
public class Rank {

    public List<Group> groups;

    public Rank()
    {
        this.groups = new List<Group>();
    }

    public Rank(List<Group> groups)
    {
        this.groups = groups;
    }

}
