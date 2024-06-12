using System.Collections.Generic;
using UnityEngine;

public class PatoPool : MonoBehaviour
{
    #region var
    [SerializeField] private GameObject PatoNormal;
    [SerializeField] private GameObject PatoEspecial;
    [SerializeField] private GameObject Rana;

    [SerializeField] private List<GameObject> Normalist;
    [SerializeField] private List<GameObject> Especialist;
    [SerializeField] private List<GameObject> Ranalist;

    [SerializeField] private int poolSize = 10;

    private static PatoPool instance;
    public static PatoPool Instance {  get { return instance; } }
    #endregion
    #region UnityMethods

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
    #endregion
    #region OwnMethods
    private void AddPatosToPool (int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            GameObject Normal = Instantiate(PatoNormal);
            Normal.SetActive(false);
            Normalist.Add(Normal);
            Normal.transform.parent = transform;
        }

        for (int i = 0; i < cantidad; i++)
        {
            GameObject Especial = Instantiate(PatoEspecial);
            Especial.SetActive(false);
            Especialist.Add(Especial);
            Especial.transform.parent = transform;
        }

        for (int i = 0; i < cantidad; i++)
        {
            GameObject RanaM = Instantiate(Rana);
            RanaM.SetActive(false);
            Ranalist.Add(RanaM);
            RanaM.transform.parent = transform;
        }
    }

    public GameObject RequestPatoNormal()
    {
        for ( int  i = 0; i < Normalist.Count; i++)
        {
            if(!Normalist[i].activeSelf )
            {
                Normalist[i].SetActive(true);
                return Normalist[i];
            }
        }
        return null;
    }
    public GameObject RequestPatoEspecial()
    {
        for (int i = 0; i < Especialist.Count; i++)
        {
            if (!Especialist[i].activeSelf)
            {
                Especialist[i].SetActive(true);
                return Especialist[i];
            }
        }
        return null;
    }
    public GameObject RequestRana()
    {
        for (int i = 0; i < Ranalist.Count; i++)
        {
            if (!Ranalist[i].activeSelf)
            {
                Ranalist[i].SetActive(true);
                return Ranalist[i];
            }
        }
        return null;
    }
    #endregion

}
