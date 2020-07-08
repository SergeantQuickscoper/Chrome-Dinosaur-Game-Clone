﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
   public Transform RespawnPoint;
   public Transform PlayerPrefab;
   public void RespawnPlayer(bool DeathState, PlayerMovement CurrentPlayerInstance)
   {
       Destroy(CurrentPlayerInstance.gameObject);
       Instantiate(PlayerPrefab, RespawnPoint.transform.position, Quaternion.identity);
   }
}