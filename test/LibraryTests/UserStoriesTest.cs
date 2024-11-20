namespace Ucu.Poo.DiscordBot.Domain.Tests;
using DefaultNamespace;
using Library.Tipos;
[TestFixture]
public class UserStoriesTest
{
        /// <summary>
    /// Prueba de la clase <see cref="Menu"/>.
    /// Estos test nos permiten verificar que las historias de usuarios están bien implementadas
    /// </summary>
    [Test]
    /// <summary>
    /// Este test verifica la tercer historia de usuario
    /// </summary>
    public void PikachuDañaAPidgey()
    {
        // 95 de daño del ataque rayo * efectividad (2) 
        int vidaesperada = 0; // tiene 60 de vida y 40 de defensa así que aguantría un golpe de 99 de daño como mucho 
        Facade.Instance.StartBattle("Ash","joshua");
        Facade.Instance.AddPokemosA("Pikachu");
        Facade.Instance.AddPokemosD("Pidgey");
        Facade.Instance.InitializeBattle();
        Facade.Instance.UsePokemonMove(1); //Pikachu usa royo
        Assert.That(vidaesperada,Is.EqualTo(Facade.Instance.Menu.GetHpDefensor())); // Verificar que la vida de Pidgey es 0
        Assert.That(80,Is.EqualTo(Facade.Instance.Menu.GetHpDefensor())); // Verificar que Pikachu mantiene su HP
    }
    [Test]
    public void PidgeyPorCharmanderParaAguantarAPikachu()
    {
        // Arrange
        double dañoPorAtaque = 65; // Daño de rayo
        double defensaCharmander = 60; // Defensa de Charmander
        double hpCharmander = 85; // Charmander arranca con 85 de vida
        double vidaCharmanderRestanteEsperada = hpCharmander - (dañoPorAtaque - defensaCharmander); // Calculos de supuesta vida charmander
        double vidaPidgeyEsperada = 60; // Pidgey debería iniciar con 60 de vida

        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Pidgey"); 
        Facade.Instance.AddPokemosD("Pikachu");
        Facade.Instance.AddPokemosA("Charmander");
        Facade.Instance.InitializeBattle();
        Facade.Instance.ChangePokemon(1); // Cambia a Charmander
        Facade.Instance.UsePokemonMove(2);//Pikachu usa rayo, danio de rayo: 65, defensa de Charmander: vida 85, defensa: 60
        
        Assert.That(vidaCharmanderRestanteEsperada,Is.EqualTo(Facade.Instance.Menu.GetHpAtacante())); // Verificar que la vida de Charmander es la esperada
        Facade.Instance.ChangePokemon(1);//Cambio a Pidgey, pasa a ser defensor al usar su turno
        Facade.Instance.UsePokemonMove(4);//Pikachu usa proteccion
        Assert.That( Facade.Instance.Menu.GetHpAtacante(),Is.EqualTo(vidaPidgeyEsperada)); //Verifica que pidgey sigue intecto
    }
    [Test]
    /// <summary>
    /// Este test verifica la cuarta historia de usuario ya que un ataque electrico a un tipo planta le hace la mitad del daño del ataque
    /// Además tambien cumple con la septima historia de usuario que dice puedo de pokemon cuando es mi turno pasando de Squirtle a Bulbasaur
    /// Además que el que comienza es squirtle y bulbasaur , para luego jugar pikachu repetando el orden del enfrentamiento
    /// </summary>
    public void BulbasaurPorSquirtleParaAguantarAPikachu()
    {
        int dañoPorAtaque = 95 / 2 ;
        int defensaBulbasaur = 70; 
        int hpBulbasaurEsperado = 90;
        int vidabulbasaurRestanteEsperada = 90; // Sabemos que no alzcanza para romper su defensa
        int vidatortugaEsperada = 80;

        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Squirtle");
        Facade.Instance.AddPokemosA("Bulbasaur");
        Facade.Instance.AddPokemosD("Pikachu");
        Facade.Instance.InitializeBattle();
        Facade.Instance.ChangePokemon(1); // Cambia a bulbasaur
        Facade.Instance.UsePokemonMove(2); // Pikachu usa rayo, daño de 65/2 = 32,5 
            
            
        Assert.That(vidabulbasaurRestanteEsperada,Is.EqualTo(Facade.Instance.Menu.GetHpAtacante())); // Verificar que la vida de bulbasour es la esperada
        Facade.Instance.ChangePokemon(1); // Cambiar a Squirtle
        Assert.That(vidatortugaEsperada,Is.EqualTo(Facade.Instance.Menu.GetHpDefensor())); //Verifica que bulbasaur sigue intecto
    }
    [Test]
    /// <summary>
    /// Este test verifica la segunda historia de usuario
    /// </summary>
    public void Especial() //En este test se puede ver que cuando el jugador 1 intenta usar el ataque especial de nuevo no puede hacerlo. 
    {
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Pikachu");
        Facade.Instance.AddPokemosD("Caterpie");
        Facade.Instance.InitializeBattle();
        Facade.Instance.ShowAvailableMoves();
        Facade.Instance.UsePokemonMove(1);//Jugador 1 usa Rayo(especial), vida del contrincante en 45
        Facade.Instance.UsePokemonMove(1);//Jugador2 usa picotazo cola
        Facade.Instance.UsePokemonMove(1);//Jugador 1 intenta usar el Rayo nuevamente pero no puede, vida del contrincante se mantiene
        int vidaesperadadefensor = 5;
        double vidaObtenidaDefensor = Facade.Instance.Menu.GetHpDefensor();
        Assert.That(vidaesperadadefensor,Is.EqualTo(vidaObtenidaDefensor));
    }
    
    [Test]
    public void Inmune() //En este test se puede ver que cuando un Pokemon que es inmune a otro es atacado, su vida no se ve afectada
    {
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Pikachu");
        //Usamos a pikachu porque electrico es inmune a electrico y el ataque Rayo es de tipo electrico
        Facade.Instance.AddPokemosD("Caterpie");
        Facade.Instance.InitializeBattle();
        Facade.Instance.UsePokemonMove(1);//Jugador 1 usa Rayo(electrico)
        Facade.Instance.UsePokemonMove(1);//Jugador2 usa Rayo(electrico)
        int vidaesperadadefensor = 80;
        double vidaObtenidaDefensor = Facade.Instance.Menu.GetHpDefensor();
        Assert.That(vidaesperadadefensor,Is.EqualTo(vidaObtenidaDefensor));
    }

    [Test]
    /// <summary>
    /// Este test verifica la quinta historia de usuario ya que pikachu siempre va a ser el pokemon atacante, es decir el que empiece
    /// Junto a esto tenemos un Console.WriteLine que indica de quien es el turno (Tenemos pensado hacer un string builder que forme el mensaje para el usuario en cada turno)
    /// </summary>
    public void Defensa()//Demuestra que defensa no hace daño
    {
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Pikachu");
        Facade.Instance.AddPokemosD("Charmander");
        Facade.Instance.InitializeBattle();
        Facade.Instance.UsePokemonMove(4);//El movimiento 4 siempre es de defensa, por lo que no provoca daño al contrincante
        double vidaesperadadefensor = 80;
        double vidaObtenidaDefensor = Facade.Instance.Menu.GetHpDefensor();
        Assert.That(vidaesperadadefensor,Is.EqualTo(vidaObtenidaDefensor));
    }

    [Test]
    public void CambioPokemon()//Verificacion Cambio de Pokemon de Turno
    {
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Squirtle");//Squirtle era el Pokemon en Turno al inicio porque fue agregado primero
        Facade.Instance.AddPokemosD("Charmander");
        Facade.Instance.AddPokemosA("Bulbasaur");//Bulbasaur era el segundo pokemon del equipo
        Facade.Instance.InitializeBattle();
        Facade.Instance.ChangePokemon(1);//Bulbasaur para a ser el Pokemon en Turno
        Facade.Instance.UsePokemonMove(1);
        string pokemonesperado = "Bulbasaur";
        string pokemonobtenido = Facade.Instance.Menu.GetPokemonActual().GetName();
        Assert.That(pokemonesperado,Is.EqualTo(pokemonobtenido));
    }

    [Test]
    /// <summary>
    /// Este test verifica la primer historia de usuario y verifica la historia de usuario que no suma a una lista a los usuarios que no pueden combatir
    /// </summary>
    public void Agrego6Pokemons()  
    {
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Charmander");
        Facade.Instance.AddPokemosA("Squirtle");
        Facade.Instance.AddPokemosA("Bulbasaur");
        Facade.Instance.AddPokemosA("Dratini");
        Facade.Instance.AddPokemosA("Arbok");
        Facade.Instance.AddPokemosA("Charmander");
        //List<Pokemon> listadada = juego4.(); falta getear el equipo del atacantes
        List<string> listadadaAstring = new List<string>();
        foreach (var pokemon in Facade.Instance.Menu.GetEquipoA())
        {
            listadadaAstring.Add(pokemon.GetName());
        }
        List<string> listaesperada = new List<string>
        {
            "Charmander",
            "Squirtle",
            "Bulbasaur",
            "Dratini",
            "Arbok",
            "Charmander"
        };

        foreach (string nombre in listaesperada)
        {
            Assert.That(listadadaAstring, Does.Contain(nombre));
        }
        
        // CollectionAssert.AreEqual(listaesperada,listadadaAstring);
    }

    [Test]
    public void VeoHPDeMisPokemonsYPokemonsOponentes()
    {
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Charmander");//85
        Facade.Instance.AddPokemosD("Squirtle");//80
        string vidasdadas= $"{Facade.Instance.Menu.GetHpAtacante()}/{Facade.Instance.Menu.GetHpDefensor()}";
        string vidasesperadas = "85/80";
        Assert.That(vidasdadas, Is.EqualTo(vidasesperadas));
    }
    [Test]
    /// <summary>
    /// Este test verifica la sexta historia de usuario ya que la batalla inicia y termina
    /// El mensaje impreso en programa pasará a ser un string pasado al bot de discord
    /// </summary>
    public void GanoBatalla()
    {
        
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Pikachu");
        Facade.Instance.AddPokemosD("Pidgey");
        Facade.Instance.InitializeBattle();
        Facade.Instance.UsePokemonMove(1); //Pikachu usa royo
        Facade.Instance.ShowOpponentStatus();
        Facade.Instance.UsePokemonMove(3);
        Facade.Instance.UsePokemonMove(2);
        Facade.Instance.UsePokemonMove(2);
        bool batallaganada = Facade.Instance.IsBattleOngoing();
        bool batallaganadasupuesta = true;
        Assert.That(batallaganada, Is.EqualTo(batallaganadasupuesta));
    }
    [Test]
    /// <summary>
    /// Este test verifica la  historia de usuario que nos permite usar varios items
    /// </summary>
    public void UsoItemEnBatalla1()
    {
        //Este test muestra el uso de un revivir en la batalla
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Squirtle");//Squirtle era el Pokemon en Turno al inicio porque fue agregado primero
        Facade.Instance.AddPokemosD("Charmander");
        var pokemon = Facade.Instance.Menu.GetPokemonActual();
        Facade.Instance.InitializeBattle();
        pokemon.ChangeIsAlive();
        // Usar Revivir para restaurar 50% del HP total
        Facade.Instance.UseItem("Revivir", 0); //Revive a Squirtle
        double vidaEsperada = 40;
        double vidaObtenida = pokemon.GetVidaActual();
        Assert.That(vidaObtenida, Is.EqualTo(vidaEsperada)); // Verifica que Squirtle tiene 40 HP no anda aún
    }

    [Test]
    public void UsoItemEnBatalla2()
    {
        //Este test muestra el uso de la CuraTotal en batalla
        Dormir dormido = new Dormir();
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Squirtle");//Squirtle era el Pokemon en Turno al inicio porque fue agregado primero
        Facade.Instance.AddPokemosD("Charmander");
        Pokemon pokemon2 = Facade.Instance.Menu.GetPokemonActual();
        Facade.Instance.InitializeBattle();
        Pokemon rival = Facade.Instance.Menu.GetPokemonRival();
        dormido.HacerEfecto(pokemon2);
        // Usa CuraTotal para quitarle el efecto de dormido
        Facade.Instance.UseItem("Curatotal", 0); //Cura el efecto de squirtle
        Efecto efectohecho = pokemon2.GetEfecto();
        Efecto efectoesperado = rival.GetEfecto();
        Assert.That(efectohecho, Is.EqualTo(efectoesperado)); // Compara el efecto de squirtle con el del rival, los dos son nulos
    }

    [Test]
    public void UsoItemEnBatalla3()
    {
        //Este test muestra el uso de la superpocion en batalla
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Pikachu");
        Facade.Instance.AddPokemosD("Arbok");
        Facade.Instance.InitializeBattle();
        Facade.Instance.UsePokemonMove(2);//Jugador 1 usa Electrobola
        Facade.Instance.UsePokemonMove(1);//Jugador2 usa LanzaMugre
        Facade.Instance.UseItem("Superpocion", 0); //Cura a Pikachu
        double vidaEsperada2 = 80;
        Pokemon pikachu = Facade.Instance.Menu.GetPokemonRival();
        double vidaObtenida2 = pikachu.GetVidaActual();
        // Usar Superpoción para restaurar 70 HP 
        Assert.That(vidaEsperada2, Is.EqualTo(vidaObtenida2));
    }

    [Test]
    public void UsoItemEnBatalla4()
    {
        //Este test demuestra que no se pueden usar items una vez se acabaron ya que el pokemon va a seguir dormido
        Dormir dormido2 = new Dormir();
        Facade.Instance.StartBattle("Ash", "Red");
        Facade.Instance.AddPokemosA("Charmander");
        Facade.Instance.AddPokemosD("Pidgey");
        Pokemon pokemon4 = Facade.Instance.Menu.GetPokemonActual();
        Pokemon rival2 = Facade.Instance.Menu.GetPokemonRival();
        dormido2.HacerEfecto(pokemon4);
        Facade.Instance.UseItem("Curatotal",0);
        dormido2.HacerEfecto(pokemon4);
        Facade.Instance.UseItem("Curatotal",0); // para que avance el turno
        Facade.Instance.UseItem("Curatotal",0);
        Facade.Instance.UseItem("Curatotal",0); // para que avance el turno
        dormido2.HacerEfecto(pokemon4);
        Facade.Instance.UseItem("Curatotal",0); // no va a dejar
        Efecto estado = pokemon4.GetEfecto();
        dormido2.HacerEfecto(rival2);
        Efecto estadormido = rival2.GetEfecto();
        
        Assert.That(estado,Is.EqualTo(estadormido));
    }
    
    [Test]
    public void UsoDeEnvenenamiento()
    {
        Facade.Instance.StartBattle("qcy", "manu¿");
        Facade.Instance.AddPokemosA("Arbok");
        Facade.Instance.AddPokemosD("Squirtle");
        Facade.Instance.InitializeBattle();
        Facade.Instance.UsePokemonMove(1);
        double vidaesperadasquirtle = 60;
        double vidadada = Facade.Instance.Menu.GetHpDefensor();
        Assert.That(vidaesperadasquirtle,Is.EqualTo(vidadada));
    }
   
}