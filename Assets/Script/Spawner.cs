using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject [ ] spawner;
    public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
    void Start()
    {
       InvokeRepeating( "creatEnemy", spawnDelay, spawnTime);

    }

    // Update is called once per frame
    void creatEnemy(){
        int enemyIndex = Random.Range(0, spawner.Length);
		Instantiate(spawner[enemyIndex], transform.position, transform.rotation);

		// Play the spawning effect from all of the particle systems.
		foreach(ParticleSystem p in GetComponentsInChildren<ParticleSystem>())
		{
			p.Play();
		}
	
    }
    void Update()
    {
        
    }
}
