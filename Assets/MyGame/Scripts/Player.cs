using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigid;
    private SpriteRenderer spriteRen;

    private bool holdingPickup;

    [SerializeField]
    private CarGameManager game;

    [SerializeField]
    private Sprite baseSprite;

    [SerializeField]
    private Sprite holdingSprite;

    [SerializeField]
    private float velocity;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRen = GetComponent<SpriteRenderer>();

        spriteRen.sprite = baseSprite;
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
            spriteRen.sprite = holdingSprite;
            Destroy(collision.gameObject);
            holdingPickup = true;
        }

        else if (collision.CompareTag("Goal") && holdingPickup)
        {
            //Wenn man ein Objekt mit dem Goal Tag aufsammelt wird das Sprite des Players geändert und der Countwert wird erhöht
            spriteRen.sprite = baseSprite;
            game.SpawnObject();
            CarGameManager.objectCount++;
            holdingPickup = false;
        }
    }
}
