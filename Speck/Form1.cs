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
        internal string RutaArchivo = string.Empty;

        internal string CarpetaInicial = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);

        internal const string Separador = @" - ";
        internal const string CaracterNoGuardado = @"*";

        internal const string Mensaje = @"No has guardado tu archivo. ¿Desea guardarlo?";
        internal const string Titulo = @"No soy adivino ¬¬";
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
            Text = Name;
            cuadroEditor.EmptyUndoBuffer();
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
                Text = Name + Separador + Path.GetFileNameWithoutExtension(RutaArchivo);
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
                Text = Name + Separador + Path.GetFileNameWithoutExtension(RutaArchivo);
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

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirArchivo();
        }

        private void guardarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarArchivo();
        }

        private void guardarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GuardarArchivoComo();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deshacerToolStripMenuItem.Enabled = cuadroEditor.CanUndo;
            rehacerToolStripMenuItem.Enabled = cuadroEditor.CanRedo;
            cortarToolStripMenuItem.Enabled = !cuadroEditor.SelectedText.Equals(string.Empty);
            copiarToolStripMenuItem.Enabled = !cuadroEditor.SelectedText.Equals(string.Empty);
            pegarToolStripMenuItem.Enabled = Clipboard.ContainsData(DataFormats.Text) && cuadroEditor.CanPaste;
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

        private void rehacerToolStripMenuItem_Click(object sender, EventArgs e)
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
            barraEstado.BackColor = Color.FromArgb(barraEstado.BackColor.ToArgb() ^ 0xffffff);
            Text = Text.Insert(Text.Length, CaracterNoGuardado);
        }

        private void cuadroEditor_SavePointReached(object sender, EventArgs e)
        {
            barraEstado.BackColor = Color.FromArgb(barraEstado.BackColor.ToArgb() ^ 0xffffff);
            Text = Text.Remove(Text.Length - 1);
        }
    }
}