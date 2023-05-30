using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedGroundEnemyController : MonoBehaviour
{
    private Vector2 velocity;
    public Rigidbody2D rb;
    public Transform shootingPoint;
    public EnemyAnimController animController;

    public float damage = 2;
    public float speed = 2;
    public float minX = -10;
    public float maxX = 10;
    public float disCheck = .75f;   // check detech obstacles
    public float disDetechPlayer = 1.5f;

    public float delayTimeToShoot = 1f;

    private bool isDetectPlayer = false;
    private bool isShooting = false;
    private bool canMove = true;
    private float _curTime = 0;
    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.right * speed, disCheck, LayerMask.GetMask("Obstacles"));
        isDetectPlayer = Physics2D.Raycast(rb.position, Vector2.right * speed, disDetechPlayer, LayerMask.GetMask("Player"));
        if (hit.collider != null)
            speed = -speed;
        if (speed > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
            transform.eulerAngles = Vector3.up * 180;
        if (isDetectPlayer && !isShooting)
        {
            isShooting = true;
            canMove = false;
            animController.UpdateAnim(isShooting);
            Shoot(speed >= 0);
        }
        if (isShooting) Reloading();
    }
    private void Reloading()
    {
        _curTime += Time.deltaTime;
        if (_curTime >= .3f) canMove = true;
        if (_curTime >= delayTimeToShoot)
        {
            isShooting = false;
            animController.UpdateAnim(isShooting);
            _curTime = 0;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(rb.position, rb.position + new Vector2(disDetechPlayer * speed / Mathf.Abs(speed), 0));
    }
    private void FixedUpdate()
    {
        if (canMove)
            Movement();
    }
    private void Movement()
    {
        Vector2 pos = rb.position;
        if (pos.x == maxX || pos.x == minX) speed = -speed;
        pos.x += speed * Time.fixedDeltaTime;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        rb.MovePosition(pos);
    }
    private void Shoot(bool isRight)
    {
        GameObject obj = ObjectPooling.Instance.GetObjectFromPool("HammerBullet");
        if (isRight)
        {
            obj.GetComponent<HammerBullet>().Setup(new Vector2(1, 1), damage);
            obj.transform.position = shootingPoint.position;
        }
        else
        {
            obj.GetComponent<HammerBullet>().Setup(new Vector2(-1, 1), damage);
            obj.transform.position = shootingPoint.position;
        }
        obj.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            // tru mau player
            speed = -speed;
        }
    }
}
