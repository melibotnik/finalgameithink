using UnityEngine;
public class DmgBlockScript : MonoBehaviour
{
    //These are the player's Variables, the raw info that defines them

    //The Rigidbody2D is a component that gives the player physics, and is what we use to move
    public Rigidbody2D RB;
    private Vector3 originalPosition;
    Vector3 startPosition;
    
//Start automatically gets triggered once when the objects turns on/the game starts
    void Start()
    {
        originalPosition = transform.position;
    }
    
    void Update()
    {
        
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground")) 
        {
            transform.position = originalPosition;
            
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = Vector2.zero;
                rb.angularVelocity = 0f;
            }
        }
        
    }
}

