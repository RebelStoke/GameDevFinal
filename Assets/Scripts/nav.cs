using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class nav : MonoBehaviour
{
    public NavMeshAgent navAgent;
    private GameObject player;	
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
	    player = GameObject.Find("Player");
        navAgent.SetDestination(player.transform.position);
    }
}
