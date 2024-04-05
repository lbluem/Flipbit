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

    // Button Tracker
    private bool p1ButtonLeftUp = true;
    private bool p1ButtonRightUp = true;
    private bool p2ButtonLeftUp = true;
    private bool p2ButtonRightUp = true;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();        
    }

    private void Awake() 
    {
        // In the case we start with player 2 controlling the character
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

        if(!turned)
        {
            CalculateHorizontal(1);

            // Jumping
            if(KutiInput.GetKutiButtonDown(EKutiButton.P1_MID) && IsGrounded())
            {   
                myRB.velocity = new Vector2(myRB.velocity.x, jumpStrength);
                FindObjectOfType<AudioManager>().Play("PlayerJump");
            }
            // longer press → longer air time
            if(KutiInput.GetKutiButtonUp(EKutiButton.P1_MID) && myRB.velocity.y > 0f)
            {   
                myRB.velocity = new Vector2(myRB.velocity.x, myRB.velocity.y * 0.5f);
            }

        }else
        {
            CalculateHorizontal(2);

            // Jumping
            if(KutiInput.GetKutiButtonDown(EKutiButton.P2_MID) && IsGrounded())
            {   
                myRB.velocity = new Vector2(myRB.velocity.x, -jumpStrength);
                FindObjectOfType<AudioManager>().Play("PlayerJump");
            }
            // longer press → longer air time
            if(KutiInput.GetKutiButtonUp(EKutiButton.P2_MID) && myRB.velocity.y < 0f)
            {   
                myRB.velocity = new Vector2(myRB.velocity.x, myRB.velocity.y * 0.5f);
            }
        }

        // Plays according animations
        _animator.SetBool("isJumping", !IsGrounded());
        _animator.SetBool("isRunning", !IsRunning());

        if(!IsGrounded())
        {
            inAir = true;
        }

        if(IsGrounded() && inAir)
        {
            FindObjectOfType<AudioManager>().Play("PlayerFall");
            //Debug.Log("Player Movement: I FELL");
            _animator.SetBool("isLanding", true);
            inAir = false;
        }else
        {
            _animator.SetBool("isLanding", false);
        }

    }

    private void FixedUpdate() 
    {
        myRB.velocity = new Vector2(horizontal * speed, myRB.velocity.y);
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
            return true;
        }else
        {
            return false;
        }
    }


    // Calculate horizontal movement based on player
    // Berechne die horizontale Bewegung basierend auf dem Spieler
    private void CalculateHorizontal(int player)
    {

        // Eleganter wäre eine "activePlayer" Variable die zwischen
        // EKutiButton.P1.. und EKutiButton.P2.. swapped
        // die if Abfragen anpassen und damit sollte Code gespart werden

        if(player == 1)
        {
            if (KutiInput.GetKutiButtonDown(EKutiButton.P1_LEFT))
            {
                horizontal -= 1;
                p1ButtonLeftUp = false;
            }
            if (KutiInput.GetKutiButtonUp(EKutiButton.P1_RIGHT))
            {
                horizontal -= 1;
                p1ButtonRightUp = true;
            }
            if(KutiInput.GetKutiButtonUp(EKutiButton.P1_LEFT))
            {
                horizontal += 1;
                p1ButtonLeftUp = true;
            }
            if(KutiInput.GetKutiButtonDown(EKutiButton.P1_RIGHT))
            {
                horizontal += 1;
                p1ButtonRightUp = false;
            }
            if(p1ButtonLeftUp && p1ButtonRightUp)
            {
                horizontal = 0;
            }


        }else if(player == 2)
        {
            if (KutiInput.GetKutiButtonDown(EKutiButton.P2_LEFT))
            {
                horizontal += 1;
                p2ButtonLeftUp = false;
            }
            if (KutiInput.GetKutiButtonUp(EKutiButton.P2_RIGHT))
            {
                horizontal += 1;
                p2ButtonRightUp = true;
            }
            if (KutiInput.GetKutiButtonUp(EKutiButton.P2_LEFT))
            {
                horizontal -= 1;
                p2ButtonLeftUp = true;
            }
            if(KutiInput.GetKutiButtonDown(EKutiButton.P2_RIGHT))
            {
                horizontal -= 1;
                p2ButtonRightUp = false;
            }
            if(p2ButtonLeftUp && p2ButtonRightUp)
            {
                horizontal = 0;
            }
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
        p1ButtonLeftUp = true;
        p1ButtonRightUp = true;
        p2ButtonLeftUp = true;
        p2ButtonRightUp = true;

        myRB.gravityScale *= -1;
        gameObject.transform.Rotate(180,0,0);
        turned = !turned;

        OnGravityChange?.Invoke(turned);
    }

    // Function gets triggered in the animation from the character
    // Funtion wird in der Animation vom Charakter getriggered
    private void DeathRestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Get and Set used by Spike Handler
    public bool GetIsDying()
    {
        return isDying;
    }

    public void SetIsDying(bool newIsDying)
    {
        isDying = newIsDying;
    }
}

