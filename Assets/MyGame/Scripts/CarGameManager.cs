using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CarGameManager : MonoBehaviour
{
    [SerializeField]
    private float minRange;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private GameObject pickup;
    [SerializeField]
    private Text pickupCountCanvas;
    [SerializeField]
    private Text timerCanvas;

    public static int objectCount;

    private float timer;

    [SerializeField]
    private float maxTime;

    // Start is called before the first frame update
    void Start()
    {
        SpawnObject();
    }

    private void Update()
    {
        // Es läuft ein Timer mit
        timer += Time.deltaTime;

        timerCanvas.text = "Du hast noch " + Mathf.Round(maxTime - timer).ToString() + " Sekunden!";

        // Der PickupWert wird in UI Text umbenannt
        pickupCountCanvas.text = "Dein Score ist: " + objectCount.ToString();

        if(timer >= maxTime)
        {
            SceneManager.LoadScene(0);
            objectCount = 0;
        }
    }

    public void SpawnObject()
    {
        //Ein Objekt wird an einer zufälligen Stelle in der vorgegebenen Reichweite gespawnt 
        Instantiate(pickup, new Vector3(Random.Range(minRange, maxRange), Random.Range(minRange, maxRange), 0), Quaternion.identity);
    }
}
