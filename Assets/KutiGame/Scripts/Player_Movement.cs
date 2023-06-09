using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRB;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private float horizontal = 0f;

    public float speed = 12f;
    private float moveDirection;
    // flippt das Sprite 
    public bool turned = false;
    public float jumpStrength = 19;
    private int jumpDirection = 1;
    private bool isJumping = false;


    // Start is called before the first frame update
    void Start()
    {
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
        if(!turned)
        {
            // horizontal = Input.GetAxisRaw("P1_horizontal");

            CalculateHorizontal(1);

            // Horizontal selbst aus den Axen zsm bauen
            // ist ja eig nur -1, 0 oder 1

            if(KutiInput.GetKutiButtonDown(EKutiButton.P1_MID) && IsGrounded())
            {   
                myRB.velocity = new Vector2(myRB.velocity.x, jumpStrength);
            }
            if(KutiInput.GetKutiButtonUp(EKutiButton.P1_MID) && myRB.velocity.y > 0f)
            {   
                myRB.velocity = new Vector2(myRB.velocity.x, myRB.velocity.y * 0.5f);
            }

        }else
        {
            //horizontal = Input.GetAxisRaw("P2_horizontal");
            CalculateHorizontal(2);

            if(KutiInput.GetKutiButtonDown(EKutiButton.P2_MID) && IsGrounded())
            {   
                myRB.velocity = new Vector2(myRB.velocity.x, -jumpStrength);
            }
        }

        

        /* myRB.velocity = new Vector2(speed*moveDirection, myRB.velocity.y);

        if (!isJumping)
        {
            if(!turned)
            {
                if(KutiInput.GetKutiButtonDown(EKutiButton.P1_MID))
                {
                    myRB.velocity = Vector2.up * jumpStrength * jumpDirection;
                    isJumping = !isJumping;
                }
            }else{
                if(KutiInput.GetKutiButtonDown(EKutiButton.P2_MID))
                {
                    myRB.velocity = Vector2.up * jumpStrength * jumpDirection;
                    isJumping = !isJumping;
                }
            }
        }

        if(!turned)
        {
            if (KutiInput.GetKutiButtonDown(EKutiButton.P1_LEFT))
            {
                moveDirection = -1;
            }else if (KutiInput.GetKutiButtonDown(EKutiButton.P1_RIGHT))
            {
                moveDirection = 1;
            }else if(KutiInput.GetKutiButtonUp(EKutiButton.P1_LEFT)||KutiInput.GetKutiButtonUp(EKutiButton.P1_RIGHT))
            {
                moveDirection = 0;
            } 
        }else
        {
            if (KutiInput.GetKutiButtonDown(EKutiButton.P2_RIGHT))
            {
                moveDirection = -1;
            }else if (KutiInput.GetKutiButtonDown(EKutiButton.P2_LEFT))
            {
                moveDirection = 1;
            }else if(KutiInput.GetKutiButtonUp(EKutiButton.P2_LEFT)||KutiInput.GetKutiButtonUp(EKutiButton.P2_RIGHT))
            {
                moveDirection = 0;
            }  
        } */
    }

    private void FixedUpdate() 
    {
        myRB.velocity = new Vector2(horizontal * speed, myRB.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


    private void CalculateHorizontal(int player)
    {
        if(player == 1)
        {
            if (KutiInput.GetKutiButtonDown(EKutiButton.P1_LEFT))
            {
                horizontal -= 1;
            }
            if(KutiInput.GetKutiButtonUp(EKutiButton.P1_LEFT))
            {
                horizontal += 1;
            }
            if (KutiInput.GetKutiButtonDown(EKutiButton.P1_RIGHT))
            {
                horizontal += 1;
            }
            if(KutiInput.GetKutiButtonUp(EKutiButton.P1_RIGHT))
            {
                horizontal -= 1;
            }
        }else if(player == 2)
        {
            if (KutiInput.GetKutiButtonDown(EKutiButton.P2_LEFT))
            {
                horizontal += 1;
            }
            if(KutiInput.GetKutiButtonUp(EKutiButton.P2_LEFT))
            {
                horizontal -= 1;
            }
            if (KutiInput.GetKutiButtonDown(EKutiButton.P2_RIGHT))
            {
                horizontal -= 1;
            }
            if(KutiInput.GetKutiButtonUp(EKutiButton.P2_RIGHT))
            {
                horizontal += 1;
            }
        }
    }

    public void GravityTurn()
    {
        // moveDirection = 0;
        horizontal = 0;
        myRB.gravityScale *= -1;
        gameObject.transform.Rotate(180,0,0);
        turned = !turned;
        //jumpDirection *= -1;
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))   
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Ground"))    
        {
            isJumping = true;
        }
    }
}


