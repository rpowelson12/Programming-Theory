using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemies : Characters
{
    private GameObject player;
    [SerializeField] private NavMeshAgent enemy;
    [SerializeField] private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemy = GetComponent<NavMeshAgent>();
        playerTransform = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(playerTransform.position);
    }
}
