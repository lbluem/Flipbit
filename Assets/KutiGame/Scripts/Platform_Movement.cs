using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Movement : MonoBehaviour
{

    public Transform leftEnd;
    public Transform rightEnd;
    public float speed = 8;
    public float moveDirection = 0;
    // Start Position um da zurückkehren zu können
    // start position to return to
    public Vector3 startPosition;
    public bool turned;

    // Collision of player
    private Collision2D player = null;

    // Button Tracker
    private bool p1ButtonLeftUp = true;
    private bool p1ButtonRightUp = true;
    private bool p2ButtonLeftUp = true;
    private bool p2ButtonRightUp = true;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = gameObject.transform.position;
        turned = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().turned;
    }

    // Update is called once per frame
    void Update()
    {
        // Kann mir vorstellen, dass das zu taxing ist jede gefühlte Millisekunde
        // das Player Game Object zu finden. Bedarf evtl einer anderen Lösung
        turned = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>().turned;

        // Ist ein RigidBody überhaupt nötig?
        //thisRB.velocity = new Vector2(speed*moveDirection, thisRB.velocity.y);

        GetMovement();
    }

    private void FixedUpdate() {
       
        if(moveDirection == 0)
        {
            //FindObjectOfType<AudioManager>().Stop("PlatformMove");
            //Debug.Log("Stopping Platform Move Sound");
        }else{
            //FindObjectOfType<AudioManager>().Play("PlatformMove");
            //Debug.Log("Platform Move Sound");
        }

        if(
            (transform.position.x > leftEnd.position.x && transform.position.x < rightEnd.position.x)||
            (transform.position.x <= leftEnd.position.x && moveDirection == 1)||
            (transform.position.x >= rightEnd.position.x && moveDirection == -1))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime * moveDirection);        
        }
    }

    // Um die mögliche Strecke der Plattform zu visualisieren
    private void OnDrawGizmos() 
    {
        Gizmos.DrawLine(transform.position, leftEnd.position);
        Gizmos.DrawLine(transform.position, rightEnd.position);    
    }

    // Movement Handler 
    private void GetMovement()
    {
        if(turned)
        {
            // Handle movement input for player 1
            // Bewegungseingabe für Spieler 1
            if (KutiInput.GetKutiButtonDown(EKutiButton.P1_LEFT))
            {
                moveDirection -= 1;
                p1ButtonLeftUp = false;
            }
            if (KutiInput.GetKutiButtonUp(EKutiButton.P1_RIGHT))
            {
                moveDirection -= 1;
                p1ButtonRightUp = true;
            }
            if(KutiInput.GetKutiButtonUp(EKutiButton.P1_LEFT))
            {
                moveDirection += 1;
                p1ButtonLeftUp = true;
            }
            if(KutiInput.GetKutiButtonDown(EKutiButton.P1_RIGHT))
            {
                moveDirection += 1;
                p1ButtonRightUp = false;
            }
            if(p1ButtonLeftUp && p1ButtonRightUp)
            {
                moveDirection = 0;
            }
        }else
        {
            // Handle movement input for player 2
            // Bewegungseingabe für Spieler 2
       if (KutiInput.GetKutiButtonDown(EKutiButton.P2_LEFT))
            {
                moveDirection += 1;
                p2ButtonLeftUp = false;
            }
            if (KutiInput.GetKutiButtonUp(EKutiButton.P2_RIGHT))
            {
                moveDirection += 1;
                p2ButtonRightUp = true;
            }
            if (KutiInput.GetKutiButtonUp(EKutiButton.P2_LEFT))
            {
                moveDirection -= 1;
                p2ButtonLeftUp = true;
            }
            if(KutiInput.GetKutiButtonDown(EKutiButton.P2_RIGHT))
            {
                moveDirection -= 1;
                p2ButtonRightUp = false;
            }
            if(p2ButtonLeftUp && p2ButtonRightUp)
            {
                moveDirection = 0;
            }
        }
    }

    // Collision Handler for being on the platform
    // Kollisionshandler für auf der Plattform sein
    private void OnCollisionEnter2D(Collision2D other) 
    {
        //Debug.Log("Platform Movement: Collision detected");
        if(other.gameObject.tag == "Player")
        {
            player = other;
            other.transform.SetParent(transform);
        }else if(other.gameObject.tag == "Ground")
        {
            //Debug.Log("Platform Movement: Ground detected");
            /* if(player != null)
            {
                player.transform.SetParent(null);
            } */
        }
        /* }else if(other.gameObject.tag == "Ground")
        {
            moveDirection = 0;
        } */
        /* else if(other.gameObject.tag == "Ground")
        {
            if(other.transform.position.x > transform.position.x)
            {
                //rechte wand wurde getroffen
                Debug.Log("RECHTE WAND GETROFFEN");
            }
        } */
    }

    // Wall Collision Handler
    // Kollisionshandler für die Wand
    /* private bool wallCollision(Collision2D other) 
    {
        Debug.Log("Wilde Sachen passieren");
        if(other.gameObject.tag == "Ground")
        {
            FindObjectOfType<AudioManager>().Stop("PlatformMove");
            return true;
        }
        return false;
    } */

    // Collision Handler for leaving the platform
    // Kollisionshandler für  Plattform verlassen
    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.SetParent(null);
        }
    }

}
