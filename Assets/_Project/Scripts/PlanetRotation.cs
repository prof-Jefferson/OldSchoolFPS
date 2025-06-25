using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    [Header("Velocidade de rotação em graus por segundo")]
    public float rotationSpeed = 10f;

    void Update()
    {
        // Gira o planeta em torno do eixo Y
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
