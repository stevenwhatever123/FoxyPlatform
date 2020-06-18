using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

/*
* This Scripts controls the overall game state to check
* if the player has died, update the time/score and restart the game.
*/
public class GameController : MonoBehaviour
{
    // Component Reference
    public Transform player;
    public GameObject gameOverController;
    public GameObject cinemachine;
    public Ads ads;

    // Game start time
    public float gameTime;
    // Float variable to hold the timer
    private float timer;
    // Additional time added if the player completes his/hers objectives
    public float additionalTime;
    // The game ends if the player falls to a certain height
    public float failHeight;
    // Boolean to hold if the game is over or not
    private bool gameOver;
    // The player initial y-axis position
    private float playerInitialYPos;
    // Integer to hold the score
    private int score = 0;
    // Array list to hold the stepped platform to prevent the player from jumping the 
    // same platform again and again to gain score and additional time
    public ArrayList steppedPlatform = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        timer = gameTime + 1;
        playerInitialYPos = player.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        countDown();
        checkTime();
        checkPlayerYPosition();
    }

    // Check the player's position if he/she is below the fail height
    // If true, the game is over
    void checkPlayerYPosition(){
        if(player.transform.position.y < failHeight){
            GameOver();
        }
    }

    // Update time counter
    void checkTime(){
        if(timer < 0){
            GameOver();
        }
    }

    // Count down every second
    void countDown(){
        if(!gameOver){
            timer -= Time.deltaTime;
            int temp = (int) timer;
        }
    }

    // Gameover state
    // It enables the  game over UI and disable the cinemachine camera
    public void GameOver(){
        print("Game Over");
        gameOver = true;
        gameOverController.gameObject.SetActive(true);
        cinemachine.SetActive(false);
    }

    // Add additional time
    public void addTime(){
        timer += additionalTime;
    }

    // Gets the timer
    public float getTime(){
        return this.timer;
    }

    // Gets the timer in integer
    public int getTimeInt(){
        return (int) this.timer;
    }

    // Gets if the game is over or not
    public bool isGameOver(){
        return gameOver;
    }

    // Methods to add the score
    public void addScore(int i){
        score += i;
    }

    // Gets the score
    public int getScore(){
        return this.score;
    }

    // Gets the array list of stepped platform
    public ArrayList getSteppedPlatform(){
        return steppedPlatform;
    }

    // Restarts the game
    public void Restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
