using UnityEngine;

public class Projectile : MonoBehaviour
{
 public Vector3 direction;

 [SerializeField] float speed;

void Update()
{
  this.transform.position += this.direction * speed * Time.deltaTime;
}

void OnTriggerEnter2D(Collider2D other) 
{
  if(other.GetComponent<Invader>() != null)
  {
    other.gameObject.SetActive(false);
     GameManager.findInvadersEvent?.Invoke();
  }

  if(other.GetComponent<Player>() != null)
  {
   GameManager.lifeSustractEvent?.Invoke();
  }
  this.gameObject.SetActive(false);
}
}
