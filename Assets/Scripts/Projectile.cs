using UnityEngine;

public class Projectile : MonoBehaviour
{
 public Vector3 direction;

 [SerializeField] float speed;

void Update()
{
  this.transform.position += this.direction * speed * Time.deltaTime;
}
}
