using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public int damage = 20;
    public HealthBar healthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            
                if (currentHealth > 0f)
                {
                    ChangeHealth(-20);
                }
                if (currentHealth <= 0){
                    Debug.Log(currentHealth);
                    GetComponent<CharacterMovement>().coll.isTrigger = true;
                    //Destroy(gameObject);
                }
        }
    }
    public void ChangeHealth(int value){
        
        currentHealth += value;
        healthBar.SetHealth(currentHealth);
        currentHealth = (int)Mathf.Clamp(currentHealth, 0f, 100f);
        
        // if(currentHealth <= 0){
        //     GetComponent<CharcaterMove>().enabled = false;
            
        // }
    
    }
    
    
}
