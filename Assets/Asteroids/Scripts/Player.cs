using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField, Range(1, 100), Tooltip("Controls the speed of the player")] float speed = 5;
    public float rotationRate = 90;
    public GameObject prefab;
    public Transform bulletSpawnLocationL;
    public Transform bulletSpawnLocationR;

    private void Awake()
    {

    }

    void Start()
    {

    }

    void Update()
    {

        Vector3 direction = Vector3.zero;

        direction.z = Input.GetAxis("Vertical");

        Vector3 rotation = Vector3.zero;
        rotation.y = Input.GetAxis("Horizontal");

        transform.Translate(direction * speed * Time.deltaTime);
        //Quaternion rotate = Quaternion.Euler(rotation * rotationRate * Time.deltaTime);
        //transform.rotation = transform.rotation * rotate;
        transform.Rotate(rotation * rotationRate * Time.deltaTime);
        //transform.position += direction * speed * Time.deltaTime;

        if (Input.GetButtonDown("Fire1"))
        {
            //GetComponent<AudioSource>().Play();
            GameObject go = Instantiate(prefab, bulletSpawnLocationL.position, bulletSpawnLocationL.rotation);
            GameObject go1 = Instantiate(prefab, bulletSpawnLocationR.position, bulletSpawnLocationR.rotation);
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Enemy"))
		{
			FindObjectOfType<AsteroidManager>()?.SetGameOver();
		}
	}
}
