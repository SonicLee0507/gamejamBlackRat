using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemData : MonoBehaviour
{
    [SerializeField] public int enem_hp;

    [SerializeField] public int enem_maxhp;

    [SerializeField] public int enem_attack;
    [SerializeField] public int enem_skill;

    [SerializeField] public Slider enem_healthBar;
    // Start is called before the first frame update
    void Start()
    {
        enem_healthBar.maxValue = enem_maxhp;
    }

    // Update is called once per frame
    void Update()
    {
        enem_healthBar.value = enem_hp;

        if (enem_hp <= 0)
        {
            Destroy(gameObject);

        }
    }
}
