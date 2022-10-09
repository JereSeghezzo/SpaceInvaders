using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
 [SerializeField] int lifes;
 int points;
 [SerializeField] Text pointsText,lifesText;
 GameObject playerPrefab, playerActive;
 [SerializeField] Vector3 spawnPosition;


void Start()
{
 playerPrefab = Resources.Load<GameObject>("Prefabs/Player");
 InstantiatePlayer();
}

 void InstantiatePlayer()
 {
    playerActive = Instantiate(playerPrefab,spawnPosition, Quaternion.identity);
 }
}
