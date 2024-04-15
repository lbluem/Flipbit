using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{

    // Everything regarding the Player including the movement and other logic

    [SerializeField] private Rigidbody2D myRB;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Animator _animator;

    // For move direction
    private float horizontal = 0f;
    public float speed = 16f;

    // Flip sprite on gravity change
    // has to be set in Editor if Level starts turned
    public bool turned = false;
    public float jumpStrength = 32;
    private bool inAir = false;

    // To prevent the player from dying again before the scene resets
    public bool isDying = false;

    // Event for gravity change for different gameObjects
    public delegate void OnTurned(bool turned);
    public event OnTurned OnGravityChange;

    // for the making the char look in the right direction
    private bool isFacingRight = true;

    // Jump booleans
    private bool activeJumpButton; 
    private bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void Awake() 
    {
        // If player 2 starts
        // Für den Fall das wir mit dem Spieler 2 anfangen
        if(turned)
        {
            GravityTurn();
            turned = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Flip();
        Jump();
        SetDirection();

        // Plays according animations
        _animator.SetBool("isJumping", !IsGrounded());
        _animator.SetBool("isRunning", IsRunning());

        if(!IsGrounded())
        {
            inAir = true;
        }

        if(IsGrounded() && inAir)
        {
            FindObjectOfType<AudioManager>().Play("PlayerFall");
            _animator.SetBool("isLanding", true);
            inAir = false;
        }else
        {
            _animator.SetBool("isLanding", false);
        }

    }

    // The actual Movement
    private void FixedUpdate() 
    {
        myRB.velocity = new Vector2(horizontal * speed, myRB.velocity.y);
    }


    private void Jump()
    {
        // setting activeButton based on players turn
        activeJumpButton = !turned ? InputManager.Instance.P1ButtonJumpUp : InputManager.Instance.P2ButtonJumpUp;

        if(canJump && !activeJumpButton && IsGrounded())
            { 
                myRB.velocity = !turned ? new Vector2(myRB.velocity.x, jumpStrength) : new Vector2(myRB.velocity.x, -jumpStrength);
                FindObjectOfType<AudioManager>().Play("PlayerJump");
                canJump = false;
            }
            // longer press → longer air time
            if((!turned && activeJumpButton && myRB.velocity.y > 0f) ||
                (turned && activeJumpButton && myRB.velocity.y < 0f))
            {
                myRB.velocity = new Vector2(myRB.velocity.x, myRB.velocity.y * 0.5f);
            }
            // too prevent continous jumping while holding the jump button
            if(activeJumpButton)
            {
                canJump = true;
            }

    }
    // Check if the player is grounded
    // Überprüfe, ob der Spieler auf dem Boden steht
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.75f, groundLayer);
    }

    // Check if the player is running (for the animation)
    // Überprüfe, ob der Spieler rennt (für die Animation)
    private bool IsRunning()
    {
        if(horizontal == 0)
        {
            return false;
        }else
        {
            return true;
        }
    }

    // Setting the horizontal movement based of the Inputs (1, 0 or -1)
    // Setzt die horizontale Bewegung basierend auf den Input (1, 0 oder -1)
    private void SetDirection()
    {
        if(!turned)
        {
            if(!InputManager.Instance.P1ButtonLeftUp&&InputManager.Instance.P1ButtonRightUp){horizontal=-1;}
            if(!InputManager.Instance.P1ButtonRightUp&&InputManager.Instance.P1ButtonLeftUp){horizontal=+1;}
            if(InputManager.Instance.P1ButtonLeftUp&&InputManager.Instance.P1ButtonRightUp||
              !InputManager.Instance.P1ButtonLeftUp&&!InputManager.Instance.P1ButtonRightUp){horizontal=0;}
        }else if(turned)
        {
            if(InputManager.Instance.P2ButtonLeftUp&&!InputManager.Instance.P2ButtonRightUp){horizontal=-1;}
            if(InputManager.Instance.P2ButtonRightUp&&!InputManager.Instance.P2ButtonLeftUp){horizontal=+1;}
            if(InputManager.Instance.P2ButtonLeftUp&&InputManager.Instance.P2ButtonRightUp||
              !InputManager.Instance.P2ButtonLeftUp&&!InputManager.Instance.P2ButtonRightUp){horizontal=0;}
        }
        
    }

    // If the player walks to the left the character also looks to the left
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1;
            transform.localScale = localScale;
        }

    }

    // Invert gravity for the player → The player changes
    // Die Schwerkraft für den Spieler umkehren
   public void GravityTurn()
    {
        myRB.gravityScale *= -1;
        gameObject.transform.Rotate(180,0,0);
        turned = !turned;
        SetDirection();
        OnGravityChange?.Invoke(turned);
    }

    // Function gets triggered in the animation from the character
    // Funtion wird in der Animation vom Charakter getriggered
    private void DeathRestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Get and Set used by TouchAndYouDie Handler
    public bool GetIsDying()
    {
        return isDying;
    }

    // Also used by TouchAndYouDie Handler
    public void SetIsDying(bool newIsDying)
    {
        isDying = newIsDying;
        // as the scene and character reloads the isDying variable is automatically set to false again
    }
}

