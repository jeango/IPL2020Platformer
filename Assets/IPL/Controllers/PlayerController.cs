using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Movement movement;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //déplacement droite-gauche
        var h = Input.GetAxisRaw("Horizontal");
        movement.Move(h, 0);
        if (Input.GetButtonDown("Jump"))
            movement.Jump();

    }
}