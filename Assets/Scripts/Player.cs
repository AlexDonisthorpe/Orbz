using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float maxDistance = 30f;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast (ray, out hit, maxDistance))
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}
