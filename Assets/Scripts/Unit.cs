using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Unit : MonoBehaviour
{
    [SerializeField]
    private IMoveBehaviour _moveBehaviour;
    private IClickBehaviour _clickBehaviour;
    private IPassLineBehaviour _passLineBehaviour;

    public Unit(IMoveBehaviour moveBehaviour, IClickBehaviour clickBehaviour, IPassLineBehaviour passLineBehaviour)
    {
        _moveBehaviour = moveBehaviour;
        _clickBehaviour = clickBehaviour;
        _passLineBehaviour = passLineBehaviour;
    }
    private void Awake()
    {
        //_moveBehaviour = new WalkBehaviour(1, gameObject, FindObjectOfType<GridManager>());
        //_moveBehaviour = new StrafeBehaviour(1, 1, gameObject, FindObjectOfType<GridManager>());
    }
    private void Start()
    {
        _moveBehaviour?.Move();
    }

    private void OnMouseDown()
    {
        _clickBehaviour?.Click();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "EndLine")
            _passLineBehaviour?.PassLine();
    }
    private void Update()
    {
        _moveBehaviour?.Move();
    }
}
