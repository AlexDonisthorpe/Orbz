using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float maxDistance = 30f;

    private ScoreManager _scoreManager;
    private SphereManager _sphereManager;
    private OrbzCursor _cursor;

    bool gameOver = false;

    void Start()
    {
        _scoreManager = FindObjectOfType<ScoreManager>();
        _sphereManager = FindObjectOfType<SphereManager>();
        _cursor = FindObjectOfType<OrbzCursor>();

        LevelTimer.TimeUp += GameOver;
    }

    void Update()
    {
        if(!gameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, maxDistance))
                {
                    if (hit.transform.tag == "Sphere")
                    {
                        Colours.ColourNames sphereColor = hit.transform.GetComponent<Sphere>().GetColour();

                        FindObjectOfType<MatchingBox>().HandleMatchingColour(_cursor.GetColor(), sphereColor);

                        _cursor.SetColor(sphereColor);
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

    private void GameOver()
    {
        gameOver = true;
    }
}
