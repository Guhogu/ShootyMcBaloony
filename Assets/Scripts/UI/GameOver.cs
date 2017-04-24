using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class GameOver : MonoBehaviour {

    int index;

    Image render;
    [SerializeField]
    Sprite[] choices;

    float cooldown = 0.1f;

    // Use this for initialization
    void Start()
    {
        render = GetComponent<Image>();
        if(FindObjectOfType<GameController>())
            Destroy(FindObjectOfType<GameController>().gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        cooldown -= Time.deltaTime;

        if (Input.GetButtonDown("Enter"))
        {
            switch (index)
            {
                case 0:
                    SceneManager.LoadScene("MainScene");
                    break;
                case 1:
                    SceneManager.LoadScene("MainMenu");
                    break;
                case 2:
                    Application.Quit();
                    break;

            }
        }

        if (cooldown < 0 && Mathf.Abs(Input.GetAxisRaw("Vertical")) > 0.5)
        {
            index += (int)Mathf.Round(-Input.GetAxisRaw("Vertical"));
            cooldown = 0.1f;
        }
        if (index < 0)
            index += 3;

        index = index % 3;

        render.sprite = choices[index];

    }
}
