using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{

    public float speed = 3; 

    public KeyCode inputLeft;

    Rigidbody2D rb2d;
    private PlayerEnergy pe;

    [Header("Animation")]
    public Sprite spriteSide;
    private SpriteRenderer _playerSR;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        pe = GetComponent<PlayerEnergy>();
        _playerSR = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {
        if (!pe.isAwake) return;           // player doesn't move if sleeping

        MovePlayer();
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
