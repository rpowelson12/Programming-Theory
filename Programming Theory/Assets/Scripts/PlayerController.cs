using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerInputActions playerInputActions;
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private GameObject player;

    

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Movement.performed += Movement_performed;
    }

    private void OnEnable()
    {
        playerInputActions.Player.Movement.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Player.Movement.Enable();
    }


    private void Movement_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        float speed = 10f;

        Vector2 playerInput = playerInputActions.Player.Movement.ReadValue<Vector2>();
        Vector3 moveDir = new Vector3(playerInput.x, 0, playerInput.y);
        playerRb.AddForce(moveDir * speed * Time.deltaTime, ForceMode.Impulse);

        ConstrainMovement();
        
    }

    private void ConstrainMovement()
    {
        float playerXpos = player.transform.position.x;
        float playerYpos = player.transform.position.y;

        if (playerXpos < 45)
        {
            playerXpos = 45;
        }
        else if (playerXpos > 45)
        {
            playerXpos = -45;
        }
        else if (playerYpos < 45)
        {
            playerYpos = 45;
        }
        else if (playerYpos > -45)
        {
            playerYpos = -45;
        }
    }

}
