using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [Header("Ammo:")]
    public int maxAmmo;
    public int currentAmmo;
    public Text ammoText;
    [Header("About Weapon:")]
    public float fireRate;
    float fireRateReset;
    public float accuracy;
    public float reloadTime;
    float reloadTimeReset;
    public float recoil;
    public Camera mainCamera;
    

    [Header("Bullet info:")]
    public Rigidbody bulletPrefab;
    public Transform bulletSpawnPosition;
    AudioSource gunSounds;
    public AudioClip fireSound;
    public AudioClip reloadSound;
    
    Bullet bulletScript;

    [Header("Fire mode: *Single Fire is default*")]
    public bool singleFire = true;//0
    
    int fireMode = 0;

   

    private void Start()
    {

        currentAmmo = maxAmmo;
        ShowAmmo();
        fireRateReset = fireRate;
        reloadTimeReset = reloadTime;
        gunSounds = GetComponent<AudioSource>();
        bulletScript = bulletPrefab.gameObject.GetComponent<Bullet>();

         fireMode = 0;

    }

    private void Update()
    {
        fireRate -= Time.deltaTime;
        reloadTime -= Time.deltaTime;


        if (Input.GetMouseButtonDown(0) && fireMode == 0 && currentAmmo > 0 && fireRate <= 0)
        {
            Shoot();
            fireRate = fireRateReset;
        }
       
        void Shoot()
        {
            float xScreen = Screen.width / 2;
            float yScreen = Screen.height / 2;

            float xAcc = Random.Range(xScreen - accuracy, xScreen + accuracy);
            float yAcc = Random.Range(yScreen - accuracy, yScreen + accuracy);

            var ray = Camera.main.ScreenPointToRay(new Vector3(xAcc, yAcc, 0));

            currentAmmo--;
            ShowAmmo();

            Rigidbody cloneBullet;
            cloneBullet = Instantiate(bulletPrefab, bulletSpawnPosition.position, bulletSpawnPosition.rotation);
            cloneBullet.velocity = bulletScript.speed * ray.direction; //neka vrijednost brzine sa metka
            gunSounds.clip = fireSound;
            gunSounds.Play();
        }

        if (Input.GetKeyDown(KeyCode.R) && reloadTime <= 0)
        {
            currentAmmo = maxAmmo;
            ShowAmmo();
            gunSounds.clip = reloadSound;
            gunSounds.Play();
            
            reloadTime = reloadTimeReset;

        }

    }

    public void ShowAmmo()
    {
        ammoText.text = currentAmmo + "/" + maxAmmo;
    }
}
