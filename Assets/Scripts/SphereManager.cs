using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SphereManager : MonoBehaviour
{
    [SerializeField] private GameObject spherePrefab;

    [SerializeField] int maxSpheres = 5;
    [SerializeField] float xBounds = 9f;
    [SerializeField] float yBounds = 4.5f;
    [SerializeField] float zBounds = 6f;

    List<GameObject> sphereList = new List<GameObject>();

    private void OnEnable()
    {
        LevelTimer.TimeUp += DeleteSpheres;
    }

    public void StartGame()
    {
        SpawnNewSphere();
        AkSoundEngine.PostEvent("MenuStop", gameObject);
    }

    private void SpawnNewSphere()
    {
        if (sphereList.Count >= maxSpheres) return;

        var newSphere = Instantiate(spherePrefab, GetRandomPosition(), Quaternion.identity);
        newSphere.transform.SetParent(gameObject.transform, true);
        newSphere.GetComponent<Sphere>().SetColour(GetRandomColor());
        sphereList.Add(newSphere);
    }

    private Vector3 GetRandomPosition()
    {
        float randX = Random.Range(-xBounds, xBounds);
        float randY = Random.Range(-yBounds, yBounds);
        float randZ = Random.Range(-zBounds, zBounds);

        return new Vector3(randX, randY, randZ);
    }

    public void MoveSphere(GameObject sphere)
    {
        Colours.ColourNames newColour = GetRandomColor();
        sphere.transform.position = GetRandomPosition();
        sphere.GetComponent<Sphere>().SetColour(newColour);
        SpawnNewSphere();
        AkSoundEngine.PostEvent("POP", gameObject);
    }

    private Colours.ColourNames GetRandomColor()
    {
        Colours.ColourNames[] sphereColors = { Colours.ColourNames.Red, Colours.ColourNames.Blue, Colours.ColourNames.Yellow };
        return sphereColors[Random.Range(0, 3)];
    }

    private void DeleteSpheres()
    {
        foreach(GameObject sphere in sphereList)
        {
          

            Destroy(sphere);
        }
    }
}
