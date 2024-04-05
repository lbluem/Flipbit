using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform_Movement : MonoBehaviour
{

    // Managing the movement and logic of the moving platforms

    // Sets boundaries for the platforms
    public Transform leftEnd;
    public Transform rightEnd;

    // Speed gets overwritten in editor
    public float speed = 12;
    public float moveDirection = 0;

    public bool turned;

    // Button Tracker
    private bool p1ButtonLeftUp = true;
    private bool p1ButtonRightUp = true;
    private bool p2ButtonLeftUp = true;
    private bool p2ButtonRightUp = true;

    // Start is called before the first frame update
    void Start()
    {
        // Event prerequisites
        Player_Movement player_Movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Movement>();
        player_Movement.OnGravityChange += ChangeTurned;
        // Manual function call at the beginning of the Level
        ChangeTurned(player_Movement.turned);
       
    }

    // Update is called once per frame
    void Update()
    {
        GetMovement();
    }

    // Triggered once at the start of the Level and then as an Event
    // everytime the Player changes
    private void ChangeTurned(bool turnedFromPlayer)
    {
        turned = turnedFromPlayer;
        //Debug.Log(transform.parent.name+" turned to "+turned);
    }

    private void FixedUpdate() {
       
        if(leftEnd != null && rightEnd != null)
        {
            if(
                (transform.position.x > leftEnd.position.x && transform.position.x < rightEnd.position.x)||
                (transform.position.x <= leftEnd.position.x && moveDirection == 1)||
                (transform.position.x >= rightEnd.position.x && moveDirection == -1))
            {
                transform.Translate(Vector2.right * speed * Time.deltaTime * moveDirection);        
            }
        }else
        {
            Debug.LogWarning("Platform Movement: Left and Right End Component required!");
        }
    }

    // To visualize the possible path of the platform
    // Um die mögliche Strecke der Plattform zu visualisieren
    private void OnDrawGizmos() 
    {
        if(leftEnd != null && rightEnd != null)
        {
            Gizmos.DrawLine(transform.position, leftEnd.position);
            Gizmos.DrawLine(transform.position, rightEnd.position);    
        }else
        {
            Debug.LogWarning("Platform Movement: Cant draw Gizmo. Left and Right End not set!");
        }
    }

    // Movement Handler 
    private void GetMovement()
    {
        TrackButtons();
        
        if(turned)
        {
            // Handle movement input for player 1
            // Bewegungseingabe für Spieler 1
            if(!p1ButtonLeftUp&&p1ButtonRightUp){moveDirection=-1;}
            if(!p1ButtonRightUp&&p1ButtonLeftUp){moveDirection=+1;}
            if(p1ButtonLeftUp&&p1ButtonRightUp||!p1ButtonLeftUp&&!p1ButtonRightUp){moveDirection=0;}
        }else
        {
            // Handle movement input for player 2
            // Bewegungseingabe für Spieler 2
            if(p2ButtonLeftUp&&!p2ButtonRightUp){moveDirection=-1;}
            if(p2ButtonRightUp&&!p2ButtonLeftUp){moveDirection=+1;}
            if(p2ButtonLeftUp&&p2ButtonRightUp||!p2ButtonLeftUp&&!p2ButtonRightUp){moveDirection=0;}
        }
    }

    // Keeping track of all the button states
    private void TrackButtons()
    {
        if (KutiInput.GetKutiButtonDown(EKutiButton.P1_LEFT))
        {
            p1ButtonLeftUp = false;
        }
        if (KutiInput.GetKutiButtonUp(EKutiButton.P1_RIGHT))
        {
            p1ButtonRightUp = true;
        }
        if(KutiInput.GetKutiButtonUp(EKutiButton.P1_LEFT))
        {
            p1ButtonLeftUp = true;
        }
        if(KutiInput.GetKutiButtonDown(EKutiButton.P1_RIGHT))
        {
            p1ButtonRightUp = false;
        }
        if (KutiInput.GetKutiButtonDown(EKutiButton.P2_LEFT))
        {
            p2ButtonLeftUp = false;
        }
        if (KutiInput.GetKutiButtonUp(EKutiButton.P2_RIGHT))
        {
            p2ButtonRightUp = true;
        }
        if (KutiInput.GetKutiButtonUp(EKutiButton.P2_LEFT))
        {
            p2ButtonLeftUp = true;
        }
        if(KutiInput.GetKutiButtonDown(EKutiButton.P2_RIGHT))
        {
            p2ButtonRightUp = false;
        }
    }

    // Collision Handler for being on the platform
    // Kollisionshandler für auf der Plattform sein
    private void OnCollisionEnter2D(Collision2D other) 
    {
        //Debug.Log("Platform Movement: Collision detected");
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    // Collision Handler for leaving the platform
    // Kollisionshandler für  Plattform verlassen
    private void OnCollisionExit2D(Collision2D other) 
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }

}
