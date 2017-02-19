using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ScintillaNET;

namespace Speck
{
    public partial class Speck : Form
    {
        internal string NombreArchivo;

        internal string CarpetaInicial = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        internal const string Mensaje = @"No has guardado tu archivo. ¿Desea guardarlo?";
        internal const string Titulo = @"No soy adivino ¬¬";
        internal const int OffsetContador = 1;

        internal const string Linea = @"Ln ";
        internal const string Columna = @"Col ";
        internal StringBuilder SbLinea = new StringBuilder();
        internal StringBuilder SbColumna = new StringBuilder();
        internal StringBuilder SbModificacion = new StringBuilder();

        public Speck()
        {
            InitializeComponent();

            //Configurar estilo (Fuente y Tamaño)
            cuadroEditor.StyleResetDefault();
            cuadroEditor.Styles[Style.Default].Font = "Calibri";
            cuadroEditor.Styles[Style.Default].Size = 10;
            cuadroEditor.StyleClearAll();

            //Colores texto
            cuadroEditor.Styles[Style.Cpp.CommentLine].ForeColor = Color.FromArgb(0, 128, 0);
            cuadroEditor.Styles[Style.Cpp.Comment].ForeColor = Color.FromArgb(0, 128, 0);
            cuadroEditor.Styles[Style.Cpp.CommentLineDoc].ForeColor = Color.FromArgb(128, 128, 128);
            cuadroEditor.Styles[Style.Cpp.Number].ForeColor = Color.Black;
            cuadroEditor.Styles[Style.Cpp.Word].ForeColor = Color.Blue;
            cuadroEditor.Styles[Style.Cpp.Word2].ForeColor = Color.FromArgb(173, 91, 255);
            cuadroEditor.Styles[Style.Cpp.String].ForeColor = Color.FromArgb(163, 21, 21);
            cuadroEditor.Styles[Style.Cpp.Character].ForeColor = Color.FromArgb(163, 21, 21);

            //Palabras clave
            cuadroEditor.SetKeywords(0, "if while do for int float string");
            cuadroEditor.SetKeywords(1, "lol asd qwe");

            //Número de linea
            cuadroEditor.Margins[0].Width = 40;
            cuadroEditor.Styles[Style.LineNumber].Font = "Calibri";
            cuadroEditor.Styles[Style.LineNumber].ForeColor = Color.White;
            cuadroEditor.Styles[Style.LineNumber].BackColor = Color.FromArgb(0, 88, 191, 255);
            cuadroEditor.Margins[0].Type = MarginType.Number;
        }

        private void GuardarArchivo()
        {
            var guardaLaGuindow = new SaveFileDialog();
            guardaLaGuindow.Filter = @"Prru (*.prru)|*.prru";
            guardaLaGuindow.InitialDirectory = CarpetaInicial;
            if (guardaLaGuindow.ShowDialog() == DialogResult.OK)
                NombreArchivo = guardaLaGuindow.FileName;

            if (!NombreArchivo.Equals(string.Empty))
            {
                var sw = new StreamWriter(NombreArchivo);
                sw.Write(cuadroEditor.Text);
                sw.Close();
                SbModificacion.Clear();
                SbModificacion.Append(cuadroEditor.Text);
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NombreArchivo == null && !cuadroEditor.Text.Equals(string.Empty) ||
                !cuadroEditor.Text.Equals(SbModificacion.ToString()))
            {
                var dialogoDeseaGuardar = MessageBox.Show(this, Mensaje, Titulo, MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
                switch (dialogoDeseaGuardar)
                {
                    case DialogResult.Yes:
                        GuardarArchivo();
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }
            cuadroEditor.Text = string.Empty;
            NombreArchivo = null;
            SbModificacion.Clear();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NombreArchivo == null && !cuadroEditor.Text.Equals(string.Empty) ||
                !cuadroEditor.Text.Equals(SbModificacion.ToString()))
            {
                var dialogoDeseaGuardar = MessageBox.Show(this, Mensaje, Titulo, MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
                switch (dialogoDeseaGuardar)
                {
                    case DialogResult.Yes:
                        GuardarArchivo();
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }
            var openDeGuindou = new OpenFileDialog();
            openDeGuindou.Filter = @"Prru (*.prru)|*.prru|Todos los archivos|*.*";
            openDeGuindou.InitialDirectory = CarpetaInicial;

            if (openDeGuindou.ShowDialog() == DialogResult.OK)
            {
                NombreArchivo = openDeGuindou.FileName;
                var sr = new StreamReader(NombreArchivo, Encoding.Default, true);
                cuadroEditor.Text = sr.ReadToEnd();
                sr.Close();
                SbModificacion.Clear();
                SbModificacion.Append(cuadroEditor.Text);
            }
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NombreArchivo == null)
            {
                var guardaLaGuindow = new SaveFileDialog();
                guardaLaGuindow.Filter = @"Prru (*.prru)|*.prru";
                guardaLaGuindow.InitialDirectory = CarpetaInicial;
                if (guardaLaGuindow.ShowDialog() == DialogResult.OK)
                    NombreArchivo = guardaLaGuindow.FileName;
            }
            else
            {
                var sw = new StreamWriter(NombreArchivo);
                sw.Write(cuadroEditor.Text);
                sw.Close();
                SbModificacion.Clear();
                SbModificacion.Append(cuadroEditor.Text);
            }
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarArchivo();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (NombreArchivo == null && !cuadroEditor.Text.Equals(string.Empty) ||
                !cuadroEditor.Text.Equals(SbModificacion.ToString()))
            {
                var dialogoDeseaGuardar = MessageBox.Show(this, Mensaje, Titulo, MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
                switch (dialogoDeseaGuardar)
                {
                    case DialogResult.Yes:
                        GuardarArchivo();
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }

            if (Application.MessageLoop)
                Application.Exit();
            else
                Environment.Exit(1);
        }

        private void cuadroEditor_UpdateUI(object sender, UpdateUIEventArgs e)
        {
            if ((e.Change & UpdateChange.Selection) > 0 || (e.Change & UpdateChange.Content) > 0)
            {
                SbLinea.Append(Linea).Append(cuadroEditor.CurrentLine + OffsetContador);
                SbColumna.Append(Columna).Append(cuadroEditor.GetColumn(cuadroEditor.CurrentPosition) + OffsetContador);

                labelLinea.Text = SbLinea.ToString();
                labelColumna.Text = SbColumna.ToString();

                SbLinea.Clear();
                SbColumna.Clear();
            }
        }
    }
}