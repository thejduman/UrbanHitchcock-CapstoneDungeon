using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;
    public IInteractable Interactable { get; set; }
    
    public float playerSpeed;
    private Rigidbody2D rb;

    public static bool NearInteractable = false;
    private Vector2 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(directionX, directionY).normalized;

        if( Input.GetKeyDown(KeyCode.E))
        {
            if(Interactable != null)
            {
                Interactable.Interact(this);
            }
        }

        //if(Input.GetKeyDown(KeyCode.M) == true)
        //{
        //    
        //}

    }

    // Called once per physics frame
    void FixedUpdate()
    {
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);
    }
}
