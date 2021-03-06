﻿using System.Collections.Generic;

namespace RaytracingWPF_CT.Render
{
    public class Scene
    {
        private readonly List<IPrimitive> _objects;

        public Scene(int width, int height)
        {
            ParseCompleted = true;
            Width = width;
            Height = height;
            _objects = new List<IPrimitive>();
        }

        public int Width { get; set; }
        public int Height { get; set; }

        public bool ParseCompleted { get; set; }

        public void AddPrimitive(IPrimitive primitive)
        {
            _objects.Add(primitive);
        }

        public void ClearPrimitives()
        {
            _objects.Clear();
        }

        public IPrimitive[] ConvertToArray()
        {
            return _objects.ToArray();
        }
    }
}