using UnityEngine;
using Vuforia;

public class DetectIA : MonoBehaviour
{
    public GameObject texte;

    void Start()
    {
        // cacher le texte au début
        texte.SetActive(false);

        // récupérer le composant Vuforia
        var observer = GetComponent<ObserverBehaviour>();

        // écouter les changements de détection
        if (observer)
        {
            observer.OnTargetStatusChanged += OnStatusChanged;
        }
    }

    void OnStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
    {
        // si l'image est détectée
        if (status.Status == Status.TRACKED || status.Status == Status.EXTENDED_TRACKED)
        {
            texte.SetActive(true);
        }
        else
        {
            texte.SetActive(false);
        }
    }
}