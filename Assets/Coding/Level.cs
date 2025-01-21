using UnityEngine;

public class Level : MonoBehaviour
{
    public float Speed = -15f;       // Vitesse de déplacement
    public float deadZone = -20f;   // Zone où les tuyaux sont réinitialisés
    public float tuyauGap = 3f;     // Écart constant entre les tuyaux
    public float fixedX = 9.65f;    // Position fixe en X des tuyaux lorsqu'ils réapparaissent

    public Transform tuyauBas;      // Transform du tuyau inférieur
    public Transform tuyauHaut;     // Transform du tuyau supérieur

    private float tuyauBasHeight;   // Hauteur totale du tuyau inférieur
    private float tuyauHautHeight;  // Hauteur totale du tuyau supérieur

    private Vector3 initPosition;   // Position initiale du groupe

    private void Start()
    {
        // Définit la position initiale avec la position X fixe
        initPosition = new Vector3(fixedX, transform.position.y, transform.position.z);

        // Applique immédiatement la position X fixe au début
        transform.position = initPosition;

        // Récupère la hauteur des tuyaux à partir de leur SpriteRenderer
        tuyauBasHeight = tuyauBas.GetComponent<SpriteRenderer>().bounds.size.y;
        tuyauHautHeight = tuyauHaut.GetComponent<SpriteRenderer>().bounds.size.y;

        // Place les tuyaux à leur position initiale
        RandomizeTuyaux();
    }

    void Update()
    {
        // Déplace le groupe de tuyaux vers la gauche
        transform.position += new Vector3(Speed * Time.deltaTime, 0f);

        // Si le groupe de tuyaux atteint la zone morte (deadZone), réinitialise sa position
        if (transform.position.x < deadZone)
        {
            // Réinitialise la position globale à la position X fixe
            transform.position = initPosition;

            // Calcule une nouvelle position aléatoire pour les tuyaux
            RandomizeTuyaux();
        }
    }

    void RandomizeTuyaux()
    {
        // Récupère la valeur aléatoire pour le centre de l’écart (le trou)
        float randomGapCenter = Random.Range(-3f, 3f);

        // Positionne le tuyau inférieur
        tuyauBas.localPosition = new Vector3(0f, randomGapCenter - (tuyauGap / 2) - (tuyauBasHeight / 2), 0f);

        // Positionne le tuyau supérieur
        tuyauHaut.localPosition = new Vector3(0f, randomGapCenter + (tuyauGap / 2) + (tuyauHautHeight / 2), 0f);

        Debug.Log($"Tuyaux positionnés : TuyauBas Y = {tuyauBas.localPosition.y}, TuyauHaut Y = {tuyauHaut.localPosition.y}");
    }
}