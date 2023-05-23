using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void LateUpdate()
    {
        UpdateAnim();
    }
    public void UpdateAnim()
    {
        anim.SetBool(ANIM_PARAM.Move, PlayerController.Instance.running);
        anim.SetBool(ANIM_PARAM.Jump, PlayerController.Instance.jumping);
        anim.SetBool(ANIM_PARAM.Slide, PlayerController.Instance.sliding);
    }
}
public struct ANIM_PARAM
{
    public const string Move = "isMove";
    public const string Jump = "isJump";
    public const string Slide = "isSlide";
}
