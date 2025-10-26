using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private GameObject gameOverCanvas;
    // Start is called before the first frame update
    public void gameOver() { 
        gameOverCanvas.SetActive(true);
    }
}
