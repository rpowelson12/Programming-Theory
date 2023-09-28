using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Characters
{
    private PlayerInputActions playerInputActions;
    private Rigidbody playerRb;
    private GameObject player;

    

    

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
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
        Move();
    }

    public void Move()
    {
        float speed = 10f;

        Vector2 playerInput = playerInputActions.Player.Movement.ReadValue<Vector2>();
        Vector3 moveDir = new Vector3(playerInput.x, 0, playerInput.y);
        playerRb.AddForce(moveDir * speed * Time.deltaTime, ForceMode.Impulse);

        Vector3 position = Characters.ConstrainMovement(player.transform.position.x, player.transform.position.z);
        player.transform.position = position;
    }

    

}
