using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Grid grid;
    public GameObject player;
    public float moveSpeed = 2f;
    public Animator animator;
    private Vector3Int _targetCell;
    private Vector3 _targetPosition;
    float speed;
    private bool isMoving = false;
    private SpriteRenderer _renderer;
    private void Start()
    {
        // Get initial position of the player on the world grid
        Vector3 initialPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        _renderer = GetComponent<SpriteRenderer>();
        _targetCell = grid.WorldToCell(initialPosition);
        speed = this.GetComponent<Rigidbody2D>().velocity.y;
        // Snap the player to the center of the initial cell
        _targetPosition = grid.CellToWorld(_targetCell);
    }

    private void Update()
    {
       
        Vector3Int gridMovement = new Vector3Int();


        if(transform.position == grid.CellToWorld(_targetCell)) {
           

            if (Input.GetKey(KeyCode.W))
            {
                _renderer.flipX = true;
                animator.Play("Runs");
                gridMovement.x += 1;

            }

            if (Input.GetKey(KeyCode.S))
            {
                _renderer.flipX = false;
                gridMovement.x -= 1;
                animator.Play("Runs2");
            }
      
            if (Input.GetKey(KeyCode.A))
            {
                _renderer.flipX = false;
                gridMovement.y += 1;
                animator.Play("Runs");

            }
            if (Input.GetKey(KeyCode.D))
            {
                _renderer.flipX = true;
                gridMovement.y -= 1;
                animator.Play("Runs2");
            }
            if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.W))
            {
            
                if (!Input.GetKey(KeyCode.S))
                {
                    animator.Play("Idle2");
                }
                if (!Input.GetKey(KeyCode.A))
                {

                    Debug.Log("HUH");
                }
                animator.Play("Idles");
            }
        

            if (gridMovement != Vector3Int.zero)
            {
                _targetCell += gridMovement;
                _targetPosition = grid.CellToWorld(_targetCell);
                // Debug.Log(gridMovement.ToString());
                
            }

        

        }

       
        MoveToward(_targetPosition);
    }

    private void MoveToward(Vector3 target)
    {


      

        transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);
       

    }
}
