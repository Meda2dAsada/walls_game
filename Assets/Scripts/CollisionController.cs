using System;
using UnityEngine;

public class CollisionController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    // Update is called once per frame
    void Update()
    {
        
        
        
        
        
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            
            Destroy(other.gameObject);
            
        }
        
            
        throw new NotImplementedException();
    }
}
