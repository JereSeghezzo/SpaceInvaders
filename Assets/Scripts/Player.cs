using UnityEngine;

public class Player : MonoBehaviour
{
 [SerializeField] float speed;
 [SerializeField] float shootCD;
 float cd;
 public Projectile laserPrefab;

 private void Update()
 {
    if (cd < shootCD)
    {
        cd += Time.deltaTime;
    }

    if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && this.transform.position.x > -14f)
    {
     this.transform.position += Vector3.left * speed * Time.deltaTime;
    }
    else if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && this.transform.position.x < 14f) 
    {
     this.transform.position += Vector3.right * speed * Time.deltaTime;
    }

    if((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && cd >= shootCD)
    {
        Shoot();
    }
 }

 private void Shoot()
 {
  Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
  cd = 0f;
 }
}
