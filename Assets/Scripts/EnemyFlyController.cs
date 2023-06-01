using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyController : MonoBehaviour
{
    public Transform shootingPoint;
    public float minX, maxX;
    public float speed;
    public int damage;
    public float fireRate;
    public float delayTime = .5f;

    private float _curTime;

    private bool isShooting = false;
    // Update is called once per frame
    void Update()
    {
        if (!isShooting)
        {
            Movement();
        }
        Shoot();
    }
    private void Movement()
    {
        Vector3 pos = transform.position + Vector3.left * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        if (pos.x == maxX || pos.x == minX) speed = -speed;
        transform.position = pos;
        if (speed < 0)
            transform.eulerAngles = Vector3.up * 180;
        else
            transform.eulerAngles = Vector3.zero;
    }
    private void Shoot()
    {
        _curTime += Time.deltaTime;
        if (_curTime >= fireRate && !isShooting)
        {
            isShooting = true;
            GameObject obj = ObjectPooling.Instance.GetObjectFromPool("FireBullet");
            obj.GetComponent<FireBullet>().Setup(damage, Vector2.zero);
            obj.transform.position = shootingPoint.position;
            obj.SetActive(true);
            Invoke(nameof(ResetTime), delayTime);
        }
    }
    private void ResetTime()
    {
        _curTime = 0;
        isShooting = false;
    }
}
