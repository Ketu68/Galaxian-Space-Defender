using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GSDManager : MonoBehaviour
{
    public static GSDManager Instance;
    public Canvas menuCanvas, inGameCanvas, gameOverCanvas, pauseCanvas;
    public AudioSource source, soundtrack;
    public AudioClip fireSound, playerHitSound, alienHitSound, alienFire, thrust, SoundTrack;

    public GSDManager GetInstance() { return Instance; }
    public GameState currentGameState = GameState.menu;

    public int score;
    public string nextSceneName;
    public float waitTime=3f;

    public enum GameState
    {
        menu, inGame, paused, gameOver
    }

    public void Awake()
    {
        Instance = this;
        currentGameState = GameState.menu;
        //SceneManager.LoadScene(0);
    }

    void Start()
    {

    }

    public void StartGame()
    {
        SetGameState(GameState.inGame);
        SceneManager.LoadScene(1);
    }
    public void PauseGame()
    {
        Debug.Log("GamePaused");
        SetGameState(GameState.paused);
        SceneManager.LoadScene(0);
    }
    public void GameOver()
    {
        SetGameState(GameState.gameOver);
        SceneManager.LoadScene(0);
    }
    public void BackToMenu()
    {
        SetGameState(GameState.menu);
        SceneManager.LoadScene(0);
    }

    public void EndTheScene()
    {
        SceneManager.LoadScene(0);
        //StartCoroutine(WaitAndLoadScene());
    }

    public IEnumerator WaitAndLoadScene()
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(0);
    }

    public void SetGameState(GameState newGameState)
    {
        if (newGameState == GameState.menu)
        {
            menuCanvas.enabled = true;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
            pauseCanvas.enabled = false;
        }
        else if (newGameState == GameState.inGame)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = true;
            gameOverCanvas.enabled = false;
            pauseCanvas.enabled = false;
        }
        else if (newGameState == GameState.paused)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = false;
            pauseCanvas.enabled = true;
        }
        else if (newGameState == GameState.gameOver)
        {
            menuCanvas.enabled = false;
            inGameCanvas.enabled = false;
            gameOverCanvas.enabled = true;
            pauseCanvas.enabled = false;
        }
        currentGameState = newGameState;
    }

    public void QuitGame()
    {
        //Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
    }
}


