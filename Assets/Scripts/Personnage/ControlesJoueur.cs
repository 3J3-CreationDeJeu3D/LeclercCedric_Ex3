using UnityEngine;
using UnityEngine.InputSystem;


// Tous les états possibles du personnage, qui déterminent quelles actions sont autorisées à un moment donné.
public enum EtatPerso
{
    LIBRE,
    SAUT,
    ATTAQUE,
    BLESSE,
    INTERACTION,
    MORT,
    FINJEU

}
// Les fonctionnalités sont séparées en plusieurs scripts pour une meilleure organisation et maintenabilité. 
// Ce script principal gère les entrées du joueur et l'état du personnage, 
// tandis que d'autres scripts gèrent les aspects spécifiques comme le déplacement, la santé, le combat et l'interaction.
public class ControlesJoueur : MonoBehaviour
{

    [Header("États")]
    public EtatPerso etatPerso = EtatPerso.LIBRE;

    [Header("Touches")]
    [SerializeField] InputAction deplacementAction;
    [SerializeField] InputAction sautAction;
    [SerializeField] InputAction dashAction;
    [SerializeField] InputAction interactionAction;
    [SerializeField] InputAction attaqueAction;


    [Header("Deplacements")]
    Vector3 deplacementTotal = Vector3.zero; // Le déplacement total du joueur, combinant le mouvement, la gravité et les forces spéciales
    Vector3 deplacementGeneral = Vector3.zero; // Le déplacement calculé à partir des entrées du joueur
    Vector3 deplacementGravite = Vector3.zero; // Le déplacement vertical calculé à partir de la gravité
    Vector3 deplacementSpecial = Vector3.zero; // Le déplacement spécial calculé à partir des forces spéciales (comme une poussée ou le dash)


    [Header("Connexion avec les autres scripts du personnage")]
    SanteJoueur santeJoueur;
    DeplacementJoueur deplacementJoueur;
    CombatJoueur combatJoueur;
    InteractionJoueur interactionJoueur;
    CharacterController characterController;
    Animator animator;

    // ======================================== 
    // Activer et désactiver les actions d'entrée du joueur lorsque le script est activé ou désactivé
    void OnEnable()
    {
        deplacementAction.Enable();
        sautAction.Enable();
        interactionAction.Enable();
        attaqueAction.Enable();
        dashAction.Enable();
    }
    void OnDisable()
    {
        deplacementAction.Disable();
        sautAction.Disable();
        interactionAction.Disable();
        attaqueAction.Disable();
        dashAction.Disable();
    }

    // ========================================
    void Start()
    {
        santeJoueur = GetComponent<SanteJoueur>();
        deplacementJoueur = GetComponent<DeplacementJoueur>();
        combatJoueur = GetComponent<CombatJoueur>();
        interactionJoueur = GetComponent<InteractionJoueur>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    // Script principal du joueur, qui gère les entrées et les états du personnage et déclenche les autres actions
    void Update()
    {
        // Si le jeu est en pause, ne pas exécuter les actions du joueur.
        //On remet le deplacement total à zero à chaque début de frame;
        deplacementTotal = Vector3.zero;


        //1. Lire les entrées
        //Déplacement, saut, attaque, interaction.
        Vector2 deplacementInput = deplacementAction.ReadValue<Vector2>();
        bool sautInput = sautAction.WasPressedThisFrame();
        bool dashInput = dashAction.WasPressedThisFrame();
        bool interactionInput = interactionAction.WasPressedThisFrame();
        bool attaqueInput = attaqueAction.WasPressedThisFrame();

        // 2. Traiter les actions
        // Quand le personnage est libre, il peut se déplacer et sauter. 
        // Si le personnage est dans un autre état, il ne peut pas se déplacer ni sauter, 
        // mais peut effectuer d'autres actions comme attaquer ou interagir.


        //Placer ici les autres actions autorisées en état LIBRE, comme l'attaque et l'interaction.


        // Placer ici les autres actions autorisées peut importe l'état comme la pause.


        //================================
        // Ne pas exécuter d'autres actions à partir de ce point.
        // ===============================

        // 3. Calculer la gravité et le déplacement spécial. 
        // Calculer la force spéciale (poussée, dash, autres effets) et l'ajouter au déplacement total.


        // 4. Calculer le déplacement total
        // Tenir compte du nouvel état et calculer la gravité.

        // 4. Appliquer le déplacement final et la rotation au CharacterController
        // Une seule fois par frame, en combinant les déplacements.


        // 5. Gestion de l'animation

        // 6. Gestion des autres états du joueur, comme la fin du saut après le calcul des déplacements

    }

    public void RetourEtatLibre()
    {
        etatPerso = EtatPerso.LIBRE;
    }

    public void ChangerEtat(EtatPerso nouvelEtat)
    {
        etatPerso = nouvelEtat;
    }
    public void TerminerJeu()
    {
        etatPerso = EtatPerso.FINJEU;
    }

}
