﻿using System;
using Entity;
using Entity.IState;
using Move;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Entity.Entity))]
    [RequireComponent(typeof(IInput))]
    public class Player : MonoBehaviour
    {
        private Entity.Entity _entity;
        private IInput _input;

        private IMover Move => _entity.Move;
        private EntityMotion Motion => _entity.Motion;

        private void Awake()
        {
            _entity = GetComponent<Entity.Entity>();
            _input = GetComponent<IInput>();
        }

        private void OnEnable()
        {
            _input.Jumping += Motion.OnJumping;
        }

        private void Update()
        {
            Motion.GoWithSpeed(_input.HorizontalSpeed);
        }

        private void OnDisable()
        {
            _input.Jumping -= Motion.OnJumping;
        }
    }
}