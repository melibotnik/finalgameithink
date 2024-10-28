
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerScript : MonoBehaviour
{
    
    public Rigidbody2D RB;
    public Transform groundCheckCollider;
    public TextMeshPro ScoreText;
    public LayerMask groundLayer;
        
    const float groundCheckRadius = 0.2f;
    public float Speed = 5;
    public int Score = 0;
    public float jumpPower = 300;
    float deathYPosition = -4.5f;
    
    float horizontalValue;
    
    public bool isGrounded;
    bool Jump;
    
//Start automatically gets triggered once when the objects turns on/the game starts

    void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
        RB = GetComponent<Rigidbody2D>();   
       
        UpdateScore();
    }

    
    void Update()
    {
        
        horizontalValue = Input.GetAxisRaw ("Horizontal");

        if (Input.GetButtonDown("Jump"))
            Jump = true;
        else if (Input.GetButtonUp("Jump"))
            Jump = false;
        
        if (transform.position.y <= deathYPosition)
        {
            Die();
        }
        
    }

    void FixedUpdate()
    {
        GroundCheck(); 
        Move(horizontalValue, Jump);
    }

    void GroundCheck()
    {
        isGrounded = false;
       
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);  
        if (colliders.Length>0)
            isGrounded = true;
    }
    
    void Move(float dir, bool jumpFlag)
    {
        if (isGrounded && jumpFlag)
        {
            isGrounded = false;
            jumpFlag = false;
            RB.AddForce(new Vector2(0F,jumpPower));
        }
        
        float xVal = dir * Speed * 100 * Time.fixedDeltaTime;
       Vector2 targetVelocity = new Vector2(xVal,RB.velocity.y);
       RB.velocity = targetVelocity;
    }
    
   
    
    //This gets called whenever you bump into another object, like a wall or coin.
    private void OnCollisionEnter2D(Collision2D other)
    {
        //This checks to see if the thing you bumped into had the Hazard tag
        //If it does...
        if (other.gameObject.CompareTag("Hazard"))
        {
            //Run your 'you lose' function!
            Die();
        }
        
        
       
            CoinScript coin = other.gameObject.GetComponent<CoinScript>();
           
            if (coin != null)
            {
                //Tell the coin that you bumped into them so they can self destruct or whatever
                coin.GetBumped();
                //Make your score variable go up by one. . .
                Score++;
                //And then update the game's score text
                UpdateScore();
            }
        
    }
    
    void UpdateScore()
        {
            ScoreText.text = "Score: " + Score;
        }

        //If this function is called, the player character dies. The game goes to a 'Game Over' screen.
        void Die()
        {
            SceneManager.LoadScene("Game Over");
        }
}
