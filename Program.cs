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
        for (int i = 0; i < 5; i++)
        {
            Console.WriteLine("Barco: " + nombreBarcos[i]);
            barcoList.Add(batalla.SolicitarCoordenadas(nombreBarcos[i]));

        }

    }

    private Barco SolicitarCoordenadas(string nombre)
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

        barco.Nombre = nombre;

        Console.WriteLine("Ingrese si su barco estará en Vertical, escriba 0, o si estará en horizontal escriba 1");
        barco.Posicion = Int32.Parse(Console.ReadLine());
        Console.WriteLine(" Ingrese coordenada numérica en la que iniciará las dimensiones de su barco del 1 al 10");
        barco.CasillaInicialX = Int32.Parse(Console.ReadLine());
        Console.WriteLine(" Ingrese coordenada Alfanumérica en la que iniciará las dimensiones de su barco, de la A a la J");
        barco.CasillaInicialY = Convert.ToChar(Console.ReadLine().ToUpper()) - 65;

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
        }
    }

    private List<Casilla> DibujarBarco(List<Barco> barcoList)
    {
        BatallaNaval batalla = new BatallaNaval();
        List<Casilla> casillaList = new List<Casilla>();
        Casilla casilla;

        casilla = new Casilla();


        foreach (Barco barco in barcoList)
        {
            if (barco.Posicion == 0)
            {
                for (int y = barco.CasillaInicialY; y < (barco.CasillaInicialY+barco.NumeroCasillas); y++)
                {
                    casilla.CoordenadaX=barco.CasillaInicialX;
                    casilla.CoordenadaY=y;
                }
            }else {
                for (int x = barco.CasillaInicialX; x < (barco.CasillaInicialX+barco.NumeroCasillas); x++)
                {
                    casilla.CoordenadaY=barco.CasillaInicialY;
                    casilla.CoordenadaX=x;
                }
            }
            casilla.EspacioDisp = " B |";
            casilla.Estado = 1;
            
            casillaList.Add(casilla);
            
        }
        return casillaList;
    }
    private static void DibujarCuadricula()
    {
        Casilla miCasilla;

        miCasilla = new Casilla();
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

        for (int valor = 65; valor < 75; valor++)
        {
            char letra = (char)(valor);
            Console.Write("\n" + letra + "|");
            for (i = 0; i < 10; i++)
            {
                Console.Write(miCasilla.EspacioDisp);
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
