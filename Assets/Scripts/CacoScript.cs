using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class CacoScript : MonoBehaviour
{
    public bool isHit = false;
    public GameObject coin;
    private GameObject player;
    private GameObject spawner;
    private GameObject playerManager;
    

    private float secondsToPlayerNav;
    private float speed;

    void Start()
    {
        player = GameObject.Find("Player");
	    spawner = GameObject.Find("EnemySpawner");
        playerManager = GameObject.Find("PlayerManager");
       
    }

    void Update()
    {
        if (isHit)
        {
            Destroy(this.transform.parent.gameObject);
            spawner.GetComponent<Spawner>().spawnCoin(gameObject.transform.position);
            spawner.GetComponent<Spawner>().addKill();
            playerManager.GetComponent<PlayerManager>().addKill();
        }  


        secondsToPlayerNav = (float)(Math.Pow(Vector2.Distance(player.transform.position, gameObject.transform.position), 0.75) / 5);
        speed = 25 / secondsToPlayerNav;

        if (gameObject.transform.position.y > player.transform.position.y + 5)
            gameObject.transform.Translate(Vector3.down * Time.deltaTime * speed);
	
    }
}
