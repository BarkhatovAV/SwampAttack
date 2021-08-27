using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi: Weapon
{
    [SerializeField] private float _timeBetweenShoots;

    private int _magazineCapacity = 10;
    private bool _isFireOver = true;

    public override void Shoot(Transform shootPoint)
    {
        if (_isFireOver == true)
            StartCoroutine(AutoShoot(shootPoint));
    }

    private IEnumerator AutoShoot(Transform shootPoint)
    {
        var waitForShoot = new WaitForSeconds(_timeBetweenShoots);
        _isFireOver = false;

        for (int i = 0; i < _magazineCapacity; i++)
        {
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);
            yield return waitForShoot;
        }

        _isFireOver = true;
    }
}
