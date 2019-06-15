﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMasterTeleport : MonoBehaviour {

    public static GameMasterTeleport gm;

    public static int deathCount;

    // Use this for initialization
    void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMasterTeleport>();
        }

        deathCount = 0;
    }

    private void Update()
    {
        // [Esc] to quit
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        // [R] to reload level
        if (Input.GetKeyDown(KeyCode.R))
        {
            Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
        }
    }

    public Transform playerPrefab;
    public Transform spawnPoint;
    public float spawnDelay = 2;

    //Variable that stores the spawn particle prefab
    public GameObject spawnParticlesPrefab;

    public IEnumerator RespawnPlayer()
    {
        //Play the death sound (non enabled)
        //GetComponent<AudioSource>().Play();

        // Wait for a few seconds before respawning the player
        //Since we're using yield here, the method type has to be IEnumerator, instead of void
        yield return new WaitForSeconds(spawnDelay);

        //Respawn the player
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);

        //Create the respawn particles and then destroy them 3 seconds later
        GameObject clone = Instantiate(spawnParticlesPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;

        Destroy(clone, 3f);
    }

    public static void KillPlayer(TeleportPlayer player)
    {

        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnPlayer()); //Has to call the method like this if its an IEnumerator method

    }

    public static void IncreaseDeath()
    {
        deathCount++;
        Debug.Log("Death Count: " + deathCount);
    }
}
