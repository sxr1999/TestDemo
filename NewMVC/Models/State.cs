﻿namespace NewMVC.Models
{
    public class State
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<City> Cities { get; set; }
    }
}
