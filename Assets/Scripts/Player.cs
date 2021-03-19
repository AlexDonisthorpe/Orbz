using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float maxDistance = 30f;

    private SphereManager _sphereManager;

    void Start()
    {
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
                }
            }
        }
    }
}
