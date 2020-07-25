using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{

    private const float PLAYER_DISTANCE_TO_SPAWN_LEVEL_PART = 50f;
    [SerializeField]private Transform[] levelParts;
    [SerializeField]private Transform startingLevelPart;
    [SerializeField]private Transform PlayerReference;
    private Vector3 lastEndPosition;
    private float nextTimeToSearch = 0;

    // Start is called before the first frame update
    void Awake()
    {
        lastEndPosition = startingLevelPart.Find("EndPosition").position;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerReference == null) {
			FindPlayer ();
			return;
		}

        if(Vector3.Distance(PlayerReference.position, lastEndPosition) < PLAYER_DISTANCE_TO_SPAWN_LEVEL_PART)
        {
            SpawnLevelPart();
        }
    }

    public void SpawnLevelPart()
    {
        Transform chosenLevelPart = levelParts[Random.Range(0, levelParts.Length)];
        Transform lastLevelPartTransform = SpawnLevelPart(lastEndPosition, chosenLevelPart);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }

    public Transform SpawnLevelPart(Vector3 SpawnPosition, Transform LevelPart)
    {
        Transform levelPartTransform = Instantiate(LevelPart, SpawnPosition, Quaternion.identity);
        return levelPartTransform;
    }

    void FindPlayer () {
		if (nextTimeToSearch <= Time.time) {
			GameObject searchResult = GameObject.FindGameObjectWithTag ("Player");
			if (searchResult != null)
				PlayerReference = searchResult.transform;
			nextTimeToSearch = Time.time + 0.5f;
		}
	}
}
