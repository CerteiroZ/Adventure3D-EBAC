using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAbilityShoot : PlayerAbilityBase
{
    public GunBase[] gunPrefabs;
    public Transform gunPosition;
    public FlashColor _flashColor;

    private GunBase _currentGun;
    private GunBase[] _gunInstances;

    protected override void Init()
    {
        base.Init();

        CreateGuns();

        inputs.Gameplay.Shoot.performed += cts => StartShoot();
        inputs.Gameplay.Shoot.canceled += cts => CancelShoot();

        inputs.Gameplay.Weapon1.performed += cts => ChangeGun(0);
        inputs.Gameplay.Weapon2.performed += cts => ChangeGun(1);
    }

    private void CreateGuns()
    {
        _gunInstances = new GunBase[gunPrefabs.Length];

        for (int i = 0; i < gunPrefabs.Length; i++)
        {
            _gunInstances[i] = Instantiate(gunPrefabs[i], gunPosition);
            _gunInstances[i].transform.localPosition = _gunInstances[i].transform.localEulerAngles = Vector3.zero;
        }

        _currentGun = _gunInstances[0];
    }

    public void ChangeGun(int gunIndex)
    {
        _currentGun.gameObject.SetActive(false);
        _currentGun = _gunInstances[gunIndex];
        _currentGun.gameObject.SetActive(true);
    }

    private void StartShoot()
    {
        _currentGun.StartShoot();
        _flashColor?.Flash();
        Debug.Log("Start Shoot");
    }

    private void CancelShoot()
    {
        _currentGun.StopShoot();
        Debug.Log("Cancel Shoot");
    }
}
