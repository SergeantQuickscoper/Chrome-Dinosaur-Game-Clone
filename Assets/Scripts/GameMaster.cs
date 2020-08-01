using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
   public Transform RespawnPoint;
   public Transform PlayerPrefab;
   private ScoreManager scoreManager;

   void Awake()
   {
     scoreManager = GameObject.FindObjectOfType<ScoreManager>();
   }
   public void RespawnPlayer(bool DeathState, PlayerMovement CurrentPlayerInstance)
   {
       Destroy(CurrentPlayerInstance.gameObject);
       Instantiate(PlayerPrefab, RespawnPoint.transform.position, Quaternion.identity);
       scoreManager.score = 0;
   }
}
