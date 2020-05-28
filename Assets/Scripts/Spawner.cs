using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject deamon;
    public GameObject player;
    public GameObject playerManager;
    public GameObject coin;

    private int waveKill = 0;
    public Text waveText;
    private int wave = 1;

    void Start()
    {
        waveText = GameObject.Find("WaveCounter").GetComponent<Text>();
        nextWave();
    }

    void Update()
    {
        if (waveKill == wave-1)
        nextWave();
    }

    public void addKill() {
        waveKill++;
    }

    void nextWave(){
        waveText.text = "Wave: " + wave.ToString();
        waveKill = 0;
	    for(int i = 0; i < wave; i++)
		{
            SpawnOne();
		}
        wave++;
    }
    void SpawnOne()
    {
        GameObject newDeamon = Instantiate(deamon, new Vector3(Random.Range(-85, 85), 50, Random.Range(-85, 85)), Quaternion.identity);
        if (Vector2.Distance(newDeamon.transform.position, player.transform.position) < 50)
        {
            Destroy(newDeamon);
            SpawnOne();
        }
    }
    public void spawnCoin(Vector3 vector3) {
        Instantiate(coin, vector3, Quaternion.identity);
    }
}



