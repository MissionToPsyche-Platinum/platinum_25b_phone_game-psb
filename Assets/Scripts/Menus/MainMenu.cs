using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
// This script loads game scenes that are used in different menus

public class MainMenu : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("GameLevel");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("PowerUp");
    }
    
    public void MMenu ()
    {
        SceneManager.LoadScene("MainMenu");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("PowerUp");
    }
    
    public void Tutorial()
    {
        SceneManager.LoadScene("HowToPlay");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("PowerUp");
    }

    public void ScoreBoard()
    {
        SceneManager.LoadScene("Scoreboard");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("PowerUp");
    }
    
    public void Options()
    {
        SceneManager.LoadScene("Options");
        GameObject.Find("SoundManager").GetComponent<SoundManager>().PlaySound("PowerUp");
    }
}
