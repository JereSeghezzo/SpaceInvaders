using UnityEngine;

public class Invader : MonoBehaviour
{
 [SerializeField] float shootMinCD;
 [SerializeField] float shootMaxCD;
 float shootReady;
 float cd;

 void Update()
 {
    if (cd < shootReady)
    {
        cd += Time.deltaTime;
    } else  Shoot();
 }

 void Shoot()
 {
  cd = 0f;
  shootReady = Random.Range(shootMinCD, shootMaxCD);
  GameObject laser = LaserPooling.instance.GetNewLaser();
  laser.transform.position = this.transform.position;
  laser.GetComponent<Projectile>().direction = new Vector3(0, -1, 0); 
  laser.GetComponent<SpriteRenderer>().color = Color.red;
  laser.layer = 9;
  laser.SetActive(true);
 }
}
