using UnityEngine;

public class CarGameManager : MonoBehaviour
{
    [SerializeField]
    private float minRange;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private GameObject pickup;


    // Start is called before the first frame update
    void Start()
    {
            SpawnObject();
    }

    public void SpawnObject()
    {
        Instantiate(pickup, new Vector3(Random.Range(minRange, maxRange), Random.Range(minRange, maxRange), 0), Quaternion.identity);
    }
}
