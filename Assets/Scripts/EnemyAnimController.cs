using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimController : MonoBehaviour
{
    public const string strIsAttack = "isAttack";
    public Animator anim;

    public void UpdateAnim(bool isShoot)
    {
        anim.SetBool(strIsAttack, isShoot);
    }
}

