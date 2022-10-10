using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{
 [SerializeField] int lifes;
 int points;
 [SerializeField] Text pointsText,lifesText;
 GameObject playerPrefab, playerActive;
 [SerializeField] Vector3 spawnPosition;
 [SerializeField] float timeToDeath;
 [SerializeField] GameObject winScreen, loseScreen;
 [SerializeField] int restartTime;
 public static Action findInvadersEvent;
 public static Action lifeSustractEvent;


void Start()
{
 playerPrefab = Resources.Load<GameObject>("Prefabs/Player");
 InstantiatePlayer();
}

void LifeSustract()
{
 Destroy(playerActive);
 if(lifes > 0 ) StartCoroutine(DestroyPlayer(timeToDeath));
 else GameOver("Lose");
}

 void InstantiatePlayer()
 {
    playerActive = Instantiate(playerPrefab,spawnPosition, Quaternion.identity);
 }

 IEnumerator DestroyPlayer (float time)
 {
    yield return new WaitForSeconds(time);
    InstantiatePlayer();
    lifes--;
 }

 void GameOver(string result)
 {
  if(result == "Lose")
   {
    loseScreen.SetActive(true);
   } else winScreen.SetActive(true);
   foreach (var item in FindObjectsOfType<Invader>()) item.gameObject.SetActive(false);
   StartCoroutine(RestartGame());
 }

 void FindActiveInvaders()
 {
  foreach (var item in FindObjectsOfType<Invader>())
  if (item.gameObject.activeInHierarchy) return;
  GameOver("Win");
 }

 IEnumerator RestartGame()
 {
  yield return new WaitForSeconds(restartTime);
  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
 }

 private void OnEnable() 
 {
   lifeSustractEvent += LifeSustract;
   findInvadersEvent += FindActiveInvaders;
 }

 private void OnDisable() 
 {
   lifeSustractEvent -= LifeSustract;
   findInvadersEvent -= FindActiveInvaders;
 }
}
