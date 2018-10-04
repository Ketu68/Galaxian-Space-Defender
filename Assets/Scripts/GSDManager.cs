using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GSDManager : MonoBehaviour
{
    public static GSDManager Instance;
    public AudioSource source, soundtrack;
    public AudioClip fireSound, playerHitSound, alienHitSound, alienFire, thrust, SoundTrack;
    public GameObject explosion, laser;

    public GSDManager GetInstance() { return Instance; }

    public int score, lives;
    public string nextSceneName;
    public float waitTime=3f;
    public int maxenemies = 12, enemies = 0;

    public void Awake()
    {
        Instance = this;
        score = 0;
        lives = 3;
        //AudioSource source = GetComponent<AudioSource>();
    }

    void Start()
    {
        GameObject.Find("scoreUI").GetComponent<Text>().text = "SCORE : " + score;
        for (int x = 0; x < lives; x++) GameObject.Find("Lives").GetComponent<Text>().text = "LIVES : " + lives;
    }

    public void IncreaseScore()
    {
        score += 100;
        if (score % 10000 == 0)
        {
            lives++;
        }

        GameObject.Find("scoreUI").GetComponent<Text>().text = "SCORE : " + score;
        for (int x = 0; x < lives; x++) GameObject.Find("Lives").GetComponent<Text>().text = "LIVES : " + lives;

    }

    public IEnumerator FreezeFor()
    {
        if (GSDManager.Instance.source.isPlaying) GSDManager.Instance.source.Stop();
        yield return new WaitForSeconds(2);
        StartOver();
    }

    public void StartOver()
    {
        lives--;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //gameObject.transform.Translate(Vector3.left * 1f);

        //Destroy(transform.gameObject);

        //if (GSDManager.Instance.soundtrack.isPlaying) GSDManager.Instance.soundtrack.Stop();
        //if (!GSDManager.Instance.source.isPlaying) GSDManager.Instance.EndTheScene();
        //else StartCoroutine(FreezeFor());
        //if (!GSDManager.Instance.source.isPlaying) GSDManager.Instance.EndTheScene();
    }


    public void EndTheScene()
    {
        SceneManager.LoadScene(0);
    }
}


