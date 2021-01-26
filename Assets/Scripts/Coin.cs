using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private PlayerController Player;
    public bool isCollected = false;
    public bool isSetPosition = false;
    private int position;

    List<PlayerStep> playerSteps = new List<PlayerStep>(); 


    private void Start() {
        Player = FindObjectOfType<PlayerController>();
    }

    private void Update() {

        if (isCollected) {
            if (!isSetPosition) {
                isSetPosition = true;
                position = Player.totalCoins;
            }

            Debug.Log("<color=red>Z position </color>"+ (int)Player.transform.position.z);
            playerSteps.Add(new PlayerStep((float)Player.transform.position.x, (int) Player.transform.position.z) ); 
            
            if ( playerSteps.Find((x) => x.posZ == (int)Player.transform.position.z - position).posZ == (int)  transform.position.z ) {
                float newXposition = playerSteps.Find((x) => x.posZ == (int)Player.transform.position.z - position).posX;
                transform.position = new Vector3( newXposition, Player.transform.position.y, Player.transform.position.z - position);
            }
            else{
                transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, (Player.transform.position.z - position) );
            }
        }
    }

    public void OnTriggerEnter(Collider other){
        PlayerController _player = other.GetComponent<PlayerController>();
       
        if(_player != null){
            _player.collectCoin();
        }

        Destroy(this.gameObject);
    }
}
