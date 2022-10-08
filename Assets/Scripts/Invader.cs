using UnityEngine;

public class Invader : MonoBehaviour
{
 [SerializeField] float shootMinCD;
 [SerializeField] float shootMaxCD;
 float shootReady;
 float cd;
 public Projectile laserPrefab;

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
  Instantiate(this.laserPrefab, this.transform.position, Quaternion.identity);
 }
}
