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
    private SpriteRenderer _renderer;
    private KeyCode lastHitKey;
    private void Start()
    {
        // Get initial position of the player on the world grid
        Vector3 initialPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        _renderer = GetComponent<SpriteRenderer>();
        _targetCell = grid.WorldToCell(initialPosition);
       
        // Snap the player to the center of the initial cell
        _targetPosition = grid.CellToWorld(_targetCell);
    }

    private void Update()
    {
       
        Vector3Int gridMovement = new Vector3Int();
        

        if(transform.position == grid.CellToWorld(_targetCell)) {
           
            //Refactor this later --> Shit code
            
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D))
            {
                _renderer.flipX = true;

                if (Input.GetKey(KeyCode.W))
                {
                    lastHitKey = KeyCode.W;
                    animator.Play("Runs");
                    gridMovement.x += 1;
                }
               else if (Input.GetKey(KeyCode.D))
                {
                    lastHitKey = KeyCode.D;
                    gridMovement.y -= 1;
                    animator.Play("Runs2");
                }
                
            }
            
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A))
            {
                _renderer.flipX = false;

                if (Input.GetKey(KeyCode.S))
                {
                    lastHitKey = KeyCode.S;
                    gridMovement.x -= 1;
                    animator.Play("Runs2");
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    lastHitKey = KeyCode.A;
                    gridMovement.y += 1;
                    animator.Play("Runs");

                }

            }

            else if (gridMovement == Vector3Int.zero)
            {
                if(_renderer.flipX == true)
                {
                    if(lastHitKey == KeyCode.W)
                    {
                        animator.Play("Idles");
                    }
                    else
                    {
                        animator.Play("Idle2");
                    }
                   
                }
                else
                {
                    if(lastHitKey == KeyCode.S)
                    {
                        animator.Play("Idle2");
                    }
                    else
                    {
                        animator.Play("Idles");
                    }
                   
                }
               
            }
            //Refactor this later
            if (gridMovement != Vector3Int.zero && gridMovement != new Vector3(1,1,0) && gridMovement != new Vector3(-1,-1,0))
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
