using UnityEngine;

public class MeteorSpawner : MonoBehaviour
{
    public GameObject MeteorPrefab;
    public int SpawnLimit;
    public float SpawnIntervalSeconds;
    
    private float _elapsed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Spawner: Init");
    }

    // Update is called once per frame
    void Update()
    {
        _elapsed += Time.deltaTime;
        if (_elapsed >= SpawnIntervalSeconds)
        {
            if (transform.childCount < SpawnLimit)
            {
                Spawn();
            } else
            {
                //Debug.Log("Spawner: spawn limit reached");
            }

            _elapsed = 0.0f;
        }
    }

    public void Spawn()
    {
        var meteor = Instantiate(MeteorPrefab);
        meteor.transform.parent = this.gameObject.transform;
        //Debug.Log("Spawner: Spawned " + transform.childCount);
    }
}
