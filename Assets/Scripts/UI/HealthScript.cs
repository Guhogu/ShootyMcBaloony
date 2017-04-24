using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthScript : MonoBehaviour {

    [SerializeField]
    Sprite[] sprites;

    [SerializeField]
    Image image;

	// Use this for initialization
	public void UpdateLives(int left)
    {
        image.enabled = true;
        image.sprite = sprites[left % sprites.Length];
    }
}
