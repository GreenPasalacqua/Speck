using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ScintillaNET;

namespace Speck
{
    public partial class Speck : Form
    {
        internal string RutaArchivo = string.Empty;

        internal string CarpetaInicial = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
        internal string RutaAnalizadorLexico = Path.Combine(Directory.GetCurrentDirectory(), @"lexico.py");

        internal const string Separador = @" - ";
        internal const string CaracterNoGuardado = @"*";

        internal const string Mensaje = @"No has guardado tu archivo. ¿Desea guardarlo?";
        internal const string Titulo = @"No soy adivino ¬¬";

        internal const string TituloLexico = @"¡Está en blanco! ¡Mi compilador!";
        internal const string MensajeLexico = @"¡Debes hacer algo para que yo pueda hacer algo!";

        internal const string Python = @"C:\Python27\python.exe";
        internal const string DirectorioLexico = @"Lexico";
        internal const string ArchivoLexico = @"lexemas.txt";
        internal const string ArchivoErroresLexico = @"errores_lexicos.txt";

        internal StringBuilder SbTitulo = new StringBuilder();

        internal const int OffsetContador = 1;
        internal const string Linea = @"Ln ";
        internal const string Columna = @"Col ";
        internal StringBuilder SbLinea = new StringBuilder();
        internal StringBuilder SbColumna = new StringBuilder();

        internal int LongitudMaximaNumeroLinea;
        internal const int PaddingNumeroLinea = 2;

        public Speck()
        {
            InitializeComponent();

            //Full screen, como para juegos
            /*WindowState = FormWindowState.Maximized;
            FormBorderStyle = FormBorderStyle.None;*/

            StartPosition = FormStartPosition.Manual;
            Location = new Point(0, 0);
            Size = Screen.PrimaryScreen.WorkingArea.Size;

            textboxLexicoChido.ReadOnly = true;
            textboxErrorLexico.ReadOnly = true;

            cuadroEditor.StyleResetDefault();
            cuadroEditor.Styles[Style.Default].Font = "Meslo LG S Regular";
            cuadroEditor.Styles[Style.Default].Size = 10;
            cuadroEditor.SetSelectionBackColor(true, Color.DodgerBlue);
            cuadroEditor.SetSelectionForeColor(true, Color.White);
            cuadroEditor.StyleClearAll();

            cuadroEditor.Margins[0].Width = 16;
            cuadroEditor.Styles[Style.LineNumber].Font = "HelveticaNeue Light";
            cuadroEditor.Styles[Style.LineNumber].ForeColor = Color.White;
            cuadroEditor.Styles[Style.LineNumber].BackColor = Color.FromArgb(0, 88, 191, 255);
            cuadroEditor.Margins[0].Type = MarginType.Number;
        }

        private void Speck_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cuadroEditor.Modified)
            {
                var dialogoDeseaGuardar = MessageBox.Show(this, Mensaje, Titulo, MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);
                switch (dialogoDeseaGuardar)
                {
                    case DialogResult.Yes:
                        GuardarArchivo();
                        break;
                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
        }

        public void NuevoArchivo()
        {
            if (cuadroEditor.Modified)
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
            RutaArchivo = string.Empty;
            cuadroEditor.Text = string.Empty;
            cuadroEditor.SetSavePoint();
            SbTitulo.Clear();
            SbTitulo.Append(Name);
            Text = SbTitulo.ToString();
            cuadroEditor.EmptyUndoBuffer();
            textboxLexicoChido.Text = string.Empty;
            textboxErrorLexico.Text = string.Empty;
        }

        public void AbrirArchivo()
        {
            if (cuadroEditor.Modified)
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

            var openDeGuindou = new OpenFileDialog
            {
                Filter = @"Prru (*.prru)|*.prru|Todos los archivos|*.*",
                InitialDirectory = CarpetaInicial
            };
            if (openDeGuindou.ShowDialog() == DialogResult.OK)
            {
                RutaArchivo = openDeGuindou.FileName;
                using (var sr = new StreamReader(RutaArchivo, Encoding.Default, true))
                {
                    cuadroEditor.Text = sr.ReadToEnd();
                }
                cuadroEditor.SetSavePoint();
                SbTitulo.Clear();
                SbTitulo.Append(Name).Append(Separador).Append(Path.GetFileNameWithoutExtension(RutaArchivo));
                Text = SbTitulo.ToString();
            }
            cuadroEditor.EmptyUndoBuffer();
        }

        public void GuardarArchivo()
        {
            if (RutaArchivo.Equals(string.Empty))
            {
                GuardarArchivoComo();
            }
            else
            {
                using (var sw = new StreamWriter(RutaArchivo))
                {
                    sw.Write(cuadroEditor.Text);
                }
                cuadroEditor.SetSavePoint();
            }
        }

        public void GuardarArchivoComo()
        {
            var guardaLaGuindow = new SaveFileDialog
            {
                Filter = @"Prru (*.prru)|*.prru",
                InitialDirectory = CarpetaInicial
            };
            if (guardaLaGuindow.ShowDialog() == DialogResult.OK)
                RutaArchivo = guardaLaGuindow.FileName;

            if (!RutaArchivo.Equals(string.Empty))
            {
                using (var sw = new StreamWriter(RutaArchivo))
                {
                    sw.Write(cuadroEditor.Text);
                }
                cuadroEditor.SetSavePoint();
                SbTitulo.Clear();
                SbTitulo.Append(Name).Append(Separador).Append(Path.GetFileNameWithoutExtension(RutaArchivo));
                Text = SbTitulo.ToString();
            }
            cuadroEditor.EmptyUndoBuffer();
        }

        public void Salir()
        {
            if (Application.MessageLoop)
                Application.Exit();
            else
                Environment.Exit(1);
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NuevoArchivo();
        }

        private void botonNuevo_Click(object sender, EventArgs e)
        {
            NuevoArchivo();
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirArchivo();
        }

        private void botonAbrir_Click(object sender, EventArgs e)
        {
            AbrirArchivo();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarArchivo();
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            GuardarArchivo();
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarArchivoComo();
        }

        private void botonGuardarComo_Click(object sender, EventArgs e)
        {
            GuardarArchivoComo();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salir();
        }

        public void Deshacer()
        {
            cuadroEditor.Undo();
        }

        public void Rehacer()
        {
            cuadroEditor.Redo();
        }

        public void Cortar()
        {
            cuadroEditor.Cut();
        }

        public void Copiar()
        {
            cuadroEditor.Copy();
        }

        public void Pegar()
        {
            cuadroEditor.Paste();
        }

        public void SeleccionarTodo()
        {
            cuadroEditor.SelectAll();
        }

        private void deshacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Deshacer();
        }

        private void botonDeshacer_Click(object sender, EventArgs e)
        {
            Deshacer();
        }

        private void rehacerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rehacer();
        }

        private void botonRehacer_Click(object sender, EventArgs e)
        {
            Rehacer();
        }

        private void cortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cortar();
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Copiar();
        }

        private void pegarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Pegar();
        }

        private void seleccionarTodoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SeleccionarTodo();
        }

        public void ComandoPython(string argumentos)
        {
            using (Process proceso = new Process())
            {
                proceso.StartInfo = new ProcessStartInfo(Python, argumentos)
                {
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                proceso.Start();
                string salida = proceso.StandardOutput.ReadToEnd();
                proceso.WaitForExit();
                Console.WriteLine(salida);
                Console.ReadLine();
            }
        }

        public void Lexico()
        {
            GuardarArchivo();
            if (!RutaArchivo.Equals(string.Empty))
            {
                ComandoPython(RutaAnalizadorLexico + " " + RutaArchivo);
                var rutaLexico = Path.Combine(Directory.GetCurrentDirectory(), DirectorioLexico, ArchivoLexico);
                var rutaErrorLexico = Path.Combine(Directory.GetCurrentDirectory(), DirectorioLexico,
                    ArchivoErroresLexico);
                textboxLexicoChido.Text = File.ReadAllText(rutaLexico);
                textboxErrorLexico.Text = File.ReadAllText(rutaErrorLexico);
            }
        }

        private void léxicoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Lexico();
        }

        private void botonLexico_Click(object sender, EventArgs e)
        {
            Lexico();
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

            deshacerToolStripMenuItem.Enabled = cuadroEditor.CanUndo;
            botonDeshacer.Enabled = cuadroEditor.CanUndo;
            rehacerToolStripMenuItem.Enabled = cuadroEditor.CanRedo;
            botonRehacer.Enabled = cuadroEditor.CanRedo;
            cortarToolStripMenuItem.Enabled = !cuadroEditor.SelectedText.Equals(string.Empty);
            copiarToolStripMenuItem.Enabled = !cuadroEditor.SelectedText.Equals(string.Empty);
            pegarToolStripMenuItem.Enabled = Clipboard.ContainsData(DataFormats.Text) && cuadroEditor.CanPaste;
        }

        private void cuadroEditor_TextChanged(object sender, EventArgs e)
        {
            var longitudMaximaNumeroLinea = cuadroEditor.Lines.Count.ToString().Length;
            if (longitudMaximaNumeroLinea == LongitudMaximaNumeroLinea)
                return;

            cuadroEditor.Margins[0].Width =
                cuadroEditor.TextWidth(Style.LineNumber, new string('9', longitudMaximaNumeroLinea + 1)) +
                PaddingNumeroLinea;
            LongitudMaximaNumeroLinea = longitudMaximaNumeroLinea;
        }

        private void cuadroEditor_SavePointLeft(object sender, EventArgs e)
        {
            SbTitulo.Clear();
            SbTitulo.Append(Text).Append(CaracterNoGuardado);
            Text = SbTitulo.ToString();
            barraEstado.BackColor = Color.FromArgb(barraEstado.BackColor.ToArgb() ^ 0xffffff);
        }

        private void cuadroEditor_SavePointReached(object sender, EventArgs e)
        {
            if (SbTitulo.ToString().Contains(CaracterNoGuardado))
            {
                SbTitulo.Length--;
                Text = SbTitulo.ToString();
                barraEstado.BackColor = Color.FromArgb(barraEstado.BackColor.ToArgb() ^ 0xffffff);
            }
        }
    }
}