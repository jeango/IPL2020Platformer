using UnityEngine;

public class SlimeController : MonoBehaviour
{
    [SerializeField] private Movement movement;
    [SerializeField] private Transform frontGroundCheck;
    [SerializeField] private Transform obstacleCheck;
    [SerializeField] private int direction = 1;
    [SerializeField] private LayerMask groundLayers;
    private RaycastHit2D[] _results = new RaycastHit2D[1];
    private Transform _transform;

    void Awake()
    {
        _transform = transform;
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Physics2D.RaycastNonAlloc(frontGroundCheck.position, Vector2.down, _results, 0.1f, groundLayers) == 0
            || Physics2D.RaycastNonAlloc(obstacleCheck.position, _transform.right, _results, 0.1f, groundLayers) > 0)
            direction = -direction;
        movement.Move(direction, 0);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        var position = frontGroundCheck.position;
        Gizmos.DrawLine(position, position + Vector3.down * 0.1f);
        position = obstacleCheck.position;
        Gizmos.DrawLine(position, position + transform.right * 0.1f);
        
    }
    
}