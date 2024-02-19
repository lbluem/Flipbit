using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRB;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Animator _animator;

    private float horizontal = 0f;

    //für Out of Bounds Check
    private string thisScene;
    public float speed = 12f;
    private float moveDirection;
    // flippt das Sprite 
    public bool turned = false;
    public float jumpStrength = 19;
    private bool inAir = false;
    private bool isFacingRight = false;

    // Button Tracker
    private bool p1ButtonLeftUp = true;
    private bool p1ButtonRightUp = true;
    private bool p2ButtonLeftUp = true;
    private bool p2ButtonRightUp = true;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        thisScene = SceneManager.GetActiveScene().name;

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
        /* CheckOutOfBounds(); */

        if(!turned)
        {
            CalculateHorizontal(1);

            if(KutiInput.GetKutiButtonDown(EKutiButton.P1_MID) && IsGrounded())
            {   
                myRB.velocity = new Vector2(myRB.velocity.x, jumpStrength);
                FindObjectOfType<AudioManager>().Play("PlayerJump");
            }
            if(KutiInput.GetKutiButtonUp(EKutiButton.P1_MID) && myRB.velocity.y > 0f)
            {   
                myRB.velocity = new Vector2(myRB.velocity.x, myRB.velocity.y * 0.5f);
            }

        }else
        {
            CalculateHorizontal(2);

            if(KutiInput.GetKutiButtonDown(EKutiButton.P2_MID) && IsGrounded())
            {   
                myRB.velocity = new Vector2(myRB.velocity.x, -jumpStrength);
                FindObjectOfType<AudioManager>().Play("PlayerJump");
            }
            if(KutiInput.GetKutiButtonUp(EKutiButton.P2_MID) && myRB.velocity.y < 0f)
            {   
                myRB.velocity = new Vector2(myRB.velocity.x, myRB.velocity.y * 0.5f);
            }
        }

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

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.6f, groundLayer);
    }

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

    public void GravityTurn()
    {
        // wenn zu "geturned" wird sollte folgendes passieren
        p1ButtonLeftUp = true;
        p1ButtonRightUp = true;
        p2ButtonLeftUp = true;
        p2ButtonRightUp = true;

        // so wie oben ist das Problem erstmal gelöst
        // aber führt zu anderen nischigeren Problemen

        //horizontal = 0;
        myRB.gravityScale *= -1;
        gameObject.transform.Rotate(180,0,0);
        turned = !turned;
    }

/*     private void CheckOutOfBounds()
    {
        var thisPosition = transform.position;

        if(thisPosition.x > 11.5 || thisPosition.x < -11.5
        || thisPosition.y > 9.5 || thisPosition.y < -9.5)
        {
            FindObjectOfType<AudioManager>().Play("PlayerHit");
            SceneManager.LoadScene(thisScene, LoadSceneMode.Single);
        }
    } */

}

