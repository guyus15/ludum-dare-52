using UnityEngine;

public class Player : MonoBehaviour, IMoveable
{
    [field: SerializeField, Header("Movement")]
    public float MoveSpeed { get; set; }
    public Vector2 Velocity { get; set; }

    private Rigidbody2D _rb2d;

    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        _rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void FixedUpdate()
    {
        Move();
    }

    public void Move()
    {
        _rb2d.velocity = new Vector2(Input.GetAxis("Horizontal") * MoveSpeed, Input.GetAxis("Vertical") * MoveSpeed);

        Vector3 mousePosition = Input.mousePosition;
        Vector3 playerScreenPosition = Camera.main.WorldToScreenPoint(transform.position);

        mousePosition.x -= playerScreenPosition.x;
        mousePosition.y -= playerScreenPosition.y;

        float angle = Mathf.Atan2(mousePosition.y, mousePosition.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
