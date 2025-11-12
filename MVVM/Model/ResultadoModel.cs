using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LigaApp.MVVM.Model
{
    public class ResultadoModel
    {
        public string id { get; set; }
        public string NOMBRE { get; set; }
        public string ESCUDO { get; set; }
        public string FECHA { get; set; } // Se leerá como string "2025-10-19 16:30:00"
        public string CAMPO { get; set; }
        public string G_LOCAL { get; set; }
        public string G_VISITANTE { get; set; }
        public string local { get; set; }

        public string EscudoCompletoLocal => $"https://chetosfs.com/{ESCUDO}";

        public string NOMBRE_VISITANTE { get; set; }
        public string ESCUDO_VISITANTE { get; set; }

        public string EscudoCompletoVisitante => $"https://chetosfs.com/{ESCUDO_VISITANTE}";

        public void comprobarVisitante()
        {
            if (local == "1")
            {
                // El equipo local es el equipo de referencia
                NOMBRE_VISITANTE = NOMBRE;
                ESCUDO_VISITANTE = ESCUDO;
                NOMBRE = "Chetos F.S.";
                ESCUDO = "escudo_azul_rosa.png";
            }else
            {
                // El equipo visitante es el equipo de referencia
                NOMBRE_VISITANTE = "Chetos F.S.";
                ESCUDO_VISITANTE = "escudo_azul_rosa.png";
            }
        }
    }
}
