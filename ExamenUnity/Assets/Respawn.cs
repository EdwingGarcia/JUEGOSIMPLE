using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour
{
    public Transform respawnPoint;
    public float fallThreshold = -10f;

    private void Update()
    {
        // Detectar si el personaje ha caído por debajo del umbral de caída
        if (transform.position.y < fallThreshold)
        {
            // Resetear la posición del personaje al punto de respawn
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        // Restablecer la posición del personaje al punto de respawn
        transform.position = respawnPoint.position;

        // También puedes restablecer otros aspectos del personaje, como la rotación o la velocidad
    }
}