using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class Init : MonoBehaviour {

    GameObject masterObject;
    GameObject spawnObject;

    GameObject statesParent;
    GameObject collisionParent;

    public GameObject statePrefab;
    public GameObject collisionPrefab;

    List<StateSnap> stateSnaps = new List<StateSnap>()
    {
        new StateSnap("AC", -4.16f, 1.47f),
        new StateSnap("AM", -2.6f, 2.92f),
        new StateSnap("SC", 1.17f, -3.76f),
        new StateSnap("RS", 0.46f, -4.5f),
        new StateSnap("PR", 1.18f, -2.9f),
        new StateSnap("SP", 1.93f, -2.3f),
        new StateSnap("MT", -0.12f, 0.4f),
        new StateSnap("RO", -2.16f, 0.97f),
        new StateSnap("PA", 0.83f, 2.94f),
        new StateSnap("MA", 2.84f, 2.34f),
        new StateSnap("TO", 1.97f, 1.36f),
        new StateSnap("PI", 3.4f, 2.09f),
        new StateSnap("GO", 1.65f, -0.5f),
        new StateSnap("MS", 0.28f, -1.75f),
        new StateSnap("MG", 2.71f, -1.22f),
        new StateSnap("RJ", 3.51f, -2.11f),
        new StateSnap("ES", 4.04f, -1.45f),
        new StateSnap("BA", 3.76f, 0.26f),
        new StateSnap("AL", 5.2f, 1.36f),
        new StateSnap("RR", -1.73f, 4.52f),
        new StateSnap("CE", 4.5f, 2.5f),
        new StateSnap("AP", 0.83f, 4.38f),
        new StateSnap("PB", 5.16f, 2.05f),
        new StateSnap("PE", 4.86f, 1.68f),
        new StateSnap("SE", 5.04f, 1.04f),
        new StateSnap("RN", 5.18f, 2.37f),
    };
    
    public void Awake()
    {
        masterObject = GameObject.Find("_MASTER");
        spawnObject = GameObject.Find("_SPAWN");
        statesParent = GameObject.Find("States");
        collisionParent = GameObject.Find("Collision");
    }

    public void Start()
    {
        var snapManager = masterObject.GetComponent<SnapManager>();

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

            var snap = stateObject.GetComponent<StateSnap>();
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
                snapManager.ReleasedPiece(gesture.gameObject.GetComponent<StateSnap>());
            });
            stateObject.transform.parent = statesParent.transform;
        }

        Destroy(spawnObject);
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

    public void Close()
    {
        Application.Quit();
    }
}
