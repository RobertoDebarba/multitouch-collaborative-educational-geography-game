using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class Init : MonoBehaviour {

    GameObject masterObject;
    GameObject spawnObject;

    GameObject statesParent;
    GameObject collisionParent;

    Preview preview;

    public GameObject statePrefab;
    public GameObject collisionPrefab;

    List<State> stateSnaps = new List<State>()
    {
        new State("AC", -4.16f, 1.47f),
        new State("AM", -2.6f, 2.92f),
        new State("SC", 1.18f, -3.76f),
        new State("RS", 0.49f, -4.5f),
        new State("PR", 1.16f, -2.9f),
        new State("SP", 1.9f, -2.3f),
        new State("MT", -0.14f, 0.41f),
        new State("RO", -2.18f, 0.97f),
        new State("PA", 0.83f, 2.97f),
        new State("MA", 2.84f, 2.34f),
        new State("TO", 1.97f, 1.36f),
        new State("PI", 3.4f, 2.09f),
        new State("GO", 1.65f, -0.5f),
        new State("MS", 0.26f, -1.73f),
        new State("MG", 2.71f, -1.22f),
        new State("RJ", 3.51f, -2.11f),
        new State("ES", 4.04f, -1.45f),
        new State("BA", 3.76f, 0.26f),
        new State("AL", 5.2f, 1.36f),
        new State("RR", -1.73f, 4.52f),
        new State("CE", 4.5f, 2.5f),
        new State("AP", 0.83f, 4.4f),
        new State("PB", 5.16f, 2.05f),
        new State("PE", 4.86f, 1.68f),
        new State("SE", 5.04f, 1.04f),
        new State("RN", 5.18f, 2.37f),
    };
    
    public void Awake()
    {
        masterObject = GameObject.Find("_MASTER");
        spawnObject = GameObject.Find("_SPAWN");
        statesParent = GameObject.Find("States");
        collisionParent = GameObject.Find("Collision");

        preview = new Preview();
    }

    public void Start()
    {
        startGame();
    }
    

    Vector3 ObtainSpawnPosition()
    {
        var collider = spawnObject.GetComponent<PolygonCollider2D>();
        do
        {
            var rX = Random.Range(-25, 25);
            var rY = Random.Range(-10, 10);

            var vector = new Vector3(rX, rY, 0);
            if (collider.OverlapPoint(vector))
            {
                return vector;
            }
        } while (true);
    }

    public void loadGame() {
        var snapManager = masterObject.GetComponent<GameUIManager>();

        for (int i = 0; i < stateSnaps.Count; i++)
        {
            var state = stateSnaps[i];

            var stateObject = Instantiate(statePrefab);
            stateObject.name = state.Name;

            var sprite = Resources.Load<Sprite>(state.Name);

            var collisionObject = Instantiate(collisionPrefab);
            collisionObject.GetComponent<SpriteRenderer>().sprite = sprite;
            collisionObject.AddComponent<PolygonCollider2D>();
            collisionObject.AddComponent<CircleCollider2D>();
            collisionObject.GetComponent<CircleCollider2D>().radius = 0.15f;
            collisionObject.GetComponent<SpriteRenderer>().enabled = false;
            collisionObject.name = state.Name;
            collisionObject.transform.parent = collisionParent.transform;
            collisionObject.transform.localPosition = new Vector3(state.X, state.Y, 0);

            var gestureEvent = new Gesture.GestureEvent();
            stateObject.GetComponent<ReleaseGesture>().OnRelease = gestureEvent;

            var snap = stateObject.GetComponent<State>();
            snap.Name = state.Name;
            snap.X = state.X;
            snap.Y = state.Y;

            stateObject.GetComponent<SpriteRenderer>().sprite = sprite;
            stateObject.transform.localPosition = ObtainSpawnPosition();
            stateObject.AddComponent<PolygonCollider2D>();
            stateObject.AddComponent<CircleCollider2D>();
            stateObject.GetComponent<CircleCollider2D>().radius = 0.15f;
            gestureEvent.AddListener((gesture) =>
            {
                snapManager.ReleasedPiece(gesture.gameObject.GetComponent<State>());
            });
            stateObject.transform.parent = statesParent.transform;
        }

        Destroy(spawnObject);

        snapManager.StartTimer();
    }

    public void startGame() {
        StartCoroutine(showPreview());
    }

    public IEnumerator showPreview(bool shouldLoadGame = true) {
        yield return preview.ShowPreview();

        if (shouldLoadGame)
            loadGame();
    }


    public void Close()
    {
        Application.Quit();
    }
}
