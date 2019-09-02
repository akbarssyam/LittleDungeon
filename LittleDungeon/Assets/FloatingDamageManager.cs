using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingDamageManager : MonoBehaviour
{
    private static FloatingDamageManager _instance;
    [SerializeField]
    private GameObject floatingDamage;


    public static FloatingDamageManager Instance { get { return _instance; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    public void CreateFloatingDamage(string amount, Vector3 position)
    {
        FloatingDamage fd = Instantiate(floatingDamage, position, Quaternion.identity).GetComponentInChildren<FloatingDamage>();
        fd.SetText(amount);
    }
}
