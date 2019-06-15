using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartLevel : MonoBehaviour {

    //Reference to fading animator
    public Animator animator;

    private int levelToLoad;
    private bool levelFinished;

    private void Start()
    {
        levelFinished = false;
    }

    // Update is called once per frame
    void Update()
    {
        levelFinished = StartMaster.playGame;

        if (levelFinished == true)
        {
            FadeToNextLevel();
        }

        levelFinished = false;
    }

    public void FadeToNextLevel()
    {
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");

    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
