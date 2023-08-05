using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons = new List<Weapon>();

    private const int maxWeapons = 3;
    public bool slotsFull;


    public void AddWeapon(Weapon weapon)
    {
        
        if (!slotsFull && weapons.Count < maxWeapons )
        {
            
            if (!weapons.Contains(weapon))
            {
                weapons.Add(weapon);
            }
        }

        
        slotsFull = weapons.Count >= maxWeapons;
    }
    
    public void RemoveWeapon(Weapon weapon)
    {
        if (weapons.Contains(weapon))
        {
            weapons.Remove(weapon);
            weapon.gameObject.SetActive(false);
            
            slotsFull = false;
        }
    }

    public bool AreSlotsFull()
    {
        return slotsFull;
    }
}
