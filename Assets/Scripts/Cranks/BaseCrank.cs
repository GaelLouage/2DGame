using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Cranks
{
    public abstract class BaseCrank : MonoBehaviour
    {
        [SerializeField]
        protected Sprite crankUp;
        [SerializeField]
        protected Sprite crankDown;


        protected bool crankToggle;

        protected abstract void Update();

        protected abstract void OnTriggerEnter2D(Collider2D collision);
        protected abstract void OnTriggerExit2D(Collider2D collision);
    }
}
