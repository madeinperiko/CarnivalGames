using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiratePool : MonoBehaviour
{
    #region var
    [SerializeField] private GameObject Pirata;
    [SerializeField] private GameObject Gaviota;
    [SerializeField] private GameObject Aliado;
    [SerializeField] private GameObject Nube1;
    [SerializeField] private GameObject Nube2;
    [SerializeField] private GameObject Nube3;

    [SerializeField] private List<GameObject> Piratalist;
    [SerializeField] private List<GameObject> Gaviotalist;
    [SerializeField] private List<GameObject> Aliadolist;
    [SerializeField] private List<GameObject> Nube1list;
    [SerializeField] private List<GameObject> Nube2list;
    [SerializeField] private List<GameObject> Nube3list;

    [SerializeField] private int poolSize = 10;

    private static PiratePool instance;
    #endregion
    #region methods
    public static PiratePool Instance { get { return instance; } }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        AddPatosToPool(poolSize);
    }

    private void AddPatosToPool(int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            GameObject PirataI = Instantiate(Pirata);
            PirataI.SetActive(false);
            Piratalist.Add(PirataI);
            PirataI.transform.parent = transform;
        }

        for (int i = 0; i < cantidad; i++)
        {
            GameObject Especial = Instantiate(Gaviota);
            Especial.SetActive(false);
            Gaviotalist.Add(Especial);
            Especial.transform.parent = transform;
        }

        for (int i = 0; i < cantidad; i++)
        {
            GameObject AliadoI = Instantiate(Aliado);
            AliadoI.SetActive(false);
            Aliadolist.Add(AliadoI);
            AliadoI.transform.parent = transform;
        }

        for (int i = 0; i < cantidad; i++)
        {
            GameObject Nube1I = Instantiate(Nube1);
            Nube1I.SetActive(false);
            Nube1list.Add(Nube1I);
            Nube1I.transform.parent = transform;
        }

        for (int i = 0; i < cantidad; i++)
        {
            GameObject Nube2I = Instantiate(Nube2);
            Nube2I.SetActive(false);
            Nube2list.Add(Nube2I);
            Nube2I.transform.parent = transform;
        }

        for (int i = 0; i < cantidad; i++)
        {
            GameObject Nube3I = Instantiate(Nube3);
            Nube3I.SetActive(false);
            Nube3list.Add(Nube3I);
            Nube3I.transform.parent = transform;
        }
    }

    public GameObject RequestPirata()
    {
        for (int i = 0; i < Piratalist.Count; i++)
        {
            if (!Piratalist[i].activeSelf)
            {
                Piratalist[i].SetActive(true);
                return Piratalist[i];
            }
        }
        return null;
    }
    public GameObject RequestGaviota()
    {
        for (int i = 0; i < Gaviotalist.Count; i++)
        {
            if (!Gaviotalist[i].activeSelf)
            {
                Gaviotalist[i].SetActive(true);
                return Gaviotalist[i];
            }
        }
        return null;
    }
    public GameObject RequestAliado()
    {
        for (int i = 0; i < Aliadolist.Count; i++)
        {
            if (!Aliadolist[i].activeSelf)
            {
                Aliadolist[i].SetActive(true);
                return Aliadolist[i];
            }
        }
        return null;
    }

    public GameObject RequestNube1() 
    {
        for (int i = 0; i < Nube1list.Count; i++)
        {
            if (!Nube1list[i].activeSelf)
            {
                Nube1list[i].SetActive(true);
                return Nube1list[i];
            }
        }
        return null;
    }

    public GameObject RequestNube2()
    {
        for (int i = 0; i < Nube2list.Count; i++)
        {
            if (!Nube2list[i].activeSelf)
            {
                Nube2list[i].SetActive(true);
                return Nube2list[i];
            }
        }
        return null;
    }

    public GameObject RequestNube3()
    {
        for (int i = 0; i < Nube3list.Count; i++)
        {
            if (!Nube3list[i].activeSelf)
            {
                Nube3list[i].SetActive(true);
                return Nube3list[i];
            }
        }
        return null;
    }

    #endregion
}
