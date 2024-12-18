using UnityEngine;

public class SpawnTube : MonoBehaviour
{
    public GameObject Tubes;
    public GameObject Spawner1;
    public GameObject Spawner2;
    private void Start()
    {
        float RandomFloat1 = Random.Range(10f, 30f);
        Spawner1.transform.position = new Vector3(Spawner1.transform.position.x, RandomFloat1, Spawner1.transform.position.z);
        Instantiate(Tubes, Spawner1.transform);
        float RandomFloat2 = Random.Range(10f, 30f);
        Spawner2.transform.position = new Vector3(Spawner2.transform.position.x, RandomFloat2, Spawner2.transform.position.z);
        Instantiate(Tubes, Spawner2.transform);
    }
}
