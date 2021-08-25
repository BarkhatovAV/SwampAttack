using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Uzi: Weapon
{
    [SerializeField] private float _timeBetweenShoots ;

    private int _magazineCapacity = 10;
    private int _numberCurrentBulletInMagazine = 0;
    private bool _isShoot = false;
    private Transform _shootPoint;
    private float _currentTime;
    private float _shootTime;
    private float _nextFire = 0f;
    private bool _isUziCreated;

    private Bullet _bullet;


    //private void Update()
    //{
    //    //while (_isShoot == true)
    //    //{
    //        Debug.Log("2");
    //        if ((_numberCurrentBulletInMagazine < _magazineCapacity) || (_isShoot == true))
    //        {
    //            Debug.Log("3");
    //            if (Time.time > _nextFire)
    //            {
    //                Debug.Log("4");

    //                _nextFire = Time.time + _timeBetweenShoots;
    //                _numberCurrentBulletInMagazine++;
    //                Debug.Log(_nextFire);
    //                Debug.Log(_numberCurrentBulletInMagazine);
    //                ShootAtUzi(_shootPoint);
    //                //Instantiate(Bullet, _shootPoint.position, Quaternion.identity);

    //            }
    //        }
    //        else
    //        {
    //            Debug.Log("5");
    //            _isShoot = false;
    //        }
    //    //}
    //}

    //public override void Shoot(Transform shootPoint)
    //{   
    //    _shootPoint = shootPoint;
    //    Instantiate(gameObject, _shootPoint.position, Quaternion.identity);
    //    gameObject.SetActive(true);
    //    CreateUzi();


    //    _isShoot = true;




    //    _bullet = Bullet;

    //    //StartCoroutine(AutoShoot(shootPoint));
    //    Debug.Log("1");
    //    //Instantiate(Bullet, _shootPoint.position, Quaternion.identity);
    //}

    //private void CreateUzi()
    //{
    //    if (_isUziCreated == false)
    //    {
    //        var Uziz = Instantiate(gameObject, _shootPoint.position, Quaternion.identity);
    //        Uziz.SetActive(true);
    //        gameObject.SetActive(true);
    //    }

    //    _isUziCreated = true;
    //}

    //private void ShootAtUzi(Transform shootPoint)
    //{
    //     Instantiate(Bullet, _shootPoint.position, Quaternion.identity);
    //}


    public override void Shoot(Transform shootPoint)
    {
        
        Instantiate(Bullet, _shootPoint.position, Quaternion.identity);
        StartCoroutine(AutoShoot(shootPoint));
    }


    private IEnumerator AutoShoot(Transform shootPoint)
    {
        for (int i = 0; i < _magazineCapacity; i++)
        {
            Debug.Log("2");
            Instantiate(Bullet, _shootPoint.position, Quaternion.identity);
            yield return new WaitForSeconds(_timeBetweenShoots);
        }
    }


}
