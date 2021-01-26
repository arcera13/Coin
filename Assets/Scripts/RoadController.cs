using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{

    [SerializeField] private PlayerController _player;
    [SerializeField] private GameObject[] roads;
    private bool _isCreated = false;

    // Update is called once per frame
    void Update() {
        float posZ = (int) _player.transform.position.z;
        if (posZ > 0 && (posZ % 40) == 0) {
            if (!_isCreated) {
                createSection(posZ, roads);
            }
        }
        else{
            _isCreated = false;
        }
    }

    public void createSection( float posZ, GameObject[] roads) {
        int element = Random.Range(0, roads.Length);

        GameObject road = Instantiate(roads[element]);
        road.transform.position = new Vector3(transform.position.x, transform.position.y, posZ + 40);
        _isCreated = true;
    }    
}