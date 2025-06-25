using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour
{
    [Header("Referência da UI da arma")]
    public Image armaUI;

    [Header("Sprites da Animação")]
    public Sprite idleSprite;
    public Sprite fireSprite1;
    public Sprite fireSprite2;
    public Sprite tickSprite;

    [Header("Som do disparo")]
    public AudioSource audioSource;
    public AudioClip somDisparo;
    public AudioClip somTick;
    

    [Header("Tempos da animação")]
    public float tempoQuadro = 0.05f;
     public float tempoTick = 0.05f;
     
    
    [Header("RayCast do Disparo")]
    public RaycastShooter raycastShooter;

    private bool animando = false;

    void Start()
    {
        armaUI.sprite = idleSprite;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !animando)
        {
            StartCoroutine(AnimarDisparo());
        }
    }

    System.Collections.IEnumerator AnimarDisparo()
    {
        animando = true;

        // Toca som
        if (audioSource && somDisparo)
            audioSource.PlayOneShot(somDisparo);

        // Sequência de quadros
        armaUI.sprite = fireSprite1;
        yield return new WaitForSeconds(tempoQuadro);

        armaUI.sprite = fireSprite2;
        yield return new WaitForSeconds(tempoQuadro);

        // Executa Raycast
        raycastShooter?.DispararRaycast();

        // Tick (recarga visual + som)
        if (audioSource && somTick)
            audioSource.PlayOneShot(somTick);

        armaUI.sprite = tickSprite;
        yield return new WaitForSeconds(tempoTick);

        // Volta ao estado idle
        armaUI.sprite = idleSprite;

        animando = false;
        
        // Após a animação
        raycastShooter?.DispararRaycast();
    }
}
