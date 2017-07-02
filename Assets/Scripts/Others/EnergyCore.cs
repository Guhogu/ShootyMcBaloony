using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCore : MonoBehaviour {

    bool _broken;
    public bool broken
    {
        get { return broken; }
        set { _broken = value;
            if (value)
            {
                sprite.sprite = sprite_broken;
                DisableShield();
            }
        }
    }

    [SerializeField]
    int max_durability;

    public int durability;

    [SerializeField]
    SpriteRenderer sprite;

    [SerializeField]
    Sprite sprite_broken;

    [SerializeField]
    Sprite sprite_clean;

    [SerializeField]
    public int scrollingIndex;

    [SerializeField]
    GameObject portal;

    [SerializeField]
    ShieldScript shield;
    

    // Use this for initialization
    void Start () {
        durability = max_durability;
	}
	
    public void EnablePortal()
    {
        GameController.destroyedShield[scrollingIndex] = true;
        portal.SetActive(true);
        portal.GetComponent<PortalScript>().toWorld = scrollingIndex;
    }

    public void DisableShield()
    {
        shield.gameObject.SetActive(false);
        EnablePortal();
    }

    // Update is called once per frame
    void Update () {
        
	}
}
