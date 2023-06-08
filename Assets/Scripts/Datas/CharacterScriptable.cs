using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character Datas")]
public class CharacterScriptable : ScriptableObject
{
    public int damage;
    public int hp;
    public float speed;
    public float jumpForce;
}
