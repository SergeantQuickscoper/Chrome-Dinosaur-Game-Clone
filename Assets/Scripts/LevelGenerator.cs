using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    [SerializeField]private Transform levelPart;
    [SerializeField]private Transform startingLevelPart;

    // Start is called before the first frame update
    void Start()
    {
        Transform lastLevelPart = SpawnLevelPart(startingLevelPart.Find("EndPosition").position);
        lastLevelPart = SpawnLevelPart(lastLevelPart.Find("EndPosition").position);
        lastLevelPart = SpawnLevelPart(lastLevelPart.Find("EndPosition").position)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform SpawnLevelPart(Vector3 SpawnPosition)
    {
        Transform levelPartTransform = Instantiate(levelPart, SpawnPosition, Quaternion.identity);
        return levelPartTransform;
    }
}
