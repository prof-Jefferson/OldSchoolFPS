using UnityEngine;

public class RaycastShooter : MonoBehaviour
{
    [Header("Alcance do disparo")]
    public float alcance = 100f;

    [Header("Camada dos alvos (opcional)")]
    public LayerMask layerAlvo;

    /// <summary>
    /// Executa o raycast a partir do centro da tela e retorna o objeto atingido.
    /// </summary>
    public void DispararRaycast()
    {
        Camera cam = Camera.main;

        if (cam == null)
        {
            Debug.LogWarning("Câmera principal não encontrada!");
            return;
        }

        Ray ray = cam.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));
        if (Physics.Raycast(ray, out RaycastHit hit, alcance, layerAlvo))
        {
            Debug.Log($"Objeto atingido: {hit.collider.gameObject.name}");

            // Exemplo: aplicar efeito visual
            // hit.collider.GetComponent<Renderer>()?.material.color = Color.red;
        }
        else
        {
            Debug.Log("Nenhum objeto atingido.");
        }
    }
}
