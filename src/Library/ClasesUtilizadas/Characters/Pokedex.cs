using Library.Tipos;
using Ucu.Poo.Pokemon;
using Dormir = Library.Tipos.Dormir;
using Envenenar = Library.Tipos.Envenenar;
using Paralizar = Library.Tipos.Paralizar;
using Quemar = Library.Tipos.Quemar;

namespace DefaultNamespace;

//Clase Pokedex:
//Cumple con el princpio de SRP, ya que se encarga de crear todos los pokemones con sus tipos,
//efectividades, movimientos característicos y los efectos de sus movimientos especiales.
//Cumple con Expert porque tiene toda la informacion necesaria para sus tareas en sí misma.
//Cumple con Creator ya que se encarga de crear instancias de la clase Pokemon, Efecto y Tipo.


public static class Pokedex
{
    private static List<Tipo> listatiposdisponibles = new List<Tipo>();
    private static List<Pokemon> pokemonsdisponibles = new List<Pokemon>();
    private static List<IMovimiento> listaMovimientos = new List<IMovimiento>();
    private static List<Efecto> listaEfectos = new List<Efecto>();


    /// <summary>  
    /// Constructor estático que inicializa la Pokédex,  
    /// configurando efectos, tipos, movimientos y Pokémon.  
    /// </summary>  
    static Pokedex()
    {
        RegularEfectos();
        RegularTipos();
        CrearMovimientos();
        CrearPokemones();
    }

    /// <summary>  
    /// Muestra el catálogo de Pokémon disponibles en la Pokédex.  
    /// </summary>  
    public static string MostrarCatalogo()
    {
        string catalogo = "";
        foreach (Pokemon pokemon in pokemonsdisponibles)
        {
            catalogo += $"{pokemon.GetName()}\n";
        }

        return catalogo;
    }

    /// <summary>  
    /// Entrega una copia de un Pokémon basado en su nombre.  
    /// Si el Pokémon no se encuentra, se informa al usuario.  
    /// </summary>  
    /// <param name="nombrepokemon">El nombre del Pokémon a entregar.</param>  
    /// <returns>Una copia del Pokémon correspondiente o null si no se encuentra.</returns>  
    public static Pokemon EntregarPokemon(string nombrepokemon)
    {
        foreach (Pokemon pokemon in pokemonsdisponibles)
        {
            if (nombrepokemon == pokemon.GetName()) //Busca que el nombre sea identico
            {
                return CrearCopia(pokemon); //Genera una copia identica del pokemon de la pokedex y se lo entre al usaurio
            }
        }
        return null;
    }

    /// <summary>  
    /// Crea una copia de un Pokémon, incluyendo sus movimientos.  
    /// </summary>  
    /// <param name="pokemon">El Pokémon del que se desea crear la copia.</param>  
    /// <returns>Una nueva instancia del Pokémon con los mismos atributos.</returns>  
    public static Pokemon CrearCopia(Pokemon pokemon)
    {
        List<IMovimiento> listaMovs = new List<IMovimiento>();
        foreach (IMovimiento movimiento in pokemon.GetListaMovimientos())
        {
            IMovimiento movimientoAgregar;
        
            if (movimiento is MovimientoEspecial movimientoEspecial)
            {
                // Crear una nueva instancia de MovimientoEspecial con los mismos atributos
                movimientoAgregar = new MovimientoEspecial(
                    movimientoEspecial.GetName(),
                    movimientoEspecial.GetAtaque(),
                    movimientoEspecial.GetTipo(),
                    movimientoEspecial.GetPrecision(),
                    movimientoEspecial.GetEfecto()
                );
            }
            else
            {
                // Si no es MovimientoEspecial ni MovimientoDeAtaque, simplemente copia la referencia
                movimientoAgregar = movimiento;
            }
        
            listaMovs.Add(movimientoAgregar);
        }
        // Crear una nueva instancia del Pokémon con el mismo nombre y lista de movimientos clonada
        Pokemon pokemonCreado = new Pokemon(pokemon.GetName(), listaMovs, pokemon.GetTipos(), pokemon.GetVidaTotal(), pokemon.GetDefensa());
        return pokemonCreado;
    }

    /// <summary>  
    /// Configura los efectos disponibles en la Pokédex.  
    /// </summary>  
    private static void RegularEfectos()
    {
        Efecto dormir = new Dormir();
        Efecto paralizar = new Paralizar();
        Efecto envenenar = new Envenenar();
        Efecto quemar = new Quemar();
        listaEfectos.Add(dormir);//0
        listaEfectos.Add(paralizar);//1
        listaEfectos.Add(envenenar);//2
        listaEfectos.Add(quemar);//3
    }
    
    /// <summary>  
    /// Configura los tipos disponibles en la Pokédex.  
    /// (Este método debe ser implementado según los tipos necesarios.)  
    /// </summary>  
    private static void RegularTipos()
    { 
        // Crear los tipos
        Tipo electrico = new Tipo("Electrico");
        Tipo fuego = new Tipo("Fuego");
        Tipo agua = new Tipo("Agua");
        Tipo planta = new Tipo("Planta");
        Tipo volador = new Tipo("Volador");
        Tipo normal = new Tipo("Normal");
        Tipo roca = new Tipo("Roca");
        Tipo tierra = new Tipo("Tierra");
        Tipo bicho = new Tipo("Bicho");
        Tipo dragon = new Tipo("Dragon");
        Tipo fantasma = new Tipo("Fantasma");
        Tipo hielo = new Tipo("Hielo");
        Tipo lucha = new Tipo("Lucha");
        Tipo psiquico = new Tipo("Psiquico");
        Tipo veneno = new Tipo("Veneno");
        

        // Definir efectividades del tipo Electrico
        electrico.CrearEfectividad(agua, 2.0);    // Electrico contra Agua -> Súper efectivo (200%)
        electrico.CrearEfectividad(planta, 0.5);  // Electrico contra Planta -> Poco efectivo (50%)
        electrico.CrearEfectividad(volador, 2.0); // Electrico contra Volador -> Súper efectivo (200%)
        electrico.CrearEfectividad(tierra, 0.5);  // Electrico contra Tierra -> Inmune (0%)
        electrico.CrearEfectividad(dragon,0.5);   //Electrico contra Dragon -> Poco efectivo (50%)
        electrico.CrearEfectividad(electrico,0.0);//Electrico contra Electrico -> Inmune(0%)
        

        // Definir efectividades del tipo Fuego
        fuego.CrearEfectividad(agua, 0.5);       // Fuego contra Agua -> Poco efectivo (50%)
        fuego.CrearEfectividad(planta, 2.0);     // Fuego contra Planta -> Súper efectivo (200%)
        fuego.CrearEfectividad(roca, 0.5);       // Fuego contra Roca -> Poco efectivo (50%)
        fuego.CrearEfectividad(bicho,2.0);       // Fuego contra Bicho -> Super efectivo (200%)
        fuego.CrearEfectividad(dragon,0.5);      //Fuego contra Dragon -> Poco efectivo (50%)
        fuego.CrearEfectividad(fuego,0.5);       //Fuego contra Fuego -> Poco efectivo (50%)
        fuego.CrearEfectividad(hielo,2.0);       //Fuego contra Hielo -> Super efectivo (200%)

        // Definir efectividades del tipo Agua
        agua.CrearEfectividad(fuego, 2.0);       // Agua contra Fuego -> Súper efectivo (200%)
        agua.CrearEfectividad(planta, 0.5);      // Agua contra Planta -> Poco efectivo (50%)
        agua.CrearEfectividad(roca, 2.0);        // Agua contra Roca -> Súper efectivo (200%)
        agua.CrearEfectividad(tierra, 2.0);      // Agua contra Tierra -> Súper efectivo (200%)
        agua.CrearEfectividad(agua,0.5);         // Agua contra Agua -> Poco efectivo (50%)
        agua.CrearEfectividad(dragon,0.5);       // Agua contra Dragon -> Poco efectivo (50%)
        
        // Definir efectividades del tipo Planta
        planta.CrearEfectividad(fuego, 0.5);      // Planta contra Fuego -> Poco efectivo (50%)
        planta.CrearEfectividad(agua, 2.0);       // Planta contra Agua -> Súper efectivo (200%)
        planta.CrearEfectividad(volador, 0.5);    // Planta contra Volador -> Poco efectivo (50%)
        planta.CrearEfectividad(roca, 2.0);       // Planta contra Roca -> Súper efectivo (200%)
        planta.CrearEfectividad(tierra, 2.0);     // Planta contra Tierra -> Súper efectivo (200%)
        planta.CrearEfectividad(bicho,0.5);       //Planta contra Bicho-> Poco efectivo (50%)
        planta.CrearEfectividad(dragon,0.5);      //Planta contra Dragon-> Poco efectivo (50%)
        planta.CrearEfectividad(planta,0.5);      //Planta contra Planta-> Poco efectivo (50%)
        planta.CrearEfectividad(veneno,0.5);      // Planta contra Veneno -> Súper efectivo (200%)

        // Definir efectividades del tipo Volador
        volador.CrearEfectividad(electrico, 0.5); // Volador contra Electrico -> Poco efectivo (50%)
        volador.CrearEfectividad(planta, 2.0);    // Volador contra Planta -> Súper efectivo (200%)
        volador.CrearEfectividad(roca, 0.5);      // Volador contra Roca -> Poco efectivo (50%)
        volador.CrearEfectividad(bicho,2.0);      // Volador contra Bicho -> Súper efectivo (200%)
        volador.CrearEfectividad(lucha,2.0);      // Volador contra Lucha -> Súper efectivo (200%)
        
        //Definir efectividades del tipo Normal
        normal.CrearEfectividad(fantasma,0.5);    // Normal contra Fantasma -> Poco efectivo (50%)
        normal.CrearEfectividad(roca,0.5);        // Normal contra Roca -> Poco efectivo (50%)

        // Definir efectividades del tipo Roca
        roca.CrearEfectividad(fuego, 2.0);        // Roca contra Fuego -> Súper efectivo (200%)
        roca.CrearEfectividad(volador, 2.0);      // Roca contra Volador -> Súper efectivo (200%)
        roca.CrearEfectividad(bicho,2.0);         // Roca contra Bicho -> Súper efectivo (200%)
        roca.CrearEfectividad(hielo,2.0);         // Roca contra Hielo -> Súper efectivo (200%)
        roca.CrearEfectividad(lucha,2.0);         // Roca contra Lucha -> Súper efectivo (200%)
        roca.CrearEfectividad(tierra,2.0);        // Roca contra Tierra -> Súper efectivo (200%)

        // Definir efectividades del tipo Tierra
        tierra.CrearEfectividad(electrico, 2.0);  // Tierra contra Electrico -> Súper efectivo (200%)
        tierra.CrearEfectividad(fuego, 2.0);      // Tierra contra Fuego -> Súper efectivo (200%)
        tierra.CrearEfectividad(planta, 0.5);     // Tierra contra Planta -> Poco efectivo (50%)
        tierra.CrearEfectividad(volador, 0.5);    // Tierra contra Volador -> Inmune (0%)
        tierra.CrearEfectividad(roca, 2.0);       // Tierra contra Roca -> Súper efectivo (200%)
        tierra.CrearEfectividad(bicho,0.5);       // Tierra contra Bicho -> Poco efectivo (50%)
        tierra.CrearEfectividad(veneno,2.0);      // Tierra contra Veneno -> Súper efectivo (200%)
        
        //Definir efectividades del tipo Bicho
        bicho.CrearEfectividad(fuego,0.5);        // Bicho contra Fuego -> Poco efectivo (50%)
        bicho.CrearEfectividad(lucha,2.0);        // Bicho contra Lucha -> Super efectivo (200%)
        bicho.CrearEfectividad(planta,2.0);       // Bicho contra Planta -> Super efectivo (200%)
        bicho.CrearEfectividad(psiquico,2.0);     // Bicho contra Psiquico -> Super efectivo (200%)
        bicho.CrearEfectividad(veneno,2.0);       // Bicho contra Veneno -> Super efectivo (200%)
        bicho.CrearEfectividad(volador,0.5);      // Bicho contra Volador -> Poco efectivo (50%)
        
        //Definir efectividades del tipo Dragon
        dragon.CrearEfectividad(dragon,2.0);      // Dragon contra Dragon -> Super efectivo (200%)
        
        //Definir efectividades del tipo Fantasma
        fantasma.CrearEfectividad(psiquico,2.0);  // Fantasma contra Psiquico -> Super efectivo (200%)
        
        //Definir efectividades del tipo Hielo
        hielo.CrearEfectividad(agua, 0.5);        // Hielo contra Agua -> Poco efectivo (50%)
        hielo.CrearEfectividad(dragon,2.0);       // Hielo contra Dragon -> Super efectivo (200%)
        hielo.CrearEfectividad(hielo,0.5);        // Hielo contra Hielo -> Poco efectivo (50%)
        hielo.CrearEfectividad(tierra,2.0);       // Hielo contra Tierra -> Super efectivo (200%)
        hielo.CrearEfectividad(volador,2.0);      // Hielo contra Volador -> Super efectivo (200%)
        
        //Definir efectividades del tipo Lucha
        lucha.CrearEfectividad(bicho,0.5);        // Lucha contra Bicho -> Poco efectivo (50%)
        lucha.CrearEfectividad(fantasma,0.5);     // Lucha contra Fantasma -> Poco efectivo (50%)
        lucha.CrearEfectividad(hielo,2.0);        // Lucha contra Hielo -> Super efectivo (200%)
        lucha.CrearEfectividad(normal,2.0);       // Lucha contra Normal -> Super efectivo (200%)
        lucha.CrearEfectividad(psiquico,2.0);     // Lucha contra Psiquico -> Super efectivo (200%)
        lucha.CrearEfectividad(roca,2.0);         // Lucha contra Roca -> Super efectivo (200%)
        lucha.CrearEfectividad(veneno,2.0);       // Lucha contra Veneno -> Super efectivo (200%)
        lucha.CrearEfectividad(volador,0.5);      // Lucha contra Volador -> Poco efectivo (50%)
        
        //Definir efectividades del tipo Psiquico
        psiquico.CrearEfectividad(lucha,2.0);     // Psiquico contra Lucha -> Super efectivo (200%)
        psiquico.CrearEfectividad(veneno,2.0);    // Psiquico contra Veneno -> Super efectivo (200%)
        
        //Definir efectividades del tipo Veneno
        veneno.CrearEfectividad(bicho,2.0);       // Veneno contra Bicho -> Super efectivo (200%)
        veneno.CrearEfectividad(fantasma,0.5);    // Veneno contra Fantasma -> Poco efectivo (50%)
        veneno.CrearEfectividad(planta,2.0);      // Veneno contra Planta -> Super efectivo (200%)
        veneno.CrearEfectividad(roca,0.5);        // Veneno contra Roca -> Poco efectivo (50%)
        veneno.CrearEfectividad(tierra,2.0);      // Veneno contra Tierra -> Super efectivo (200%)
        veneno.CrearEfectividad(veneno,0.5);      // Veneno contra Veneno -> Poco efectivo (50%)
        
        // Se agragan a la lista todos los tipos
       listatiposdisponibles.Add(electrico); //0
        listatiposdisponibles.Add(fuego);
        listatiposdisponibles.Add(agua);
        listatiposdisponibles.Add(planta);
        listatiposdisponibles.Add(volador);
        listatiposdisponibles.Add(normal);
        listatiposdisponibles.Add(roca);
        listatiposdisponibles.Add(tierra); //7
        listatiposdisponibles.Add(bicho);
        listatiposdisponibles.Add(dragon);
        listatiposdisponibles.Add(fantasma);
        listatiposdisponibles.Add(hielo);
        listatiposdisponibles.Add(lucha);
        listatiposdisponibles.Add(psiquico);
        listatiposdisponibles.Add(veneno);//14
    }

    /// <summary>  
    /// Crea los movimientos disponibles en la Pokédex.  
    /// (Este método debe ser implementado según los movimientos necesarios.)  
    /// </summary> 
    private static void CrearMovimientos()
    {
        // Movimientos de Pidgey 
        MovimientoDeAtaque picotazo = new MovimientoDeAtaque("Picotazo", 60, listatiposdisponibles[4], 95); // Volador
        MovimientoEspecial vendaval = new MovimientoEspecial("Vendaval", 110, listatiposdisponibles[4], 100,listaEfectos[0]); // Volador (especial)
        MovimientoDeAtaque golpeCabeza = new MovimientoDeAtaque("Golpe Cabeza", 70, listatiposdisponibles[5], 100); // Normal

        // Movimientos de Pikachu 
        MovimientoEspecial rayo = new MovimientoEspecial("Rayo", 95, listatiposdisponibles[0], 100,listaEfectos[1]); // Electrico (especial)
        MovimientoDeAtaque electroBola = new MovimientoDeAtaque("Electro Bola", 65, listatiposdisponibles[0], 95); // Electrico
        MovimientoDeAtaque ataqueRapido = new MovimientoDeAtaque("Ataque Rápido", 60, listatiposdisponibles[5], 100); // Normal

        // Movimientos de Larvitar 
        MovimientoDeAtaque lanzaRocas = new MovimientoDeAtaque("LanzaRocas", 50, listatiposdisponibles[6], 90); // Roca
        MovimientoEspecial terremoto = new MovimientoEspecial("Terremoto", 100, listatiposdisponibles[7], 100,listaEfectos[1]);   // Tierra (especial)
        MovimientoDeAtaque mordisco = new MovimientoDeAtaque("Mordisco", 60, listatiposdisponibles[5], 100); // Siniestro

        // Movimientos de Bulbasaur 
        MovimientoEspecial lluevehojas = new MovimientoEspecial("Lluevehojas", 95, listatiposdisponibles[3], 90,listaEfectos[2]); // Planta (especial)
        MovimientoDeAtaque bombaLodo = new MovimientoDeAtaque("BombaLodo", 70, listatiposdisponibles[3], 100); // Planta
        MovimientoDeAtaque golpeCuerpo = new MovimientoDeAtaque("Golpe Cuerpo", 65, listatiposdisponibles[5], 100); // Normal

        // Movimientos de Charmander 
        MovimientoDeAtaque furiaDragon = new MovimientoDeAtaque("Furia Dragon", 40, listatiposdisponibles[9], 100); // Daño fijo (o lo ajustamos a 100)
        MovimientoEspecial lanzallamas = new MovimientoEspecial("Lanzallamas", 70, listatiposdisponibles[1], 100,listaEfectos[3]); // Fuego
        MovimientoDeAtaque garraDragon = new MovimientoDeAtaque("Garra Dragon", 60, listatiposdisponibles[9], 100); // Dragon

        // Movimientos de Squirtle 
        MovimientoDeAtaque hidropulso = new MovimientoDeAtaque("Hidropulso", 60, listatiposdisponibles[2], 100); // Agua
        MovimientoEspecial hidrobomba = new MovimientoEspecial("Hidrobomba", 95, listatiposdisponibles[2], 80,listaEfectos[0]); // Agua (especial)
        MovimientoDeAtaque cabezazo = new MovimientoDeAtaque("Cabezazo", 40, listatiposdisponibles[5], 100); // Normal
        
        //Movimientos de Caterpie
        MovimientoDeAtaque picotazoCater = new MovimientoDeAtaque("Picotazo", 60, listatiposdisponibles[5],100);//Normal
        MovimientoEspecial disparoDemora = new MovimientoEspecial("Disparo Demora", 30, listatiposdisponibles[8], 100, listaEfectos[1]);//Bicho, Paralizar
        MovimientoDeAtaque placajeTackle = new MovimientoDeAtaque("Placaje Tackle", 40, listatiposdisponibles[8], 100);//Bicho
        
        //Movimientos de Dratini
        MovimientoEspecial besoDragon = new MovimientoEspecial("Beso Dragon", 80, listatiposdisponibles[9], 100, listaEfectos[0]);
        MovimientoDeAtaque cascada = new MovimientoDeAtaque("Cascada", 80, listatiposdisponibles[0], 100);//Agua
        MovimientoDeAtaque acuaCola = new MovimientoDeAtaque("Acua Cola", 90, listatiposdisponibles[0], 90);//Aguac
        
        //Movimientos de Gengar
        MovimientoEspecial punioFuego = new MovimientoEspecial("Puño Fuego", 75, listatiposdisponibles[1], 100, listaEfectos[3]); //Fuego, Quemar
        MovimientoDeAtaque sombraVil = new MovimientoDeAtaque("Sombra Vil", 65, listatiposdisponibles[10], 100); //Fantasma
        MovimientoDeAtaque puyaNociva = new MovimientoDeAtaque("Puya Nociva", 80, listatiposdisponibles[14], 100); //Veneno
        
        //Movimientos de Regice
        MovimientoEspecial punioHielo = new MovimientoEspecial("Puño Hielo", 75, listatiposdisponibles[11], 100, listaEfectos[1]);// Hielo, Paralizar
        MovimientoDeAtaque avalancha = new MovimientoDeAtaque("Avalancha", 60, listatiposdisponibles[11], 100);//Hielo
        MovimientoDeAtaque treparrocas = new MovimientoDeAtaque("Treparrocas", 90, listatiposdisponibles[5], 85);//Normal
        
        //Movimientos de Stufful
        MovimientoEspecial punioCertero = new MovimientoEspecial("Puñu Certero", 150, listatiposdisponibles[12], 100, listaEfectos[0]); //lucha, Dormir
        MovimientoDeAtaque demolicion = new MovimientoDeAtaque("Demolicion", 75, listatiposdisponibles[12], 100); //Lucha
        MovimientoDeAtaque derribo = new MovimientoDeAtaque("Derribo", 90, listatiposdisponibles[5], 95);//Normal
        
        //Movimientos de Gardevoir
        MovimientoEspecial premonicion = new MovimientoEspecial("Premonicion", 120, listatiposdisponibles[13], 95, listaEfectos[0]);// Psiquico, Dormir
        MovimientoDeAtaque psiocarga = new MovimientoDeAtaque("Psicocarga", 80, listatiposdisponibles[13], 100);// Psiquico
        MovimientoDeAtaque rapidez = new MovimientoDeAtaque("Rapidez", 60, listatiposdisponibles[5], 100);// Normal
            
        //Movimientos de Arbok
        MovimientoEspecial lanzaMugre = new MovimientoEspecial("Lanza Mugre", 120, listatiposdisponibles[14], 100, listaEfectos[2]);//Veneno, Envenenar
        MovimientoDeAtaque colaVeneno = new MovimientoDeAtaque("Cola Veneno", 50, listatiposdisponibles[14], 100);//Veneno
        MovimientoDeAtaque fuerza = new MovimientoDeAtaque("Fuerza", 80, listatiposdisponibles[5], 90);//Normal
        
        MovimientoDeDefensa proteccion = new MovimientoDeDefensa("Protección", 40, listatiposdisponibles[5], false); // Normal + bonificación defensa

        // Agregar movimientos a la lista
        
        //Pidgey
        listaMovimientos.Add(picotazo); // 0
        listaMovimientos.Add(vendaval); //1
        listaMovimientos.Add(golpeCabeza);//2
        //pikachu
        listaMovimientos.Add(rayo);//3
        listaMovimientos.Add(electroBola);//4
        listaMovimientos.Add(ataqueRapido);//5
        //Larvitar
        listaMovimientos.Add(lanzaRocas);//6
        listaMovimientos.Add(terremoto);//7
        listaMovimientos.Add(mordisco);//8
        //Bulbasaur
        listaMovimientos.Add(lluevehojas);//9
        listaMovimientos.Add(bombaLodo);//10
        listaMovimientos.Add(golpeCuerpo);//11
        //Charmander
        listaMovimientos.Add(furiaDragon);//12
        listaMovimientos.Add(lanzallamas);//13
        listaMovimientos.Add(garraDragon);//14
        //Squirtle
        listaMovimientos.Add(hidropulso);//15
        listaMovimientos.Add(hidrobomba);//16
        listaMovimientos.Add(cabezazo);//17
        //Todos
        listaMovimientos.Add(proteccion);//18
        //caterpie
        listaMovimientos.Add(picotazoCater);//19
        listaMovimientos.Add(disparoDemora);//20
        listaMovimientos.Add(placajeTackle);//21
        //Dratini
        listaMovimientos.Add(besoDragon);//22
        listaMovimientos.Add(cascada);//23
        listaMovimientos.Add(acuaCola);//24
        //Gengar
        listaMovimientos.Add(punioFuego);//25
        listaMovimientos.Add(sombraVil);//26
        listaMovimientos.Add(puyaNociva);//27
        //Regice
        listaMovimientos.Add(punioHielo);//28
        listaMovimientos.Add(avalancha);//29
        listaMovimientos.Add(treparrocas);//30
        //Stufful
        listaMovimientos.Add(punioCertero);//31
        listaMovimientos.Add(demolicion);//32
        listaMovimientos.Add(derribo);//33
        //Gardevoir
        listaMovimientos.Add(premonicion);//34
        listaMovimientos.Add(psiocarga);//35
        listaMovimientos.Add(rapidez);//36
        //Arbok
        listaMovimientos.Add(lanzaMugre);//37
        listaMovimientos.Add(colaVeneno);//38
        listaMovimientos.Add(fuerza);//39
        
    }

    /// <summary>  
    /// Crea los Pokémon disponibles en la Pokédex con todos sus datos correspondientes.  
    /// (Este método debe ser implementado según los Pokémon necesarios.)  
    /// </summary> 
    private static void CrearPokemones()
    {

        List<IMovimiento> movimientosPikachu = new List<IMovimiento>
        {
            listaMovimientos[3],
            listaMovimientos[4],
            listaMovimientos[5],
            listaMovimientos[18]
        };
        List<Tipo> tiposPikachu = new List<Tipo>{listatiposdisponibles[0]};
        Pokemon Pikachu = new Pokemon("Pikachu", movimientosPikachu, tiposPikachu, 80, 60);
        
        pokemonsdisponibles.Add(Pikachu);
        // Crear los movimientos para Pidgey
        List<IMovimiento> movimientosPidgey = new List<IMovimiento>
        {
            listaMovimientos[0],  // Picotazo
            listaMovimientos[1],  // Vendaval
            listaMovimientos[2],  // Golpe Cabeza
            listaMovimientos[18]  // Protección
        };
        List<Tipo> tiposPidgey = new List<Tipo> { listatiposdisponibles[4], listatiposdisponibles[5] }; // Volador, Normal
        Pokemon Pidgey = new Pokemon("Pidgey", movimientosPidgey, tiposPidgey, 60, 40);
        pokemonsdisponibles.Add(Pidgey);

        // Crear los movimientos para Larvitar
        List<IMovimiento> movimientosLarvitar = new List<IMovimiento>
        {
            listaMovimientos[6],  // LanzaRocas
            listaMovimientos[7],  // Terremoto
            listaMovimientos[8],  // Mordisco
            listaMovimientos[18]  // Protección
        };
        List<Tipo> tiposLarvitar = new List<Tipo> { listatiposdisponibles[6], listatiposdisponibles[7] }; // Roca, Tierra
        Pokemon Larvitar = new Pokemon("Larvitar", movimientosLarvitar, tiposLarvitar, 80, 70);
        pokemonsdisponibles.Add(Larvitar);

        // Crear los movimientos para Bulbasaur
        List<IMovimiento> movimientosBulbasaur = new List<IMovimiento>
        {
            listaMovimientos[9],  // Lluevehojas
            listaMovimientos[10], // Bomba Lodo
            listaMovimientos[11],  // Golpe Cuerpo
            listaMovimientos[18]  // Protección
        };
        List<Tipo> tiposBulbasaur = new List<Tipo> { listatiposdisponibles[3]}; // Planta
        Pokemon Bulbasaur = new Pokemon("Bulbasaur", movimientosBulbasaur, tiposBulbasaur, 90, 70);
        pokemonsdisponibles.Add(Bulbasaur);

        // Crear los movimientos para Charmander
        List<IMovimiento> movimientosCharmander = new List<IMovimiento>
        {
            listaMovimientos[12], // Furia Dragon
            listaMovimientos[13], // Lanzallamas
            listaMovimientos[14],  // Garra Dragon
            listaMovimientos[18]  // Protección
        };
        List<Tipo> tiposCharmander = new List<Tipo> { listatiposdisponibles[1] }; // Fuego
        Pokemon Charmander = new Pokemon("Charmander", movimientosCharmander, tiposCharmander, 85, 60);
        pokemonsdisponibles.Add(Charmander);

        // Crear los movimientos para Squirtle
        List<IMovimiento> movimientosSquirtle = new List<IMovimiento>
        {
            listaMovimientos[15], // Hidropulso
            listaMovimientos[16], // Hidrobomba
            listaMovimientos[17], // Cabezazo
            listaMovimientos[18]  // Protección
        };
        List<Tipo> tiposSquirtle = new List<Tipo> { listatiposdisponibles[2] }; // Agua
        Pokemon Squirtle = new Pokemon("Squirtle", movimientosSquirtle, tiposSquirtle, 80, 70);
        pokemonsdisponibles.Add(Squirtle);
        
        //Crear los movimientos para Caterpie
        List<IMovimiento> movimientosCaterpie = new List<IMovimiento>
        {
            listaMovimientos[19], // Picotazo cola
            listaMovimientos[20], //Disparo Demora
            listaMovimientos[21], //Placaje Tackle
            listaMovimientos[18] //Proteccion
        };

        List<Tipo> tiposCaterpie = new List<Tipo> { listatiposdisponibles[8] };//Bicho
        Pokemon Caterpie = new Pokemon("Caterpie", movimientosCaterpie, tiposCaterpie, 45, 55);
        pokemonsdisponibles.Add(Caterpie);
        
        //Crear los movimientos para Dratini
        List<IMovimiento> movimientosDratini = new List<IMovimiento>
        {
            listaMovimientos[22], // Beso Dragon
            listaMovimientos[23], //Cascada
            listaMovimientos[24], //Acua Cola
            listaMovimientos[18] //Proteccion
        };

        List<Tipo> tiposDratini = new List<Tipo> { listatiposdisponibles[9] };//Dragon
        Pokemon Dratini = new Pokemon("Dratini", movimientosDratini, tiposDratini, 82, 94);
        pokemonsdisponibles.Add(Dratini);
        
        //Crear los movimientos para Gengar
        List<IMovimiento> movimientosGengar = new List<IMovimiento>
        {
            listaMovimientos[25], // Punio Fuego
            listaMovimientos[26], //Sombra Vil
            listaMovimientos[27], //Puya Nociva
            listaMovimientos[18] //Proteccion
        };

        List<Tipo> tiposGengar = new List<Tipo> { listatiposdisponibles[10] };//Fantasma
        Pokemon Gengar = new Pokemon("Gengar", movimientosGengar, tiposGengar, 60, 149);
        pokemonsdisponibles.Add(Gengar);
        
        //Crear los movimientos para Regice
        List<IMovimiento> movimientosRegice = new List<IMovimiento>
        {
            listaMovimientos[28], //Punio Hielo
            listaMovimientos[29], //Avalancha
            listaMovimientos[30], //Treparrocas
            listaMovimientos[18] //Proteccion
        };

        List<Tipo> tiposRegice = new List<Tipo> { listatiposdisponibles[11] };//Hielo
        Pokemon Regice = new Pokemon("Regice", movimientosRegice, tiposRegice, 80, 100);
        pokemonsdisponibles.Add(Regice);
        
        //Crear los movimientos para Stufful
        List<IMovimiento> movimientosStufful = new List<IMovimiento>
        {
            listaMovimientos[31], //Punio Certero
            listaMovimientos[31], //Demolicion
            listaMovimientos[33], //Derribo
            listaMovimientos[18] //Proteccion
        };

        List<Tipo> tiposStufful = new List<Tipo> { listatiposdisponibles[12] };//Lucha
        Pokemon Stufful = new Pokemon("Stufful", movimientosStufful, tiposStufful, 70, 50);
        pokemonsdisponibles.Add(Stufful);
        
        //Crear los movimientos para Gardeovir
        List<IMovimiento> movimientosGardevoir = new List<IMovimiento>
        {
            listaMovimientos[34], //Premonicion
            listaMovimientos[35], //Psico Carga
            listaMovimientos[36], //Rapidez
            listaMovimientos[18] //Proteccion
        };

        List<Tipo> tiposGardevoir = new List<Tipo> { listatiposdisponibles[13] };//Psiquico
        Pokemon Gardevoir = new Pokemon("Gardevoir", movimientosGardevoir, tiposGardevoir, 68, 65);
        pokemonsdisponibles.Add(Gardevoir);
        
        //Crear los movimientos para Arbok
        List<IMovimiento> movimientosArbok = new List<IMovimiento>
        {
            listaMovimientos[37], //Lanza Mugre
            listaMovimientos[38], //Cola veneno
            listaMovimientos[39], //Fuerza
            listaMovimientos[18] //Proteccion
        };

        List<Tipo> tiposArbok = new List<Tipo> { listatiposdisponibles[14] };//Veneno
        Pokemon Arbok = new Pokemon("Arbok", movimientosArbok, tiposArbok, 60, 195);
        pokemonsdisponibles.Add(Arbok);
    }
}
