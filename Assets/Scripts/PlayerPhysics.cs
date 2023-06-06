using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysics : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Goomba"))
        {
            Vector2 contactPoint = collision.GetContact(0).point;
            if (Mathf.Abs(Vector2.Angle(contactPoint - GetComponent<Rigidbody2D>().position, Vector2.down)) < 25f)
                collision.transform.GetComponent<EnemyController>().ShowDeathAnim();
            else
            {
                EnemyData enem = collision.transform.GetComponent<EnemyData>();
                GetComponent<PlayerData>().GetDamage(enem.damage, (isDie) =>
                 {
                     if (isDie)
                     {
                         //Show Anim Die
                         gameObject.SetActive(false);
                     }
                     else
                     {
                         PlayerController.Instance.playerAnim.AnimHurt();
                     }
                 });
            }
        }
        //if (collision.gameObject.CompareTag("Bullet"))
        //{
        //    int damageTaken = collision.gameObject.GetComponent<Bullet>().damage;
        //    PlayerController.Instance.GetDamage(damageTaken);
        //    PlayerController.Instance.playerAnim.AnimHurt();
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("UnderGround"))
        {
            gameObject.SetActive(false);
            //Reset Game;
        }
    }
}
