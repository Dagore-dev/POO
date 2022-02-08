using System;
using System.Collections.Generic;
using System.Text;

namespace ExplicacionClases
{
    enum PokemonType
    {
        Fire,
        Water,
        Grass,
        Electric,
        Poison,
        Ghost,
        Bug,
        Normal
    }
    enum PokemonGender
    {
        Macho,
        Hembra,
        Desconocido
    }
    class Pokemon
    {
        private readonly int _id;
        private readonly string _name;
        private readonly PokemonType _type;
        private  readonly PokemonGender _gender;
        private int _maxHP;
        private int _currentHP;
        private int _level;
        public Pokemon(string name, int id, PokemonType type, PokemonGender gender, int maxHP, int currentHP, int level)
        {
            if (name.Length > 0)
            {
                this._name = name;
            }
            else
            {
                throw new Exception("name can't be empty");
            }
            if (id >= 1 && id <= 151)
            {
                this._id = id;
            }
            else
            {
                throw new Exception("id must be between 1 and 151");
            }
            this._type = type;
            this._gender = gender;
            this.MaxHP = maxHP;
            this.CurrentHP = currentHP;
            this.Level = level;
        }

        /*Definición de propiedades, sustituto de getters y setters*/
        public int Id
        {
            get
            {
                return this._id;
            }
        }
        public int CurrentHP
        {
            get
            {
                return this._currentHP;

            }
            set
            {
                if (value >= 0 || value <= this._maxHP)
                {
                    this._currentHP = value;
                }
                else
                {
                    throw new Exception("currentHP must be between zero and maxHP");
                }
            }
        }
        public string Name
        {
            get
            {
                return this._name;
            }
        }
        public int Level
        {
            get => _level;//Manera simplificada de generar la propiedad con las opciones de refactorización.
            set
            {
                if (value >= 1 && value <= 100)
                {
                    this._level = value;
                }
                else
                {
                    throw new Exception("level must be between one and one hundred");
                }
            }
        }
        public int MaxHP
        {
            get => _maxHP;
            set
            {
                if (value > 0)
                {
                    this._maxHP = value;
                }
                else
                {
                    throw new Exception("maxHP must be greater than zero");
                }
            }
        }
        public PokemonType Type { get => _type; }
        public PokemonGender Gender { get => _gender; }
        public bool Unconscious
        {
            get
            {
                bool result = false;

                if (_currentHP == 0)
                {
                    result = true;
                }

                return result;
            }
        }

        /*Sobreescribir métodos del sistema*/
        public override string ToString ()
        {
            return $"Pokemon {_id}: {_name}, tipo: {_type}, género: {_gender}, nivel {_level}, HP {_currentHP}/{_maxHP}.";
        }

        /*Métodos del Pokemon*/
        public void DrinkPotion ()
        {
            int hp = _currentHP + 20;

            if (hp <= MaxHP)
            {
                _currentHP = hp;
            }
            else
            {
                _currentHP = _maxHP;
            }
        }
    }
}
