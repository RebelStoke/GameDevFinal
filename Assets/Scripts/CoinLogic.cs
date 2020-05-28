using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinLogic : MonoBehaviour
{
    private GameObject playerManager;

    void Start()
    {
        playerManager = GameObject.Find("PlayerManager");
    }

    void Update()
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            playerManager.GetComponent<PlayerManager>().addCoin();
            Destroy(gameObject);
        }
    }
}
