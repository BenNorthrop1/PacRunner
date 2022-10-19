using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public GameObject PlayerObj;

    public void OnTriggerEnter(Collider other) 
    {
        Debug.Log("You have entered the players hitbox");
        if(other.CompareTag("Enemy"))
        {
            Debug.Log("The player should be destroyed");
            Destroy(this.gameObject);
        }
    }



}
