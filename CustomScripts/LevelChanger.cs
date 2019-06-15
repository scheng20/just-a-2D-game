using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour {

    //Reference to fading animator
    public Animator animator;

    private int levelToLoad;
    private bool levelFinished;

	// Update is called once per frame
	void Update ()
    {
        levelFinished = Player.LevelComplete;

        if (levelFinished == true)
        {
            FadeToNextLevel();
        }
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
