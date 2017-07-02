using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DashPoints : MonoBehaviour {

    [Header("References")]
    Player_Script player;
    [SerializeField]
    Transform pointPrefab;

    [Header("Properties")]
    [SerializeField]
    int length_sprite = 25;

    [SerializeField]
    int spacing = 10;


    Image[] points;

    public void Init()
    {
        player = FindObjectOfType<Player_Script>();
        points = new Image[player.dashCooldowns.Length];
        Debug.Log(player.dashCooldowns);
        for (int i = 0; i < player.dashCooldowns.Length; ++i)
        {
            Debug.Log(-(i * (length_sprite + spacing) + spacing));
            Transform point = Instantiate(pointPrefab);
            point.parent = transform;
            point.localPosition = new Vector3(-(i * (length_sprite + spacing) + spacing), spacing, 0);
            point.gameObject.SetActive(true);
            points[i] = point.GetComponent<Image>();

        }
        Debug.Log(points);
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < points.Length; ++i)
        {
            float alpha;
            if (player.dashCooldowns[i] <= 0)
                points[i].color = new Color(1, 1, 1, 1);
            else
            {
                alpha = Mathf.Lerp(0.7f, 0.1f, player.dashCooldowns[i] / player.dashCooldownTime);
                points[i].color = new Color(1, 0, 1, alpha);
            }
        }
	}
}
