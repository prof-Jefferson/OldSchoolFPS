using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Header("Sensibilidade do mouse")]
    public float sensitivity = 100f;

    [Header("Referência ao corpo do player (para rotacionar)")]
    public Transform playerBody;

    float xRotation = 0f;

    void Start()
    {
        // Oculta e bloqueia o cursor no centro da tela
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;

        // Gira o corpo do jogador no eixo Z (se estiver deitado) ou Y (FPS padrão)
        playerBody.Rotate(Vector3.forward * -mouseX); // Use Y se o player estiver em pé
    }
        
    void OnApplicationFocus(bool focus)
    {
        if (!focus)
        {
            // Mostra o cursor quando o jogo perde o foco (para evitar cursor preso)
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            // Esconde e trava o cursor quando volta para o jogo
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
