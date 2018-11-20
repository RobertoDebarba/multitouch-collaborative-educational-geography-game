using System.Collections.Generic;

[System.Serializable]
public class Rank {

    public Group[] groups;

    public Rank()
    {
        this.groups = new Group[5];
    }

    public Rank(Group[] groups)
    {
        this.groups = groups;
    }

}
