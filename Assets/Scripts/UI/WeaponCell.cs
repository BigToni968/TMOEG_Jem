using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCell : MonoBehaviour
{
    [SerializeField] private Image _image;
    [SerializeField] private List<Sprite> _sprites;
    [SerializeField] private int _index;

    private void Start()
    {
        _image.sprite = _sprites[_index];
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            _image.sprite = _sprites[0];
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            _image.sprite = _sprites[1];
        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            _image.sprite = _sprites[2];
        }
    }
}
