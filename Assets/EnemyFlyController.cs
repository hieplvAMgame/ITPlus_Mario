using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyController : MonoBehaviour
{
    public Transform shootingPoint;
    public float minX, maxX;
    public float speed;
    public float damage;
    public float fireRate;
    private float _curTime;


    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position + Vector3.left * speed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        if (pos.x == maxX || pos.x == minX) speed = -speed;
        transform.position = pos;
        Shoot();
    }
    private void Shoot()
    {
        _curTime += Time.deltaTime;
        if(_curTime>=fireRate)
        {
            GameObject obj = ObjectPooling.Instance.GetObjectFromPool("FireBullet");
            obj.GetComponent<FireBullet>().Setup(damage);
            obj.transform.position = shootingPoint.position;
            obj.SetActive(true);
            _curTime = 0;
        }
    }
}
