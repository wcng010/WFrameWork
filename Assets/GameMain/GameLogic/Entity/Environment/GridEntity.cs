using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Wcng
{
    public class GridEntity:Entity
    {
        [NonSerialized]public bool IsShow;
        private SpriteRenderer _spriteRenderer;
        [SerializeField]private Color originColor = new Color(61,92,103,54/255f);
        [SerializeField]private Color showColor = new Color(11, 164, 115, 54 / 255f);
        [SerializeField]private Color selectedColor = new Color(164, 11, 60, 54/255f);

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public GridEntity Show()
        {
            _spriteRenderer.color = showColor;
            IsShow = true;
            return this;
        }

        public void UnShow()
        {
            _spriteRenderer.color = originColor;
            IsShow = false;
        }

        public void Selected()
        {
            if (IsShow)
                _spriteRenderer.color = selectedColor;
        }

        public void UnSelected()
        {
            if (IsShow)
                _spriteRenderer.color = showColor;
        }
    }
}