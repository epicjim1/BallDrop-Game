using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEditor;

public class SkinManager : MonoBehaviour
{
    public int skin;
    public SpriteRenderer sr;
    public List<Sprite> skins = new List<Sprite>();
    private int selectedSkin = 0;
    public GameObject playerSkin;

    void Start()
    {
        skin = PlayerPrefs.GetInt("ChoosenSkin", 0);
    }

    void Update()
    {
        //Debug.Log(skin);
    }

    public void equip()
    {
        PlayerPrefs.SetInt("ChoosenSkin", selectedSkin);
        //PrefabUtility.SaveAsPrefabAsset(playerSkin, "Assets/Prefabs/selectedskin.prefab");
    }

    public void selectSkin (int skinNum)
    {
        selectedSkin = skinNum;
        sr.sprite = skins[selectedSkin];
    }

    public void ResetProgress()
    {
        Debug.Log("Progress deleted");
        sr.sprite = skins[0];
        //PrefabUtility.SaveAsPrefabAsset(playerSkin, "Assets/Prefabs/selectedskin.prefab");
        PlayerPrefs.DeleteAll();
    }
}
