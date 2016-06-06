using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace VM_ASP_MVC.Models
{
    public class Coin
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }

        public static implicit operator string(Coin с)
        {
            return string.Format("{0} {1} = {2} штук", с.Value, с.Name, с.Count);
        }
        public override string ToString()
        {
            return string.Format("{0} {1} = {2} штук", Value, Name, Count); ;
        }

        public override bool Equals(object obj)
        {
            Coin coin = obj as Coin;

            if (ReferenceEquals(coin, null))
                return false;

            return Name.Equals(coin.Name, StringComparison.CurrentCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }

    public class Name : IValidatableObject
    {
        private readonly string _value;

        [Display(Name = "Название валюты")]
        public string Value { get { return _value; } }

        private Name(string value)
        {
            _value = value;
        }

        public static Name Create(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
                throw new ArgumentException("Название монеты не может быть путым");

            return new Name(Name);
        }

        public static implicit operator string(Name Name)
        {
            return Name._value;
        }

        public override bool Equals(object obj)
        {
            Name Name = obj as Name;

            if (ReferenceEquals(Name, null))
                return false;

            return _value == Name._value;
        }

        public override int GetHashCode()
        {
            return _value.GetHashCode();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.Value))
            {
                errors.Add(new ValidationResult("Введите название книги"));
            }
            return errors;
        }
    }


}