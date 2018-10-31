using UnityEngine;

public class Menu : MonoBehaviour {

    public void SelectLevel(int level)
    {
        Application.LoadLevel(level);
    }
}
