using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Characters
{
    private PlayerInputActions playerInputActions;
    private Rigidbody playerRb;
    private GameObject player;
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    private float bulletSpeed = 50f;
    

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody>();        
        playerInputActions = new PlayerInputActions();
        playerInputActions.Player.Movement.performed += Movement_performed;
        playerInputActions.Player.Shoot.performed += Shoot_performed;
    }

    private void Shoot_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        SpawnBullet();
    }

    private void OnEnable()
    {
        playerInputActions.Player.Movement.Enable();
        playerInputActions.Player.Shoot.Enable();
    }

    private void OnDisable()
    {
        playerInputActions.Player.Movement.Disable();
        playerInputActions.Player.Shoot.Disable();
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

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * rotateSpeed);

        Vector3 position = ConstrainMovement(transform.position.x, transform.position.z);
        transform.position = position;
    }

    private void SpawnBullet()
    {
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.forward, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
    }

}
