using UnityEngine;
using System.Collections.Generic;

public class ActivateObjectByIndex : MonoBehaviour
{
    [SerializeField] private float _divisionValue = 25.0f;
    [SerializeField] private Transform _targetTransform;
    [SerializeField] private List<GameObject> _gameObjectList;

    private int currentIndex = -1;

    private void Update()
    {
        // Calculate the index based on the X position divided by the divisionValue
        int index = Mathf.FloorToInt(_targetTransform.position.x / _divisionValue);

        //is index is changed, then update the content
        if (index != currentIndex)
        {
            // Set the content active/inactive based on the index
            for (int i = 0; i < _gameObjectList.Count; i++)
            {
                // next, current , previous will active
                bool isActive = i == index || i == index + 1 || i == index - 1;
                SetContentActiveWithIndex(isActive, i);
            }

            // Update the currentIndex
            currentIndex = index;
        }
    }

    private void SetContentActiveWithIndex(bool value, int index)
    {
        // Check if the index is valid for the gameObjectList
        if (index >= 0 && index < _gameObjectList.Count)
        {
            // Activate the GameObject at the calculated index
            _gameObjectList[index].SetActive(value);
        }
    }
}