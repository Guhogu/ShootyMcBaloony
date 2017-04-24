using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessGeneration : MonoBehaviour {


    float nextGenerationPosition = 0;

    [SerializeField]
    int generateAmount;

    [SerializeField]
    GameObject[] prefabs;

	// Use this for initialization
	void Start () {
        if (FindObjectOfType<GameController>().isEndless)
            GenerateSegment();
        else
            gameObject.SetActive(false);

        
	}

    void GenerateSegment()
    {
        for(int i = 0; i < generateAmount; ++i)
        {
            GameObject newPart = Instantiate(prefabs[Random.Range(0, prefabs.Length)]);
            newPart.transform.position = new Vector3(nextGenerationPosition, 0, newPart.transform.position.z);

            float size = 0;

            foreach (Transform t in newPart.GetComponentsInChildren<Transform>())
                size = Mathf.Max(size, t.localPosition.x);

            nextGenerationPosition += size + 30;
        }
    }

	// Update is called once per frame
	void Update () {
		if(transform.position.x > nextGenerationPosition + 1080)
        {
            GenerateSegment();
        }
	}
}
