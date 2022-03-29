using System;
using System.Diagnostics.CodeAnalysis;

enum PokemonType
    {
        Normal, Grass, Fire, Water, Bug, Poison,
        Flying, Electric, Ground, Fairy, Fighting, Rock,
        Psychic, Steel, Ice, Dragon, Ghost, None
    }

class Pokemon : IComparable<Pokemon>
{
    // Atributos
    private string name;
    private int hp;
    private int attack;
    private int defense;
    private int speed;
    private int spAttack;
    private int spDefense;
    private PokemonType type1;
    private PokemonType type2;

    // Propiedades
    public string Name
    {
        get
        {
            return name;
        }

        set
        {
            name = value;
        }
    }

    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            hp = value;
        }
    }

    public int Attack
    {
        get
        {
            return attack;
        }

        set
        {
            attack = value;
        }
    }

    public int Defense
    {
        get
        {
            return defense;
        }

        set
        {
            defense = value;
        }
    }

    public int Speed
    {
        get
        {
            return speed;
        }

        set
        {
            speed = value;
        }
    }

    public int SpAttack
    {
        get
        {
            return spAttack;
        }

        set
        {
            spAttack = value;
        }
    }

    public int SpDefense
    {
        get
        {
            return spDefense;
        }

        set
        {
            spDefense = value;
        }
    }

    public PokemonType Type1
    {
        get
        {
            return type1;
        }

        set
        {
            type1 = value;
        }
    }

    public PokemonType Type2
    {
        get
        {
            return type2;
        }

        set
        {
            type2 = value;
        }
    }

    // Constructores
    public Pokemon(string name, int hp, int attack, int defense, int speed, int spAttack, int spDefense, PokemonType type1, PokemonType type2)
    {
        this.Name = name;
        this.Hp = hp;
        this.Attack = attack;
        this.Defense = defense;
        this.Speed = speed;
        this.SpAttack = spAttack;
        this.SpDefense = spDefense;
        this.Type1 = type1;
        this.Type2 = type2;
    }

    public Pokemon(string name, int hp, int attack, int defense, int speed, int spAttack, int spDefense, PokemonType type1)
    {
        this.Name = name;
        this.Hp = hp;
        this.Attack = attack;
        this.Defense = defense;
        this.Speed = speed;
        this.SpAttack = spAttack;
        this.SpDefense = spDefense;
        this.Type1 = type1;
        this.Type2 = PokemonType.None;
    }

    private string Representation()
    {
        int n = 13;
        return $"{(Name.Length < n ? Name.PadRight(n) : Name.Substring(0, 10) + "...")}{Hp.ToString().PadRight(n)}{Attack.ToString().PadRight(n)}{Defense.ToString().PadRight(n)}{Speed.ToString().PadRight(n)} {SpAttack.ToString().PadRight(n)}{SpDefense.ToString().PadRight(n)}{Type1.ToString().PadRight(n)}{Type2.ToString().PadRight(n)}";
    }
    public override string ToString()
    {
        return Representation();
    }

    public int CompareTo([AllowNull] Pokemon other)
    {
        int v;

        if (this.Attack > other.Attack)
        {
            v = 1;
        }
        else
        {
            if (this.Attack == other.Attack)
            {
                v = 0;
            }
            else
            {
                v = -1;
            } 
        }
        
        return v;
    }
}