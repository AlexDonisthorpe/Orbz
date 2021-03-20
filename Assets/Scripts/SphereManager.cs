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
    }

    private void SpawnNewSphere()
    {
        if (sphereList.Count >= maxSpheres) return;

        var newSphere = Instantiate(spherePrefab, GetRandomPosition(), Quaternion.identity);
        newSphere.transform.SetParent(gameObject.transform, true);
        newSphere.GetComponent<MeshRenderer>().material.SetColor("_Color", GetRandomColor());
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
        Color newColor = GetRandomColor();
        sphere.transform.position = GetRandomPosition();
        sphere.GetComponent<MeshRenderer>().material.SetColor("_Color", newColor);
        sphere.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", newColor);
        SpawnNewSphere();
    }

    private Color GetRandomColor()
    {
        Color[] sphereColors = { Color.red, Color.blue, Color.yellow };
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
