using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float damage;
    public List<Vector2> directionBullet = new List<Vector2>();
    public Transform shootingPoint1, shootingPoint2;

    public float fireRate = 2f;
    private float _curTime = 0;

    // Update is called once per frame
    void Update()
    {
        _curTime += Time.deltaTime;
        if (_curTime >= fireRate)
        {
            Shoot(true);
            Shoot(false);
            _curTime = 0;
        }
    }
    public void Shoot(bool isRight)
    {
        GameObject obj = ObjectPooling.Instance.GetObjectFromPool("BulletCannon");
        int ran = Random.Range(0, directionBullet.Count);
        if (isRight)
        {
            obj.GetComponent<CannonBullet>().Setup(directionBullet[ran], damage);
            obj.transform.position = shootingPoint2.position;
        }
        else
        {
            obj.GetComponent<CannonBullet>().Setup(new Vector2(-directionBullet[ran].x, directionBullet[ran].y), damage);
            obj.transform.position = shootingPoint1.position;
        }
        obj.SetActive(true);
    }
}
