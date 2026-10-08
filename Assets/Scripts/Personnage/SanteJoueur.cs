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

    }
    public void RecevoirDegats(int degats)
    {

    }

    public void Soigner(int soins)
    {

    }


    // public IEnumerator Mourir()
    // {

    // }
}
