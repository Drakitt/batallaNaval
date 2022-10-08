using System.Diagnostics;
using System;

class BatallaNaval
{

    static void Main()
    {
        BatallaNaval batalla = new BatallaNaval();
        Console.WriteLine(@"

 ___    __   _____   __    _     _      __        _       __    _       __    _    
| |_)  / /\   | |   / /\  | |   | |    / /\      | |\ |  / /\  \ \  /  / /\  | |   
|_|_) /_/--\  |_|  /_/--\ |_|__ |_|__ /_/--\     |_| \| /_/--\  \_\/  /_/--\ |_|__         
            

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
        List<Barco> barcoList = new List<Barco>();

        List<Casilla> casillaList = new List<Casilla>();
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Barco: " + nombreBarcos[i]);
            if (casillaList.Count < 1)
            {
                casillaList.AddRange(batalla.SolicitarCoordenadas(nombreBarcos[i], casillaList));
            }
            else
            {
                casillaList.AddRange(batalla.SolicitarCoordenadas(nombreBarcos[i], casillaList));
            }
            DibujarCuadricula(casillaList);

        }




    }

    private List<Casilla> DibujarBarco(Barco barco)
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



        return casillaList;
    }////////////////////////////////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////////////////////////////////
    //////////////////////////////////////////////////////////////////////////////////////////////////////
    private List<Casilla> SolicitarCoordenadas(string nombre, List<Casilla> casillaList2)
    {
        Barco barco = new Barco();

        switch (nombre)
        {
            case "acorazado":
                barco.NumeroCasillas = 4;
                break;
            case "portaaviones":
                barco.NumeroCasillas = 5;
                break;
            case "crucero":
                barco.NumeroCasillas = 1;
                break;
            case "submarino":
                barco.NumeroCasillas = 3;
                break;
            case "destructor":
                barco.NumeroCasillas = 2;
                break;
        }
        List<Casilla> casillaList = new List<Casilla>();

        barco.Nombre = nombre;

        Console.WriteLine("");
        barco.Posicion = ValidarIntPos("Ingrese si su barco estará en Vertical, escriba 0, o si estará en horizontal escriba 1");

        barco.CasillaInicialX = ValidarInt(" Ingrese coordenada numérica en la que iniciará las dimensiones de su barco del 1 al 10");
        barco.CasillaInicialY = ValidarStr(" Ingrese coordenada Alfanumérica en la que iniciará las dimensiones de su barco, de la A a la J") - 65;
        
        while (casillaList2.Find(casilla => (casilla.CoordenadaX == barco.CasillaInicialX)) != null && casillaList2.Find(casilla => (casilla.CoordenadaY == barco.CasillaInicialY)) != null)
        {
            barco.CasillaInicialX = ValidarInt("YA ESTA OCUPADO POR BARCO coordenada numérica en la que iniciará las dimensiones de su barco del 1 al 10");
            barco.CasillaInicialY = ValidarStr("YA ESTA OCUPADO POR BARCO Ingrese coordenada Alfanumérica en la que iniciará las dimensiones de su barco, de la A a la J") - 65;
        }

        casillaList = DibujarBarco(barco);

        return casillaList;

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
        }
    }

    static int ValidarInt(string msj)
    {
        int valor;
        Console.WriteLine(msj);
        while (!Int32.TryParse(Console.ReadLine(), out valor) || valor < 1 || valor > 10)
        {
            Console.WriteLine("El dato ingresado no es un entero, solo del 1 al 10, números sin espacios");
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
            Console.WriteLine("El dato ingresado no es un entero, solo del 1 al 10, números sin espacios");
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

    }

    private int casillaInicialX;
    private int casillaInicialY;
    private int posicion;
    private int numeroCasillas;
    private string nombre;

    public string Nombre { get => nombre; set => nombre = value; }
    public int NumeroCasillas { get => numeroCasillas; set => numeroCasillas = value; }
    public int Posicion { get => posicion; set => posicion = value; }
    public int CasillaInicialX { get => casillaInicialX; set => casillaInicialX = value; }
    public int CasillaInicialY { get => casillaInicialY; set => casillaInicialY = value; }
}
class Jugador
{
    public Jugador()
    {
        barco1 = new Barco();
    }
    Barco barco1;

    internal Barco Barco1 { get => barco1; set => barco1 = value; }
}
class Tiro
{
    public Tiro()
    {
        x = 0;
        Y = 0;
        resultado = false;
    }
    private int x;
    private int y;
    private bool resultado;

    public int X { get => x; set => x = value; }
    public bool Resultado { get => resultado; set => resultado = value; }
    public int Y { get => y; set => y = value; }
}
