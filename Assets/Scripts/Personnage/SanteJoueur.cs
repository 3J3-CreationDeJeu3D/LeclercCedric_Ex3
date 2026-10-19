using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SanteJoueur : MonoBehaviour
{
    [Header("Gestion de la santé")]
    public float niveauOxygene = 100;
    public float niveauOxygeneMax = 100;
    public float perteOxygene = 0.1f;

    [Header("Sons")]
    [SerializeField] AudioClip sonMort;
    [SerializeField] AudioClip sonOxygene;
    [SerializeField] AudioClip sonBlesse;

    [Header("Composants")]
    ControlesJoueur controles;
    Animator animator;
    AudioSource audiosource;


    void Start()
    {
        controles = GetComponent<ControlesJoueur>();
        animator = GetComponent<Animator>();
        audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // niveauOxygene -= Time.deltaTime * perteOxygene;
        RecevoirDegats(Time.deltaTime * perteOxygene);
    }

    public void RecevoirDegats(float degats)
    {
        niveauOxygene -= degats;
        niveauOxygene = Mathf.Clamp(niveauOxygene, 0, niveauOxygeneMax);

        if (niveauOxygene <= 0 && controles.etatPerso != EtatPerso.MORT)
        {
            StartCoroutine(Mourir());
        }
    }

    public void Soigner(int soins)
    {
        niveauOxygene += soins;
        niveauOxygene = Mathf.Clamp(niveauOxygene, 0, niveauOxygeneMax);
    }


    public IEnumerator Mourir()
    {
        // Changer etat perso
        controles.etatPerso = EtatPerso.MORT;
        // Déclencher un son de fin

        // Déclencher anim mort
        animator.SetTrigger("mort");

        // Quand anim termine, redemarre jeu
        yield return new WaitForSeconds(3);
        controles.RedemarrerPartie();
    }
}
