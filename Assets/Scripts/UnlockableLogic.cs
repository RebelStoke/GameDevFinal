using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockableLogic : MonoBehaviour
{
    private GameObject playerManager;

    void Start()
    {
        playerManager = GameObject.Find("PlayerManager");
    }

    void Update()
    {
        if (playerManager.GetComponent<PlayerManager>().isUnlocked(gameObject.name)) {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            tryUnlock(gameObject.name);
        }
    }
    private void tryUnlock(string unlockable) {    
        playerManager.GetComponent<PlayerManager>().unlock(unlockable);
    }
}
