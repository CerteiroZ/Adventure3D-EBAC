using Boss;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] private GameObject _bossGameObject;
    [SerializeField] private string _tagToCompareOnTriggerEnter = "Player";

    private bool _triggerOnce = true;
    private BossBase _bossBase;

    private void Awake()
    {
        if (_bossGameObject != null)
        {
            _bossBase = _bossGameObject.GetComponent<BossBase>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_triggerOnce)
            return;

        if (other.CompareTag(_tagToCompareOnTriggerEnter))
        {
            _triggerOnce = false;
            _bossGameObject.SetActive(true);

            if (_bossBase != null)
            {
                _bossBase.SwitchState(BossAction.WALK);
            }
        }
    }
}
