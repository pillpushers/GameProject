using UnityEngine;
using System.Collections;

public class BombPickup : MonoBehaviour
{
	public AudioClip pickupClip;		// Sound for when the bomb crate is picked up.


	private Animator anim;				// Reference to the animator component.
	private bool landed = false;		// Whether or not the crate has landed yet.


	void Awake()
	{
		// Setting up the reference.
		anim = transform.root.GetComponent<Animator>();
	}


	void OnCollisionEnter2D(Collision2D other)
	{
		// If the player enters the trigger zone...
		if(other.gameObject.tag == "Player")
		{
			// ... play the pickup sound effect.
			AudioSource.PlayClipAtPoint(pickupClip, transform.position);

			// Increase the number of bombs the player has.
			other.gameObject.GetComponent<LayBombs>().bombCount++;

			// Destroy the crate.
			Destroy(transform.root.gameObject);
		}
		// Otherwise if the crate lands on the ground...
		else if(other.gameObject.tag == "ground" && !landed)
		{
			// ... set the animator trigger parameter Land.
			anim.SetTrigger("landed");
			transform.parent = null;
			gameObject.AddComponent<Rigidbody2D>();
			landed = true;		
			anim.SetBool("flag", false);
		}
	}
}
