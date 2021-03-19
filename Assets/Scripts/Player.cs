using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float maxDistance = 30f;

    private ScoreManager _scoreManager;
    private SphereManager _sphereManager;

    void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _sphereManager = FindObjectOfType<SphereManager>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast (ray, out hit, maxDistance))
            {
                if(hit.transform.tag == "Sphere")
                {
                    _sphereManager.MoveSphere(hit.transform.gameObject);
                    _scoreManager.UpdateScore(hit.transform.localScale.x);
                }
                else
                {
                    _scoreManager.ResetMultiplyer();
                }
            }
        }
    }
}
