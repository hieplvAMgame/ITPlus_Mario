using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public float damage;
    public float speed;

    private void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
    public void Setup(float _damage)
    {
        damage = _damage;
    }
    private void ResetBullet()
    {
        transform.position = Vector3.zero;
        transform.eulerAngles = Vector3.zero;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            this.gameObject.SetActive(false);
            ResetBullet();
        }
    }
}
