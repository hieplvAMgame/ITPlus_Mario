using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Singleton<PlayerController>
{
    [SerializeField] Camera mainCamera;
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Collider2D collider;
    [SerializeField] public AnimationController playerAnim;
    [SerializeField] Transform shootingPoint;

    private Vector2 velocity;
    private float inputAxis;

    public int hp;
    public int damage = 5;
    public float moveSpeed = 8f;
    public float maxJumpHeight = 5f;
    public float maxJumpTime = 1f;
    public float jumpForce => (2f * maxJumpHeight) / (maxJumpTime / 2f);
    public float gravity => (-2f * maxJumpHeight) / Mathf.Pow(maxJumpTime / 2f, 2f);

    public bool grounded { get; private set; }
    public bool jumping { get; private set; }
    public bool running => Mathf.Abs(velocity.x) > 0.25f || Mathf.Abs(inputAxis) > 0.25f;
    public bool sliding => (inputAxis > 0f && velocity.x < 0f) || (inputAxis < 0f && velocity.x > 0f);


    private Vector2 _shootingDir;
    private void OnEnable()
    {
        rb.isKinematic = false;
        collider.isTrigger = false;
        velocity = Vector2.zero;
        jumping = false;
    }

    private void OnDisable()
    {
        rb.isKinematic = true;
        collider.enabled = false;
        velocity = Vector2.zero;
        jumping = false;
    }
    public void DisablePhysic()
    {
        rb.isKinematic = true;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        collider.isTrigger = true;
    }
    public void EnablePhysics()
    {
        rb.isKinematic = false;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        collider.isTrigger = false;
    }
    private void Update()
    {
        HorizontalMovement();
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.down, 1.05f, LayerMask.GetMask("Ground"));
        RaycastHit2D hit1 = Physics2D.Raycast(rb.position, Vector2.down, 1.05f, LayerMask.GetMask("Obstacles"));
        grounded = (hit.collider != null && hit.rigidbody != rb) || (hit1.collider != null && hit1.rigidbody != rb);
        if (grounded)
            VerticalMovement();
        ApplyGravity();
        if (Input.GetKeyDown(KeyCode.J))
            Shoot();
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(rb.position, rb.position + Vector2.down);

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(rb.position, rb.position + _shootingDir);
    }
    private void FixedUpdate()
    {
        Vector2 pos = rb.position;
        pos += velocity * Time.fixedDeltaTime;

        // Clamp player in screen
        Vector2 leftEdge = mainCamera.ScreenToWorldPoint(Vector2.zero);
        Vector2 rightEdge = mainCamera.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        pos.x = Mathf.Clamp(pos.x, leftEdge.x + 0.5f, rightEdge.x - 0.5f);

        rb.MovePosition(pos);
    }
    /// <summary>
    /// Movement control in x axis
    /// </summary>
    private void HorizontalMovement()
    {
        inputAxis = Input.GetAxis("Horizontal");
        velocity.x = Mathf.MoveTowards(velocity.x, inputAxis * moveSpeed, moveSpeed * Time.deltaTime);

        if (rb.Raycast(Vector2.right * velocity.x)) velocity.x = 0;         // Check xem va vao tuong 

        if (velocity.x > 0)
            transform.eulerAngles = Vector3.zero;
        else if (velocity.x < 0)
            transform.eulerAngles = Vector3.up * 180f;
    }
    private void VerticalMovement()
    {
        velocity.y = Mathf.Max(velocity.y, 0f);
        jumping = velocity.y > 0;

        if (Input.GetButtonDown("Jump"))
        {
            velocity.y = jumpForce;
            jumping = true;
        }
    }
    private void ApplyGravity()
    {
        bool falling = velocity.y < 0 || !Input.GetKey(KeyCode.Space);

        // increase or decrease gravity with vertical status of player
        float multiplier = falling ? 2 : 1;

        velocity.y += gravity * multiplier * Time.deltaTime;
        velocity.y = Mathf.Max(velocity.y, gravity / 2f);
    }
    public void Shoot()
    {
        _shootingDir = new Vector2(shootingPoint.position.x - transform.position.x, shootingPoint.position.y - transform.position.y);
        GameObject obj = ObjectPooling.Instance.GetObjectFromPool("Bullet");
        obj.GetComponent<BulletData>().Setup(damage, new Vector2(_shootingDir.x / Mathf.Abs(_shootingDir.x), 0));
        obj.transform.position = shootingPoint.position;
        obj.SetActive(true);
    }
    public void GetDamage(int amount)
    {
        hp = hp >= amount ? hp -= amount : 0;
    }
}
