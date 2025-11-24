using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// This script sets up window coordinates and sets up game over variables
// and background music for game level scene

public class GameStart : MonoBehaviour
{
    public int width = 1280;
    public int height = 720;
    public bool fullscreen = false;

    public Camera cam;
    public Vector2 upperLeftXY;
    public Vector2 upperRightXY;
    public Vector2 lowerLeftXY;
    public Vector2 lowerRightXY;

    public bool gameOver = false;
    public bool musicStopped = false;

    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject triviaPanel;

    // Start is called before the first frame update
    private void Start()
    {
        // play background music
        SoundManager.instance.PlaySound("Background");

        // find the game coordinates from screen size
        // upper left
        Vector3 upperLeftScreen = new Vector3(0, Screen.height, 0);
        upperLeftXY = new Vector2(cam.ScreenToWorldPoint(upperLeftScreen).x, cam.ScreenToWorldPoint(upperLeftScreen).y);
        GameObject.Find("GameController").GetComponent<SpawnAsteroids>().leftSide = upperLeftXY.x;
        
        // upper right
        Vector3 upperRightScreen = new Vector3(Screen.width, Screen.height, 0);
        upperRightXY = new Vector2(cam.ScreenToWorldPoint(upperRightScreen).x, cam.ScreenToWorldPoint(upperRightScreen).y);
        GameObject.Find("GameController").GetComponent<SpawnAsteroids>().rightSide = upperRightXY.x;

        // lower left
        Vector3 lowerLeftScreen = new Vector3(0, 0, 0);
        lowerLeftXY = new Vector2(cam.ScreenToWorldPoint(lowerLeftScreen).x, cam.ScreenToWorldPoint(lowerLeftScreen).y);

        // lower right
        Vector3 lowerRightScreen = new Vector3(Screen.width, 0, 0);
        lowerRightXY = new Vector2(cam.ScreenToWorldPoint(lowerRightScreen).x, cam.ScreenToWorldPoint(lowerRightScreen).y);

        GameObject.Find("Psyche").GetComponent<PsycheMovement>().topy = upperRightXY.y;
        GameObject.Find("Psyche").GetComponent<PsycheMovement>().bottomY = lowerLeftXY.y;
        GameObject.Find("Psyche").GetComponent<PsycheMovement>().leftX = lowerLeftXY.x;
        GameObject.Find("Psyche").GetComponent<PsycheMovement>().rightX = lowerRightXY.x;
        
        gameOver = false;
        musicStopped = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    private void Update()
    {
       if(gameOver)
       {
            if (musicStopped == false)
            {
                SoundManager.instance.StopSound("Background");
                musicStopped = true;
            }
            Time.timeScale = 0;
       }
    }
}
