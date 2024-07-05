using Personajes;
using CuantoSabes;

namespace Pelea
{
    public class PeleaUsuario
    {

        public static Personaje PeleaPersonaje(Personaje peleadorUsuario, Personaje contrincante)
        {

            // Determino aleatoriamente quién comienza
            int numeroRandom = rand.Next(0, 2);
            int primerTurno = 1;

            while (peleadorUsuario.Caracteristicas.Salud > 0 && contrincante.Caracteristicas.Salud > 0)
            {

                if (numeroRandom == 1)
                {
                    // Turno del usuario
                    if (primerTurno == 1)
                    {
                        Console.WriteLine("Comienza atacando " + peleadorUsuario.Datos.Nombre);
                    }
                    AtaqueEspecial(peleadorUsuario, contrincante);

                    // Cambio de turno
                    numeroRandom = 0;
                }
                else
                {
                    // Turno del contrincante
                    if (primerTurno == 1)
                    {
                        Console.WriteLine("Comienza atacando " + contrincante.Datos.Nombre);
                    }
                    DefensaEspecial(contrincante, peleadorUsuario);

                    // Cambio de turno
                    numeroRandom = 1;
                }
                primerTurno++;
            }

            // Retorna el ganador
            if (peleadorUsuario.Caracteristicas.Salud <= 0)
            {
                contrincante.Caracteristicas.Salud = 100;
                return contrincante;
            }
            else
            {
                peleadorUsuario.Caracteristicas.Salud = 100;
                return peleadorUsuario;
            }

        }

        private static void AtaqueEspecial(Personaje atacante, Personaje defensor)
        {
            Console.WriteLine("\nAtaque Especial");
            int daño = DevolverDaño(atacante);
            bool respuesta = MostrarResultados.MostrarResultadosPreguntas();

            if (respuesta)
            {
                daño *= 2;
                AplicacionDañoYMensaje(atacante, defensor, daño);
            }
            else
            {
                AplicacionDañoYMensaje(atacante, defensor, daño);
            }

        }
        private static void DefensaEspecial(Personaje atacante, Personaje defensor)
        {
            Console.WriteLine("\nDefensa Especial");
            bool respuesta = MostrarResultados.MostrarResultadosPreguntas();
            int daño = DevolverDaño(atacante);

            if (respuesta)
            {
                daño /= 2;
                AplicacionDañoYMensaje(atacante, defensor, daño);
            }
            else
            {
                AplicacionDañoYMensaje(atacante, defensor, daño);
            }

        }

        private static void AplicacionDañoYMensaje(Personaje atacante, Personaje defensor, int daño)
        {
            defensor.Caracteristicas.Salud = defensor.Caracteristicas.Salud - daño;
            if (defensor.Caracteristicas.Salud < 0)
            {
                defensor.Caracteristicas.Salud = 0;
            }
            Console.WriteLine($"\n{atacante.Datos.Nombre} ataca a {defensor.Datos.Nombre} y causa {daño} puntos de daño. Salud restante de {defensor.Datos.Nombre}: {defensor.Caracteristicas.Salud}");
        }

        private static int DevolverDaño(Personaje personajeUsuario)
        {
            double Ataque = (personajeUsuario.Caracteristicas.Fuerza * 1.5) * (personajeUsuario.Caracteristicas.Velocidad * 1.5) * (personajeUsuario.Caracteristicas.Energia * 1.5);
            double Efectividad = rand.Next(50, 101);
            double Defensa = (personajeUsuario.Caracteristicas.Resistencia * 1.5) * (personajeUsuario.Caracteristicas.Agilidad * 1.5) * (personajeUsuario.Caracteristicas.Energia * 1.5);
            double CtteAjuste = 1000000;
            double dañoProvocado = ((Ataque * Efectividad) - Defensa) / CtteAjuste;

            return (int)dañoProvocado;
        }

        private static Random rand = new Random();

    }
}