using System.Collections.Generic;
using UnityEngine;

public class PoolingSystem : MonoBehaviour
{
    private Transform _transform;
    private Queue<CardDisplay> _poolQueue;

    [SerializeField]
    private CardDisplay _cardPrefab;
    [SerializeField]
    private int _size;

    private void Start()
    {
        _transform = transform;
        _poolQueue = new Queue<CardDisplay>();

        for (int i = 0; i < _size; i++) {
            CardDisplay display = Instantiate(_cardPrefab, _transform);
            display.gameObject.SetActive(false);

            _poolQueue.Enqueue(display);
        }
    }

    public CardDisplay Dequeue(Transform parent, Vector3 position, Quaternion rotation)
    {
        CardDisplay display = _poolQueue.Dequeue();

        display.transform.SetParent(parent);
        display.transform.position = position;
        display.transform.rotation = rotation;

        display.gameObject.SetActive(true);

        return display;
    }

    public void Enqueue(CardDisplay display)
    {
        display.gameObject.SetActive(false);

        display.transform.SetParent(_transform);
        display.transform.position = Vector3.zero;
        display.transform.rotation = Quaternion.identity;

        _poolQueue.Enqueue(display);
    }
}