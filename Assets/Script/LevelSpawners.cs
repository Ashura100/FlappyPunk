using Unity.VisualScripting;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject template;
    public GameObject templateEmpty;
    public GameObject SpawnTo;
    private float distanceTravelled = 0;
private void Start()
    {
        GameObject Spawned = Instantiate(templateEmpty, SpawnTo.transform);
        Spawned.transform.parent = transform;
        SpawnTo.transform.position += new Vector3(0, 0, -20);
        GameObject Spawned1 = Instantiate(templateEmpty, SpawnTo.transform);
        Spawned1.transform.parent = transform;
        SpawnTo.transform.position += new Vector3(0, 0, -20);
        GameObject Spawned2 = Instantiate(templateEmpty, SpawnTo.transform);
        Spawned2.transform.parent = transform;
        SpawnTo.transform.position += new Vector3(0, 0, -20);
    }
    private void Update()
    {
        transform.position += new Vector3(0, 0, 5 * Time.deltaTime);
        if (transform.position.z - distanceTravelled >= 20)
        {
            distanceTravelled = transform.position.z;
            GameObject Spawned = Instantiate(template, SpawnTo.transform);
            Spawned.transform.parent = transform;
        }

    }
}