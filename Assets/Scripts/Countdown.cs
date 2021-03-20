using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countdownText;
    [SerializeField] private GameObject countdownUI;

    private bool _hasStarted = false;

    private void Update()
    {
        if(!_hasStarted)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Animator>().SetTrigger("CountdownStart");
            }
        }
    }

    public void ChangeText(string textToChange)
    {
        countdownText.text = textToChange;
    }
    
    public void StartGame()
    {
        FindObjectOfType<LevelTimer>().StartLevel();
        Invoke("Deactivate", 1f);
    }

    private void Deactivate()
    {
        countdownUI.SetActive(false);
    }

}
