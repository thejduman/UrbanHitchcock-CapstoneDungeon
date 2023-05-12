using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] private DialogueUI dialogueUI;
    public DialogueUI DialogueUI => dialogueUI;
    public IInteractable Interactable { get; set; }
    
    public float playerSpeed;
    private Rigidbody2D rb;
    public Animator animator;

    public static bool NearInteractable = false;
    private Vector2 playerDirection;

    // Start is called before the first frame update
    void Start()
    {
        //DontDestroyOnLoad(gameObject);
        rb = GetComponent<Rigidbody2D>();
        dialogueUI = FindObjectOfType<DialogueUI>();
        SceneManager.sceneLoaded += SetDialogueBox;
    }

    // Update is called once per frame
    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");

        playerDirection = new Vector2(directionX, directionY).normalized;

        animator.SetFloat("Horizontal", playerDirection.x);
        animator.SetFloat("Vertical", playerDirection.y);
        animator.SetFloat("Speed", playerDirection.sqrMagnitude);

        if ( Input.GetKeyDown(KeyCode.E))
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

   private void SetDialogueBox(Scene scene, LoadSceneMode mode)
    {
        dialogueUI = FindObjectOfType<DialogueUI>();
    }
}
