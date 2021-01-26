using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public bool gameIsEnded = false;

    [SerializeField] private GameObject reloadMenu;
    PlayerController Player = FindObjectOfType<PlayerController>();
    public void GameOver() {

        if (gameIsEnded == false){
            Debug.Log("GAME OVER");
            gameIsEnded = true;
            reloadMenu.SetActive(true);
            /*Restart();*/
        }
    }

    public void Restart() {
        reloadMenu.SetActive(false);
        SceneManager.LoadScene("level01");
        Player.totalCoins = 0;
    }
}