using System.Collections.Generic;

[System.Serializable]
public class Rank {

    public List<Group> easy;
    public List<Group> medium;
    public List<Group> hard;

    public Rank()
    {
        this.easy = new List<Group>();
        this.medium = new List<Group>();
        this.hard = new List<Group>();
    }

    public Rank(List<Group> easy, List<Group> medium, List<Group> hard)
    {
        this.easy = easy;
        this.medium = medium;
        this.hard = hard;
    }
}
