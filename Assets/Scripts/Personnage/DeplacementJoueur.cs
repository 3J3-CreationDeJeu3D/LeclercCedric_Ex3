using UnityEngine;

public class DeplacementJoueur : MonoBehaviour
{
    [Header("Paramètres de mouvement")]
    [SerializeField] float vitesseDeplacement = 5f;
    public float vitesseRotation = 200f;
    Vector3 deplacementAvant;

    [Header("Paramètres de saut")]
    [SerializeField] float hauteurSaut = 2f;
    [SerializeField] float gravite = -9.81f;
    Vector3 deplacementVertical;

    [Header("Paramètres deplacement special")]
    [SerializeField] float forceSpeciale = 5f;
    [SerializeField] float decelerationSpeciale = 15f;
    Vector3 deplacementSpecial;

    [Header("Composants")]
    CharacterController characterController;
    Animator animator;

    // ========================================

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // ========================================
    // public Vector3 CalculerDeplacement(Vector2 controleJoueur)
    // {

    // }

    // public Vector3 CalculerGravite()
    // {

    // }

    // public Vector3 CalculerForceSpeciale()
    // {


    // }

    public void MettreAJourRotation(float directionX)
    {
    }

    public void MettreAJourDeplacement(Vector3 direction)
    {
    }

    // ========================================

    public void Sauter()
    {

    }

    public void Dash()
    {
        deplacementSpecial += transform.forward * forceSpeciale; // Appliquer une force vers l'avant du joueur
    }

    public void AjouterForce(Vector3 direction, float force)
    {
        deplacementSpecial += direction * force;
    }




}
