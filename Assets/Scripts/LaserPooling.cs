using UnityEngine;
using System.Collections.Generic;

public class LaserPooling : MonoBehaviour
{
 public static LaserPooling instance {get; private set;}
 GameObject laser;
 [SerializeField] int amountToPool;
 public List<GameObject> lasers;
 

 private void Awake() 
 {
    if(instance != null && instance != this) Destroy(this.gameObject);
    else instance = this; 
 }

 void Start()
 {
    InstantiateLasers();
 }

 private void InstantiateLasers()
 {
    laser = Resources.Load<GameObject>("Prefabs/Laser");
    GameObject newObject;
    for(int i = 0; i < amountToPool; i++)
    {
        newObject = Instantiate(laser);
        newObject.SetActive(false);
        lasers.Add(newObject); 
    }
  }

    public GameObject GetNewLaser()
    {
        foreach (GameObject item in lasers) if (!item.activeInHierarchy) return item ;
        return null;
    }
}
