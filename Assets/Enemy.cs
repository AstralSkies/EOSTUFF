using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Grid grid;
    public GameObject player;
    public GameObject enemy;
    public float moveSpeed = 2f;
    public Animator animator;
    private Vector3Int _targetCell;
    private Vector3 _targetPosition;
    float speed;
    private bool isMoving = false;
    private SpriteRenderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        // Get initial position of the player on the world grid
        Vector3 initialPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        _renderer = GetComponent<SpriteRenderer>();
        _targetCell = grid.WorldToCell(initialPosition);
        speed = this.GetComponent<Rigidbody2D>().velocity.y;
        enemy = GameObject.FindGameObjectWithTag("Player");
        // Snap the player to the center of the initial cell
        _targetPosition = grid.CellToWorld(_targetCell);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3Int gridMovement = new Vector3Int();
    }
}
