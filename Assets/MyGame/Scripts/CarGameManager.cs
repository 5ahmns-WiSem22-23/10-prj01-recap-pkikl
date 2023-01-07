using UnityEngine;

public class CarGameManager : MonoBehaviour
{
    [SerializeField]
    private float minRange;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private GameObject pickup;

    public static int objectCount;

    // Start is called before the first frame update
    void Start()
    {
            SpawnObject();
    }

    public void SpawnObject()
    {
        //Ein Objekt wird an einer zufälligen Stelle in der vorgegebenen Reichweite gespawnt 
        Instantiate(pickup, new Vector3(Random.Range(minRange, maxRange), Random.Range(minRange, maxRange), 0), Quaternion.identity);
    }
}
