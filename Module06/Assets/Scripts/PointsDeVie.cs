using UnityEngine;
using UnityEngine.UI;

public class PointsDeVie : MonoBehaviour
{
    [SerializeField] private int _pointsDeVieMax;
    private Slider _sliderPointsDeVie;
    private int _pointsDeVie;

    // Start is called before the first frame update
    void Start()
    {
        _pointsDeVie = _pointsDeVieMax;
        _sliderPointsDeVie = GetComponentInChildren<Slider>();
    }

    public void RetirerPointsDeVie(int dommages)
    {
        
        _pointsDeVie -= dommages;
        _sliderPointsDeVie.normalizedValue = (float)_pointsDeVie / _pointsDeVieMax;
        if (_pointsDeVie <= 0)
        {
            ComportementEnnemi mourant = GetComponent<ComportementEnnemi>();
            GetComponent<ComportementEnnemi>().ChangerEtat(new EtatMort(mourant));
        }
    }


}
