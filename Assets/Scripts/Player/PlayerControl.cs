using System.Net.Security;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public CharacterController controller;
    public Animator playerani;
    public ParticleSystem falleffect;

    private float verticalVelocity; 
    public float speed = 20f;
    public float gravity = 14.0f;
    public float jumpForce = 10.0f;
    private int extrajump;
    public int Jumps = 2; //How much extra Jumps
    private int isJumping = 0;

    private float fieldboostTimer;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool booljumping;
    private bool aktivfalleffect;

    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    // Start is called before the first frame update
    void Start()
    {
        extrajump = Jumps;
    }

    // Update is called once per frame
    private void Update()
    {
        if (controller != null && playerani !=null && GameManager.TimerIsActiv == false)
        {
            Jump();
            Runstate();
            HandleJumpandFall();
            HandleSwitchColor();
        }
    }

    private void Runstate()
    {
         Vector3 moveVector = new Vector3(speed, verticalVelocity, 0);
        moveVector = transform.TransformDirection(moveVector);
        controller.Move(moveVector * Time.deltaTime);
        

        if(ColorCheck.boostingfield == true)
        {
            

            fieldboostTimer += Time.deltaTime;
            if(fieldboostTimer >= 0.5)
            {
                speed = 20f;
                fieldboostTimer = 0;
                ColorCheck.boostingfield = false;
            }
            else
            {
                Debug.Log("speed");
                speed = 50f;
            }
        }
    }

    private void Jump()
    {
        if (controller.isGrounded)
        {
            extrajump = Jumps;
            verticalVelocity = -gravity * Time.deltaTime;
            playerani.SetInteger("State", 0);
            isJumping = 0;
            jumpTimeCounter = jumpTime;
            booljumping = true;
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
            aktivfalleffect = true;
        }

        if (Input.GetMouseButtonDown(0) && Input.mousePosition.x > Screen.width / 2 && extrajump > 0 && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            isJumping++;
            verticalVelocity = jumpForce;
            extrajump--;
            jumpTimeCounter = jumpTime;
            booljumping = true;
        }
        if(Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 2 && booljumping == true && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            if(jumpTimeCounter > 0)
            {
                verticalVelocity = jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                booljumping = false;
            }
        }
        if (Input.GetMouseButtonUp(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject())
        {
            booljumping = false;
        }

    }

    private void HandleJumpandFall()
    {
        if (isJumping == 1)
        {
            if (controller.velocity.y > 0)
            {
                playerani.SetInteger("State", 3);
            }
            else
            {
                playerani.SetInteger("State", 1);
            }
        }else if(isJumping == 2)
        {

            if (controller.velocity.y > 0)
            {
                playerani.SetInteger("State", 2);
            }
            else
            {
                playerani.SetInteger("State", 1);
            }
        }

        if(controller.isGrounded && aktivfalleffect == true)
        {
            falleffect.Play();
            aktivfalleffect = false;     
        }

    }
    private void HandleSwitchColor()
    {
        if(Input.GetMouseButtonDown(0) && Input.mousePosition.x < Screen.width / 2)
        {
            playerani.SetTrigger("changecolor");
        }
    }
}
