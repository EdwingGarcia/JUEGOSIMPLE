using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject bala;
    public float fuerzaDisparo = 1000f;
    public float cooldown = 1f;

    void Start()
    {
        StartCoroutine(StartShooting());
    }

    IEnumerator StartShooting()
    {
        while (true) // Bucle infinito
        {
            GameObject nuevaBala = Instantiate(bala, spawnPoint.position, spawnPoint.rotation);
            nuevaBala.GetComponent<Rigidbody>().AddForce(spawnPoint.forward * fuerzaDisparo);
            Destroy(nuevaBala, 2);

            yield return new WaitForSeconds(cooldown);
        }
    }
}
