using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Coin _coin;

    public int totalCoins = 0;

    private float speed = 6.0f;
    public float gravity = -9.8f;
    private CharacterController _charController;
    private bool gameIsEnded;
    private ObstacleController obstacle;

    void Start() {
        _charController = GetComponent<CharacterController>();
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
        obstacle  = hit.gameObject.GetComponent<ObstacleController>();
        if(obstacle != null) {
            Debug.Log("<color=green>Player Collision</color>");
            FindObjectOfType<GameManager>().GameOver();
        }
    }

    void Update() {
        gameIsEnded = FindObjectOfType<GameManager>().gameIsEnded;

        if (gameIsEnded == false){
            float deltaX = Input.GetAxis("Horizontal") * speed;

            Vector3 movement = new Vector3(deltaX, gravity, speed);

            movement *= Time.deltaTime;

            movement = transform.TransformDirection(movement);
            _charController.Move(movement);
        }
    }

    public void collectCoin() {
        AddCoin();

        totalCoins += 1;
        Debug.Log(totalCoins);

        if (totalCoins == 3 || totalCoins % 50 == 0) {
            increaseSpeed();
        }

        Debug.Log("<color=green>Coins </color>" + totalCoins);
    }

    private void increaseSpeed() {
        speed += 2;
        Debug.Log("Speed increased: "+ speed);
    }

    public void AddCoin() {
        Coin newCoin = Instantiate(_coin) as Coin;
        newCoin.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);

        newCoin.isCollected = true;
    }
}