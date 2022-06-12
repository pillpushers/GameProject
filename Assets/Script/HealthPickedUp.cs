using UnityEngine;
using System.Collections;

public class HealthPickedUp : MonoBehaviour
{
	public int  healthBonus;				// How much health the crate gives the player.
	public AudioClip collect;				// The sound of the crate being collected.


	private PickupSpawner pickupSpawner;	// Reference to the pickup spawner.
	private Animator anim;					// Reference to the animator component.
	private bool landed;					// Whether or not the crate has landed.


	void Awake ()
	{
		// Setting up the references.
		//pickupSpawner = GameObject.Find("pickupManager").GetComponent<PickupSpawner>();
		anim = transform.root.GetComponent<Animator>();
	}


	void OnTriggerEnter2D (Collider2D other)
	{
		
	}
    void OnCollisionEnter2D(Collision2D other)
    {
        
        // If the player enters the trigger zone...
		if(other.gameObject.tag == "Player")
		{
			// Get a reference to the player health script.
			PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
        
			// Increasse the player's health by the health bonus but clamp it at 100.
			
			playerHealth.ChangeHealth(healthBonus);
Debug.Log(playerHealth.currentHealth);

			// Update the health bar.
			

			// Trigger a new delivery.
			//pickupSpawner.StartCoroutine(pickupSpawner.DeliverPickup());

			// Play the collection sound.
			AudioSource.PlayClipAtPoint(collect,transform.position);

			// Destroy the crate.
			Destroy(transform.root.gameObject);
		}
		// Otherwise if the crate hits the ground...
		else if(other.gameObject.tag == "ground" && !landed)
		{
			// ... set the Land animator trigger parameter.
			anim.SetTrigger("landed");
            Debug.Log(1);
			transform.parent = null;
			gameObject.AddComponent<Rigidbody2D>();
			landed = true;	
			anim.SetBool("flag", true);
		}
    }
}
