using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    public GameObject bulletPrefab;  // The bullet prefab to instantiate
    public float bulletSpeed = 30f;  // Speed at which the bullet will move
    public float bulletLifetime = 3f;
    public AudioClip damageSoundClip;  // The sound clip to play when shooting

    private AudioSource audioSource;  // AudioSource component to play the sound
    private bool canShoot = true;  // Whether the Shooter can shoot a bullet

    void Start()
    {
        // Get the AudioSource component
        audioSource = GetComponent<AudioSource>();

        // If there is no AudioSource component, add one
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && canShoot)
        {
            StartCoroutine(ShootBullet());
        }
    }

    private IEnumerator ShootBullet()
    {
        canShoot = false;
        GameObject bullet = Instantiate(bulletPrefab, transform.position + transform.TransformVector(0, 0, 2), transform.rotation * Quaternion.Euler(90, 0, 0));
        Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();

        // Play the shooting sound
        audioSource.PlayOneShot(damageSoundClip);

        if (bulletRigidbody != null)
        {
            bulletRigidbody.velocity = transform.forward * bulletSpeed;
        }

        yield return new WaitForSeconds(bulletLifetime);

        Destroy(bullet);

        canShoot = true;
    }
}
