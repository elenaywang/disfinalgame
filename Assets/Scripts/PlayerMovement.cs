using UnityEngine;
using UnityEngine.SceneManagement;


// CONTAINS CODE FROM: Wild Cockatiel Games https://youtu.be/qnr42UXQ0kc?si=pJbaleu7VR57bzBD

public class PlayerMovement : MonoBehaviour
{

    public float speed = 3; 

    // for determining which set of keys are used to control  movement
    public KeyCode inputLeft;

    Rigidbody2D rb2d;
    private PlayerEnergy pe;

    // for restricting player movement within the screen
    private Vector2 screenBounds;
    private float playerHalfWidth;
    private float playerHalfHeight;

    [Header("Animation")]
    public Sprite spriteSide;
    private SpriteRenderer _playerSR;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        pe = GetComponent<PlayerEnergy>();
        _playerSR = GetComponent<SpriteRenderer>();

        // for restricting player movement within the screen
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        playerHalfWidth = GetComponent<SpriteRenderer>().bounds.extents.x;
        playerHalfHeight = GetComponent<SpriteRenderer>().bounds.extents.y;
    }


    // Update is called once per frame
    void Update()
    {
        // player doesn't move if sleeping
        if (!pe.isAwake) {
            rb2d.linearVelocity = new Vector2(0, 0);
            return;
        }

        MovePlayer();

        // for restricting player movement within the screen
        float clampedX = Mathf.Clamp(transform.position.x, -screenBounds.x + playerHalfWidth, screenBounds.x - playerHalfWidth);
        float clampedY = Mathf.Clamp(transform.position.y, -screenBounds.y + playerHalfHeight, screenBounds.y - playerHalfHeight);
        Vector2 pos = transform.position;       // get player's current position
        pos.x = clampedX;                       // reassign x value to clamped x position
        pos.y = clampedY;                       // reassign y value to clamped y position
        transform.position = pos;               // reassign the clamped value back to the player
    }


    private void MovePlayer() {
        float inputX = 0;
        float inputY = 0;

        if (inputLeft == KeyCode.A) {
            if (Input.GetKey(KeyCode.A)) {
                inputX = -1;        // left
            }
            if (Input.GetKey(KeyCode.D)) {
                inputX = 1;         // right
            }
            if (Input.GetKey(KeyCode.W)) {
                inputY = 1;         // up
            }
            if (Input.GetKey(KeyCode.S)) {
                inputY = -1;        // down
            }
        } else if (inputLeft == KeyCode.LeftArrow) {
            if (Input.GetKey(KeyCode.LeftArrow)) {
                inputX = -1;        // left
            }
            if (Input.GetKey(KeyCode.RightArrow)) {
                inputX = 1;         // right
            }
            if (Input.GetKey(KeyCode.UpArrow)) {
                inputY = 1;         // up
            }
            if (Input.GetKey(KeyCode.DownArrow)) {
                inputY = -1;        // down
            }
        }

        Vector2 direction = new Vector2(inputX, inputY);
        if (direction.magnitude > 1) {
            direction.Normalize();
        }
        rb2d.linearVelocity = direction * speed;
    }
}
