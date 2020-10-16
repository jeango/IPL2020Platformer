using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private FireController fireController;


    // Update is called once per frame
         void Update()
         {
             //déplacement droite-gauche
             var h = Input.GetAxisRaw("Horizontal");
             movement.Move(h, 0);
             if (Input.GetButtonDown("Jump"))
                 movement.Jump();
             if (Input.GetButtonDown("Fire1"))
                 fireController.Fire();
         }
}