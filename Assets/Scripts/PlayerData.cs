using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : CharacterData
{
    public static PlayerData Instance;

    public List<CharacterScriptable> characterDatas = new List<CharacterScriptable>();
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }
    public bool IsCompleteTutor 
    {
        get
        {
            return PlayerPrefs.GetInt(PLAYER_KEY.IsCompleteTutor, 0) == 1;
        }
        set
        {
            PlayerPrefs.SetInt(PLAYER_KEY.IsCompleteTutor, value ? 1 : 0);
        }
    }

    public int DamageLvl
    {
        get => PlayerPrefs.GetInt(PLAYER_KEY.DamageLvl, 0);
        set => PlayerPrefs.SetInt(PLAYER_KEY.DamageLvl, value);
    }
    public int HpLvl
    {
        get => PlayerPrefs.GetInt(PLAYER_KEY.HpLvl, 0);
        set => PlayerPrefs.SetInt(PLAYER_KEY.HpLvl, value);
    }
    public int SpeedLvl
    {
        get => PlayerPrefs.GetInt(PLAYER_KEY.SpeedLvl, 0);
        set => PlayerPrefs.SetInt(PLAYER_KEY.SpeedLvl, value);
    }
    public int JumpLvl
    {
        get => PlayerPrefs.GetInt(PLAYER_KEY.JumpLvl, 0);
        set => PlayerPrefs.SetInt(PLAYER_KEY.JumpLvl, value);
    }
    public int Gold
    {
        get => PlayerPrefs.GetInt(PLAYER_KEY.Gold, 100000);
        set => PlayerPrefs.SetInt(PLAYER_KEY.Gold, value);
    }
    public int Gem
    {
        get => PlayerPrefs.GetInt(PLAYER_KEY.Gem, 50);
        set => PlayerPrefs.SetInt(PLAYER_KEY.Gem, value);
    }
    public int CurrentLevel
    {
        get => PlayerPrefs.GetInt(PLAYER_KEY.CurentLevel, 0);
        set => PlayerPrefs.SetInt(PLAYER_KEY.CurentLevel, value);
    }
    public int ClearedLevel
    {
        get => PlayerPrefs.GetInt(PLAYER_KEY.ClearedLevel, 0);
        set => PlayerPrefs.SetInt(PLAYER_KEY.ClearedLevel, value);
    }
    public int CurrentWeapon
    {
        get => PlayerPrefs.GetInt(PLAYER_KEY.CurrentWeapon, 0);
        set => PlayerPrefs.SetInt(PLAYER_KEY.CurrentWeapon, value);
    }
    public int CurrentCharacter
    {
        get => PlayerPrefs.GetInt(PLAYER_KEY.CurrentCharacter, 0);
        set => PlayerPrefs.SetInt(PLAYER_KEY.CurrentCharacter, value);
    }
}

public struct PLAYER_KEY
{
    public const string IsCompleteTutor = "IsCompleteTutor";
    public const string DamageLvl = "DamageLvl";
    public const string HpLvl = "HpLvl";
    public const string SpeedLvl = "SpeedLvl";
    public const string JumpLvl = "JumpLvl";
    public const string Gold = "Gold";
    public const string Gem = "Gem";
    public const string CurentLevel = "CurentLevel";
    public const string ClearedLevel = "ClearedLevel";
    public const string CurrentWeapon = "CurrentWeapon";
    public const string CurrentCharacter = "CurrentCharacter";
}


// PlayerController.Instance.playerData.DamageLvl++;


//
