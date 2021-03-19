using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] Texture2D cursorTexture;
    [SerializeField] float maxDistance = 30f;

    private ScoreManager _scoreManager;
    private SphereManager _sphereManager;

    void Start()
    {
        Cursor.SetCursor(cursorTexture, new Vector2(cursorTexture.width / 2, cursorTexture.height / 2), CursorMode.Auto);

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
