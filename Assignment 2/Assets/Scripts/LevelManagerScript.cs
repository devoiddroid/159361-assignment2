using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject CollectablesList;
    private int TotalCollectables;
    private int AcquiredCollectables;
    [SerializeField]
    private TMP_Text CollectableHUDField;

    // Start is called before the first frame update
    void Start()
    {
        TotalCollectables = CollectablesList.transform.childCount;
    }

    // Update is called once per frame
    void Update()
    {
        CollectableHUDField.text = AcquiredCollectables + " / " + TotalCollectables;
    }

    public void AcquiredCollectable() {
        this.AcquiredCollectables++;
    }
}
