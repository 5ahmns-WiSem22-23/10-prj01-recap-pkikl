using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;

    [SerializeField]
    CarGameManager game;

    [SerializeField]
    float velocity;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }
    
    private void FixedUpdate()
    {
        //Es wird auf das vordefinierte InputSystem zugegriffen und die horizontale und vertikale Achsen werden für die Bewegung des Autos verwendet. Die Velocity Variable verändert den Speed Faktor.//
        transform.Rotate(0, 0, -Input.GetAxis("Horizontal")*(velocity/2));
        rigid.velocity = transform.rotation * new Vector2(0, Input.GetAxis("Vertical") * (velocity / 2));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Wenn das Objekt aufgesammelt wird, wird das Objekt zerstört und ein neues erstellt
        if(collision.CompareTag("Pickup"))
        {
            game.SpawnObject();
            Destroy(collision.gameObject);
        }

        else if (collision.CompareTag("Goal"))
        {

        }
    }
}
