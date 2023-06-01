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
    public void AnimHurt()
    {
        Debug.LogError("ANIM HURT");
        StartCoroutine(IAnimHurt());
    }
    private float _curTime = 0;
    private IEnumerator IAnimHurt()
    {
        PlayerController.Instance.DisablePhysic();
        for(int i = 0; i < 3; i++)
        {
            GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(.2f);
            GetComponent<SpriteRenderer>().color = Color.white;
            yield return new WaitForSeconds(.2f);
        }
        PlayerController.Instance.EnablePhysics();
    }
}
public struct ANIM_PARAM
{
    public const string Move = "isMove";
    public const string Jump = "isJump";
    public const string Slide = "isSlide";
}
