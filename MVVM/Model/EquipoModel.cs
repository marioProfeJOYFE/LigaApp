using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace LigaApp.MVVM.Model
{
    public class EquipoModel
    {
        //ESTA PROPIEDAD NO VIENE EN EL JSON, LA AÑADO YO PARA LUEGO ORDENAR LA LISTA
        public int posicion { get; set; }
        public string id {  get; set; }
        public string NOMBRE { get; set; }
        public string N_PARTIDOS { get; set; }
        public string N_VICTORIAS { get; set; }
        public string N_DERROTAS { get; set; }
        public string N_EMPATES { get; set; }
        public string G_FAVOR {  get; set; }
        public string G_CONTRA {  get; set; }
        public string PUNTOS { get; set; }
        public string DIF {  get; set; }
        public string colorCamiseta { get; set; }
        public string escudo { get; set; }

        public string EscudoCompleto => $"https://chetosfs.com/{escudo}";

        public SolidColorBrush ColorCamisetaBrush
        {
            get => new BrushConverter().ConvertFromString(colorCamiseta) as SolidColorBrush ?? Brushes.Gray;
        }


        public override string ToString()
        {
            return $"Equipo: {NOMBRE}";
        }
    }
}
