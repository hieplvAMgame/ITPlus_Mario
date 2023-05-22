using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private PlayerController playerController;
    private Animator anim;
    private void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
        anim = GetComponent<Animator>();
    }
    private void LateUpdate()
    {
        anim.SetBool(ANIM_PARAM.Move, playerController.running);
        anim.SetBool(ANIM_PARAM.Jump, playerController.jumping);
        anim.SetBool(ANIM_PARAM.Slide, playerController.sliding);
    }
}
public struct ANIM_PARAM
{
    public const string Move = "isMove";
    public const string Jump = "isJump";
    public const string Slide = "isSlide";
}
