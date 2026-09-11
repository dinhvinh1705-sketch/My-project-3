using UnityEngine;
using TMPro;

public class AmmoUI : MonoBehaviour
{
    [SerializeField] int ammo = 10;
    [SerializeField] TMP_Text ammoText;

    public void OnPlayerShoot()
    {
        ammo--;

        ammoText.text = "Ammo: " + ammo;

        Debug.Log("Ammo: " + ammo);
    }
}