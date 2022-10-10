using UnityEngine;

public class Player : MonoBehaviour
{
 [SerializeField] float speed;
 [SerializeField] float shootCD;
 float cd;

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
 AudioManager.instance.InstantiateSound("shoot");   
 GameObject laser = LaserPooling.instance.GetNewLaser();
 laser.transform.position = this.transform.position;
 laser.GetComponent<Projectile>().direction = new Vector3(0, 1, 0); 
 laser.GetComponent<SpriteRenderer>().color = Color.green;
 laser.layer = 8;
 laser.SetActive(true);
  cd = 0f;
 }
}
