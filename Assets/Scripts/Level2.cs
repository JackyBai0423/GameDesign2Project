using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level2 : MonoBehaviour
{

    public int gameStartScene;
    // Start is called before the first frame update
    public void StartGame(){
        SceneManager.LoadScene(gameStartScene);
    }
}