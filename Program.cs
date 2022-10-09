using System.Diagnostics;
using System;

class BatallaNaval
{

    static void Main()
    {
        BatallaNaval batalla = new BatallaNaval();
        Console.WriteLine(@"

  ____       _______       _      _                     _   _     __      __     _      
 |  _ \   /\|__   __|/\   | |    | |        /\         | \ | |   /\ \    / /\   | |     
 | |_) | /  \  | |  /  \  | |    | |       /  \        |  \| |  /  \ \  / /  \  | |     
 |  _ < / /\ \ | | / /\ \ | |    | |      / /\ \       | . ` | / /\ \ \/ / /\ \ | |     
 | |_) / ____ \| |/ ____ \| |____| |____ / ____ \      | |\  |/ ____ \  / ____ \| |____ 
 |____/_/    \_\_/_/    \_\______|______/_/    \_\     |_| \_/_/    \_\/_/    \_\______|
                                                                                        
                                                                                          
            

                                     # #  ( )
                                  ___#_#___|__
                              _  |____________|  _
                       _=====| | |            | | |==== _
                 =====| |.---------------------------. | |====
   <--------------------'   .  .  .  .  .  .  .  .   '--------------/
     \                                                             /
      \___________________________________________________________/
      ");
        string[] nombreBarcos = { "portaaviones", "acorazado", "crucero", "submarino", "destructor" };

        List<Casilla> casillaListTiro1 = new List<Casilla>();
        List<Casilla> casillaListTiro2 = new List<Casilla>();
        List<Casilla> casillaListFlota1 = new List<Casilla>();
        List<Casilla> casillaListFlota2 = new List<Casilla>();

        List<Tiro> ataqueJugador1 = new List<Tiro>();
        List<Tiro> ataqueJugador2 = new List<Tiro>();

        Jugador jugador1 = new Jugador();
        Jugador jugador2 = new Jugador();
        Console.WriteLine(@"
       _                       _              __  
      | |                     | |            /_ | 
      | |_   _  __ _  __ _  __| | ___  _ __   | | 
  _   | | | | |/ _` |/ _` |/ _` |/ _ \| '__|  | | 
 | |__| | |_| | (_| | (_| | (_| | (_) | |     | | 
  \____/ \__,_|\__, |\__,_|\__,_|\___/|_|     |_| 
                __/ |                             
               |___/                              ");

        for (int i = 0; i < 5; i++)
        {
            if (jugador1.Flota.Count < 1)
            {
                Console.WriteLine("for antes");
                jugador1.Flota.Add(batalla.SolicitarCoordenadas(nombreBarcos[i], casillaListFlota1));
            }
            else
            {
                jugador1.Flota.Add(batalla.SolicitarCoordenadas(nombreBarcos[i], casillaListFlota1));
            }
            casillaListFlota1.AddRange(jugador1.Flota[i].Area);
            DibujarCuadricula(casillaListFlota1);

        }


        Console.WriteLine("Presione cualquier letra para continuar");
        string continuar = Console.ReadLine();
        //Console.Clear();
        Console.WriteLine(@"
       _                       _              ___   
      | |                     | |            |__ \  
      | |_   _  __ _  __ _  __| | ___  _ __     ) | 
  _   | | | | |/ _` |/ _` |/ _` |/ _ \| '__|   / /  
 | |__| | |_| | (_| | (_| | (_| | (_) | |     / /_  
  \____/ \__,_|\__, |\__,_|\__,_|\___/|_|    |____| 
                __/ |                               
               |___/ ");


        for (int i = 0; i < 5; i++)
        {
            if (jugador2.Flota.Count < 1)
            {
                jugador2.Flota.Add(batalla.SolicitarCoordenadas(nombreBarcos[i], casillaListFlota2));
            }
            else
            {
                jugador2.Flota.Add(batalla.SolicitarCoordenadas(nombreBarcos[i], casillaListFlota2));
            }
            casillaListFlota2.AddRange(jugador2.Flota[i].Area);
            DibujarCuadricula(casillaListFlota2);

        }

        Console.WriteLine("Presione cualquier letra para continuar");
        continuar = Console.ReadLine();
        // Console.Clear();

        Console.WriteLine(@"
                
    ______                _                          __     _                      
   / ____/___ ___  ____  (_)__  ____  ____ _   ___  / /    (_)_  _____  ____ _____ 
  / __/ / __ `__ \/ __ \/ / _ \/_  / / __ `/  / _ \/ /    / / / / / _ \/ __ `/ __ \
 / /___/ / / / / / /_/ / /  __/ / /_/ /_/ /  /  __/ /    / / /_/ /  __/ /_/ / /_/ /
/_____/_/ /_/ /_/ .___/_/\___/ /___/\__,_/   \___/_/  __/ /\__,_/\___/\__, /\____/ 
               /_/                                   /___/           /____/        
");

        do
        {
            Console.WriteLine(@"

 _____ _  _ ___ __  _  __    __  _  _  __  __  __   __  ___     __  
|_   _| || | _ \  \| |/__\  |_ \| || |/ _]/  \| _\ /__\| _ \   /  | 
  | | | \/ | v / | ' | \/ |  _\ | \/ | [/\ /\ | v | \/ | v /   `7 | 
  |_|  \__/|_|_\_|\__|\__/  /___|\__/ \__/_||_|__/ \__/|_|_\    |_| ");


            jugador1 = batalla.SolicitarTiro(jugador2, jugador1);
            DibujarCuadricula(jugador1.Tablero);
            Console.WriteLine("Presione cualquier letra para continuar");
            continuar = Console.ReadLine();


            Console.WriteLine(@"

 _____ _  _ ___ __  _  __    __  _  _  __  __  __   __  ___      ___  
|_   _| || | _ \  \| |/__\  |_ \| || |/ _]/  \| _\ /__\| _ \    (_  | 
  | | | \/ | v / | ' | \/ |  _\ | \/ | [/\ /\ | v | \/ | v /     / /  
  |_|  \__/|_|_\_|\__|\__/  /___|\__/ \__/_||_|__/ \__/|_|_\    |___| ");



            jugador2 = batalla.SolicitarTiro(jugador1, jugador2);
            DibujarCuadricula(jugador2.Tablero);
            Console.WriteLine("Presione cualquier letra para continuar");
            continuar = Console.ReadLine();
        } while (jugador1.Ataque.Count(tiro => (tiro.Resultado == 1)) < 15 || jugador2.Ataque.Count(tiro => (tiro.Resultado == 1)) < 15);

        if (jugador1.Ataque.Count(tiro => (tiro.Resultado == 1)) > jugador1.Ataque.Count(tiro => (tiro.Resultado == 1)))
        {
            Console.WriteLine(@"
  __  __  __  _  __    __  _  _  __  __  __   __  ___   __  
 / _]/  \|  \| |/  \  |_ \| || |/ _]/  \| _\ /__\| _ \ /  | 
| [/\ /\ | | ' | /\ |  _\ | \/ | [/\ /\ | v | \/ | v / `7 | 
 \__/_||_|_|\__|_||_| /___|\__/ \__/_||_|__/ \__/|_|_\  |_| ");
        }
        else
        {
            Console.WriteLine(@"
  __  __  __  _  __    __  _  _  __  __  __   __  ___   ___  
 / _]/  \|  \| |/  \  |_ \| || |/ _]/  \| _\ /__\| _ \ (_  | 
| [/\ /\ | | ' | /\ |  _\ | \/ | [/\ /\ | v | \/ | v /  / /  
 \__/_||_|_|\__|_||_| /___|\__/ \__/_||_|__/ \__/|_|_\ |___| ");

        }

    }
    private List<Casilla> DibujarTiro(Tiro tiro, List<Casilla> casillaList2)
    {
        Console.WriteLine("dibujando..");
        Tiro tiro1 = tiro;
        List<Casilla> casillaList = new List<Casilla>();

        switch (tiro.Resultado)
        {
            case 1:
                Console.WriteLine("tiro acertado..");
                Casilla casilla = new Casilla();
                casilla.CoordenadaX = tiro.Coordenadas.CoordenadaX;
                casilla.CoordenadaY = tiro.Coordenadas.CoordenadaY;
                casilla.EspacioDisp = " x |";
                casilla.Estado = 2;

                casillaList.Add(casilla);

                break;
            case 0:
                Console.WriteLine("tiro fallido..");
                Casilla casilla1 = new Casilla();
                casilla1.CoordenadaX = tiro.Coordenadas.CoordenadaX;
                casilla1.CoordenadaY = tiro.Coordenadas.CoordenadaY;
                casilla1.EspacioDisp = " - |";
                casilla1.Estado = 3;

                casillaList.Add(casilla1);
                break;
            case 2:
                Console.WriteLine("Hundiste un barco..");
                Casilla casilla2 = new Casilla();
                casilla2.CoordenadaX = tiro.Coordenadas.CoordenadaX;
                casilla2.CoordenadaY = tiro.Coordenadas.CoordenadaY;
                casilla2.EspacioDisp = " @ |";
                casilla2.Estado = 4;

                casillaList.Add(casilla2);
                break;
        }

        Console.WriteLine(casillaList.Count());
        return casillaList;

    }
    private Jugador SolicitarTiro(Jugador jugadorOponente, Jugador jugador)
    {
        Tiro tiro = new Tiro();


        List<Casilla> casillaList = new List<Casilla>();

        Console.WriteLine("\n\n Elije la casilla a la que enviarás el tiro y escribe las coordenadas \n\n");

        tiro.Coordenadas.CoordenadaX = ValidarInt("Ingrese coordenada numérica X");
        tiro.Coordenadas.CoordenadaY = ValidarStr("Ingrese coordenada Alfanumérica Y") - 65;

        while (jugador.Tablero.Find(casilla => (casilla.CoordenadaX == tiro.Coordenadas.CoordenadaX) && (casilla.CoordenadaY == tiro.Coordenadas.CoordenadaY)) != null)
        {
            Console.WriteLine("Ya escribió esta coordenada, escriba otra");
            tiro.Coordenadas.CoordenadaX = ValidarInt("Ingrese coordenada numérica X");
            tiro.Coordenadas.CoordenadaY = ValidarStr("Ingrese coordenada Alfanumérica Y") - 65;

        }


        Console.WriteLine("X" + tiro.Coordenadas.CoordenadaX);
        Console.WriteLine("Y" + tiro.Coordenadas.CoordenadaY);

        tiro.Resultado = ResultadoTiro(tiro, jugador, jugadorOponente).Resultado;


        casillaList.AddRange(DibujarTiro(tiro, casillaList));

        jugador.Ataque.Add(tiro);
        jugador.Tablero.AddRange(casillaList);



        return jugador;

    }

    private Tiro ResultadoTiro(Tiro tiro, Jugador jugador, Jugador jugadorOponente)
    {
        int res = 0;
        List<Casilla> tirosBarco = new List<Casilla>();
        foreach (Tiro tiro1 in jugador.Ataque)
        {
            tirosBarco.Add(tiro1.Coordenadas);
        }
        foreach (Barco casillaBarco in jugadorOponente.Flota)
        {

            if (casillaBarco.Area.Find(casilla => casilla.CoordenadaX == tiro.Coordenadas.CoordenadaX && casilla.CoordenadaY == tiro.Coordenadas.CoordenadaY)!=null)
            {
                tirosBarco.Add(tiro.Coordenadas);
                
                if (casillaBarco.Area.Except(tirosBarco).ToList().Count == 0)
                {
                    res = 2;
                }else {
                    res =1;
                }
            }
        }
        tiro.Resultado = res;
        return tiro;

    }
    private Barco DibujarBarco(Barco barco, List<Casilla> casillaList2)
    {
        BatallaNaval batalla = new BatallaNaval();
        List<Casilla> casillaList = new List<Casilla>();
        Casilla casilla;



        if (barco.Posicion == 0)
        {
            for (int y = barco.CasillaInicialY; y < (barco.CasillaInicialY + barco.NumeroCasillas); y++)
            {
                casilla = new Casilla();
                casilla.CoordenadaX = barco.CasillaInicialX;
                casilla.CoordenadaY = y;
                casilla.EspacioDisp = " B |";
                casilla.Estado = 1;

                casillaList.Add(casilla);

            }
        }
        else
        {
            for (int x = barco.CasillaInicialX; x < (barco.CasillaInicialX + barco.NumeroCasillas); x++)
            {
                casilla = new Casilla();
                casilla.CoordenadaY = barco.CasillaInicialY;
                casilla.CoordenadaX = x;
                casilla.EspacioDisp = " B |";
                casilla.Estado = 1;

                casillaList.Add(casilla);
            }
        }
        IEnumerable<Casilla> duplicates = casillaList2.Intersect(casillaList);

        foreach (var listas in duplicates)
        {
            Console.WriteLine(duplicates.Any());
        }

        if (duplicates.Any())
        {
            Console.WriteLine("CHOCA CON OTRO BARCO, ESCRIBE NUEVAS COORDENADAS");

            return SolicitarCoordenadas(barco.Nombre, casillaList2);
        }
        else
        {
            barco.Area.AddRange(casillaList);
            return barco;
        }


    }
    private Barco SolicitarCoordenadas(string nombre, List<Casilla> casillaList2)
    {
        Barco barco = new Barco();
        Console.WriteLine("for dentro");

        switch (nombre)
        {
            case "acorazado":
                barco.Nombre = nombre;
                barco.NumeroCasillas = 4;
                break;
            case "portaaviones":
                barco.Nombre = nombre;
                barco.NumeroCasillas = 5;
                break;
            case "crucero":
                barco.Nombre = nombre;
                barco.NumeroCasillas = 1;
                break;
            case "submarino":
                barco.Nombre = nombre;
                barco.NumeroCasillas = 3;
                break;
            case "destructor":
                barco.Nombre = nombre;
                barco.NumeroCasillas = 2;
                break;
        }
        List<Casilla> casillaList = new List<Casilla>();

        barco.Nombre = nombre;

        Console.WriteLine("\n\n" + barco.Nombre.ToUpper() + ": " + barco.NumeroCasillas + " casillas\n\n");

        barco.Posicion = ValidarIntPos("Ingrese si su barco estará en Vertical, escriba 0, o si estará en horizontal escriba 1");
        barco.CasillaInicialX = ValidarInt("Ingrese coordenada numérica en la que iniciará las dimensiones de su barco del 1 al 10");
        barco.CasillaInicialY = ValidarStr("Ingrese coordenada Alfanumérica en la que iniciará las dimensiones de su barco, de la A a la J") - 65;

        while ((10 < (barco.CasillaInicialX + barco.NumeroCasillas) && barco.Posicion == 1) || (10 < (barco.CasillaInicialY + barco.NumeroCasillas) && barco.Posicion == 0))
        {

            barco.CasillaInicialX = ValidarInt("LAS CASILLAS NO ESTAN DISPONIBLES coordenada numérica en la que iniciará las dimensiones de su barco del 1 al 10");
            barco.CasillaInicialY = ValidarStr("Ingrese coordenada Alfanumérica en la que iniciará las dimensiones de su barco, de la A a la J") - 65;
        }

        barco = DibujarBarco(barco, casillaList2);

        return barco;

    }
    private static void CambiarEspacio(int estado)
    {
        Casilla miCasilla;

        miCasilla = new Casilla();
        switch (estado)
        {
            case 0:
                miCasilla.EspacioDisp = "   |";
                break;
            case 1:
                miCasilla.EspacioDisp = " B |";
                break;
            case 2:
                miCasilla.EspacioDisp = " X |";
                break;
            Default:
                miCasilla.EspacioDisp = " - |";
        }
    }

    static int ValidarInt(string msj)
    {
        int valor;
        Console.WriteLine(msj);
        while (!Int32.TryParse(Console.ReadLine(), out valor) || valor < 1 || valor > 10)
        {
            Console.WriteLine("El dato ingresado no es valido, solo del 1 al 10, números sin espacios");
            Console.WriteLine(msj);
        }

        return valor;
    }
    static int ValidarIntPos(string msj)
    {
        int valor;
        Console.WriteLine(msj);
        while (!Int32.TryParse(Console.ReadLine(), out valor) || valor < 0 || valor > 1)
        {
            Console.WriteLine("El dato ingresado no es valido, 1 o 0, número sin espacios");
            Console.WriteLine(msj);
        }

        return valor;
    }
    static int ValidarStr(string msj)
    {
        char valor;
        Console.WriteLine(msj);
        while (!Char.TryParse(Console.ReadLine().ToUpper(), out valor) || valor < 65 || valor > 75)
        {
            Console.WriteLine("El dato ingresado no es admitido, de la A a la J solo una letra sin espacios");
            Console.WriteLine(msj);
        }

        return (valor);
    }
    private static void DibujarCuadricula(List<Casilla> casillaList)
    {
        string agua2 = "___|";

        int i = 0;
        for (i = 0; i < 10; i++)
        {
            Console.Write("   " + (i + 1));
        }

        Console.Write("\n  ");
        for (i = 0; i < 10; i++)
        {
            Console.Write("___ ");
        }
        bool espacio = false;
        for (int valor = 65; valor < 75; valor++)
        {
            char letra = (char)(valor);
            Console.Write("\n" + letra + "|");
            for (i = 1; i < 11; i++)
            {
                foreach (Casilla casilla in casillaList)
                {
                    if (casilla.CoordenadaY == (valor - 65) && casilla.CoordenadaX == i)
                    {
                        Console.Write(casilla.EspacioDisp);
                        espacio = true;
                        break;
                    }
                    else
                    {
                        espacio = false;
                    }
                }
                if (espacio == false)
                {
                    Console.Write("   |");
                    espacio = false;
                }
            }

            Console.Write("\n |");
            for (i = 0; i < 10; i++)
            {
                Console.Write(agua2);
            }
        }
    }
}



class Casilla
{
    public Casilla()
    {
        espacioDisp = "   |";
        coordenadaX = 0;
        coordenadaY = 0;
        estado = 1;
    }
    public bool Equals(Casilla other)
    {
        if (other is null)
            return false;

        return this.CoordenadaX == other.CoordenadaX && this.CoordenadaY == other.CoordenadaY;
    }

    public override bool Equals(object obj) => Equals(obj as Casilla);
    public override int GetHashCode() => (CoordenadaX, CoordenadaY).GetHashCode();
    private string espacioDisp;
    private int coordenadaX;
    private int coordenadaY;
    private int estado;

    public string EspacioDisp { get => espacioDisp; set => espacioDisp = value; }
    public int CoordenadaY { get => coordenadaY; set => coordenadaY = value; }
    public int CoordenadaX { get => coordenadaX; set => coordenadaX = value; }
    public int Estado { get => estado; set => estado = value; }
}
class Barco
{
    public Barco()
    {
        casillaInicialX = 3;
        casillaInicialY = 3;
        posicion = 1;
        numeroCasillas = 5;
        nombre = "portaviones";
        area = new List<Casilla>();

    }

    private int casillaInicialX;
    private int casillaInicialY;
    private int posicion;
    private int numeroCasillas;
    private string nombre;
    private List<Casilla> area;

    public string Nombre { get => nombre; set => nombre = value; }
    public int NumeroCasillas { get => numeroCasillas; set => numeroCasillas = value; }
    public int Posicion { get => posicion; set => posicion = value; }
    public int CasillaInicialX { get => casillaInicialX; set => casillaInicialX = value; }
    public int CasillaInicialY { get => casillaInicialY; set => casillaInicialY = value; }
    internal List<Casilla> Area { get => area; set => area = value; }
}
class Jugador
{
    public Jugador()
    {
        flota = new List<Barco>();
        ataque = new List<Tiro>();
        tablero = new List<Casilla>();
    }
    private List<Barco> flota;
    private List<Casilla> tablero;
    private List<Tiro> ataque;

    internal List<Barco> Flota { get => flota; set => flota = value; }
    internal List<Casilla> Tablero { get => tablero; set => tablero = value; }
    internal List<Tiro> Ataque { get => ataque; set => ataque = value; }
}
class Tiro
{
    public Tiro()
    {
        coordenadas = new Casilla();
        resultado = 0;
    }
    private Casilla coordenadas;
    private int resultado;

    public int Resultado { get => resultado; set => resultado = value; }
    internal Casilla Coordenadas { get => coordenadas; set => coordenadas = value; }
}