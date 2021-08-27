//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Events;

//[RequireComponent(typeof(Animator))]
//public class Player : MonoBehaviour
//{
//    [SerializeField] private int _health;
//    [SerializeField] private List<Weapon> _weapons;
//    [SerializeField] private Transform _shootPosition;

//    private Weapon _currentWeapon;
//    private int _currentWeaponNumber = 0;
//    private int _currentHealth;
//    private Animator _animator;

//    public int Money { get; private set; }

//    public event UnityAction<int, int> HealthChanged;
//    public event UnityAction<int> MoneyChanged;

//    private void Start()
//    {
//        //_currentWeapon = _weapons[_currentWeaponNumber];
//        ChangeWeapon(_weapons[_currentWeaponNumber], _currentWeapon);
//        _currentHealth = _health;
//        _animator = GetComponent<Animator>();

//    }

//    private void Update()
//    {
//        if (Input.GetMouseButtonDown(0))
//        {
//            _animator.Play("Shoot");
//            _currentWeapon.Shoot(_shootPosition);
//        }
//    }

//    public void ApplyDamage(int damage)
//    {
//        _currentHealth -= damage;
//        HealthChanged?.Invoke(_currentHealth, _health);
//        if (_currentHealth <= 0)
//        {
//            Destroy(gameObject);
//        }

//    }

//    public void AddMoney(int money)
//    {
//        Money += money;
//        MoneyChanged?.Invoke(Money);
//    }

//    public void BuyWeapon(Weapon weapon)
//    {
//        Money -= weapon.Price;
//        MoneyChanged?.Invoke(Money);
//        var purchasedWeapon = Instantiate(weapon, this.transform);//
//        purchasedWeapon.gameObject.SetActive(true);//
//        _weapons.Add(purchasedWeapon);//
//    }

//    public void NextWeapon()
//    {
//        Weapon previuosWeapon = _currentWeapon;
//        if (_currentWeaponNumber == _weapons.Count - 1)
//        {
//            _currentWeaponNumber = 0;
//        }
//        else
//        {
//            _currentWeaponNumber++;
//        }

//        ChangeWeapon(_weapons[_currentWeaponNumber], previuosWeapon);
//    }

//    public void PreviousWeapon()
//    {
//        Weapon previuosWeapon = _currentWeapon;
//        if (_currentWeaponNumber == 0)
//        {
//            _currentWeaponNumber = _weapons.Count - 1;
//        }
//        else
//        {
//            _currentWeaponNumber--;
//        }

//        ChangeWeapon(_weapons[_currentWeaponNumber], previuosWeapon);
//    }

//    private void ChangeWeapon(Weapon currentWeapon, Weapon previousWeapon)
//    {
//        _currentWeapon = currentWeapon;
//    }
//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
public class Player : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private int _currentWeaponNumber = 0;
    private int _currentHealth;
    private Animator _animator;

    public int Money { get; private set; }

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> MoneyChanged;

    private void Start()
    {
        _currentWeapon = _weapons[_currentWeaponNumber];
        _currentHealth = _health;
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _animator.Play("Shoot");//
            _currentWeapon.Shoot(_shootPoint);
        }
    }

    public void ApplyDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _health);

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddMoney(int money)
    {
        Money += money;
        MoneyChanged?.Invoke(Money);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        MoneyChanged?.Invoke(Money);
        //Instantiate(weapon, this.transform);
        //_weapons.Add(weapon);
        var purchasedWeapon = Instantiate(weapon, this.transform);
        _weapons.Add(purchasedWeapon);
    }

    public void NextWeapon()
    {
        if (_currentWeaponNumber == _weapons.Count - 1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponNumber == 0)
            _currentWeaponNumber = _weapons.Count - 1;
        else
            _currentWeaponNumber--;

        ChangeWeapon(_weapons[_currentWeaponNumber]);
    }

    private void ChangeWeapon(Weapon currentWeapon)
    {
        _currentWeapon = currentWeapon;
    }


}
