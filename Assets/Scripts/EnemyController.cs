using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Vector2 velocity;
    public Rigidbody2D rb;
    public GameObject liveSprite;
    public GameObject deathSprite;

    public float speed = 2;
    public float minX = -10;
    public float maxX = 10;
    public float disCheck = .75f;

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rb.position, Vector2.right * speed, disCheck, LayerMask.GetMask("Obstacles"));
        if (hit.collider != null)
            speed = -speed;
        if (speed > 0)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else
            transform.eulerAngles = Vector3.up * 180;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(rb.position, rb.position+ new Vector2(disCheck* speed/Mathf.Abs(speed),0));
    }
    private void FixedUpdate()
    {
        Vector2 pos = rb.position;
        Debug.LogError(pos);
        if (pos.x == maxX || pos.x == minX) speed = -speed;
        pos.x += speed * Time.fixedDeltaTime;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        rb.MovePosition(pos);
    }
    public void ShowDeathAnim()
    {
        StartCoroutine(DeathControl());
    }
    private IEnumerator DeathControl()
    {
        liveSprite.SetActive(false);
        deathSprite.SetActive(true);
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(.2f);
        gameObject.SetActive(false);
        liveSprite.SetActive(true);
        deathSprite.SetActive(false);
        GetComponent<CircleCollider2D>().enabled = true;
        GetComponent<BoxCollider2D>().enabled = false;
    }

}
