namespace Speck
{
    partial class Speck
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Speck));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.cuadroEditor = new ScintillaNET.Scintilla();
            this.barraEstado = new System.Windows.Forms.StatusStrip();
            this.labelLinea = new System.Windows.Forms.ToolStripStatusLabel();
            this.labelColumna = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.archivoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarComoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deshacerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rehacerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cortarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copiarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pegarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.seleccionarTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.compilarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.léxicoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sintácticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.semánticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.compilarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.botonNuevo = new System.Windows.Forms.ToolStripButton();
            this.botonAbrir = new System.Windows.Forms.ToolStripButton();
            this.botonGuardar = new System.Windows.Forms.ToolStripButton();
            this.botonGuardarComo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.botonDeshacer = new System.Windows.Forms.ToolStripButton();
            this.botonRehacer = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.botonLexico = new System.Windows.Forms.ToolStripButton();
            this.botonSintactico = new System.Windows.Forms.ToolStripButton();
            this.botonSemantico = new System.Windows.Forms.ToolStripButton();
            this.botonCompilar = new System.Windows.Forms.ToolStripButton();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.barraEstado.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.cuadroEditor);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.barraEstado);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1285, 677);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1285, 756);
            this.toolStripContainer1.TabIndex = 3;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // cuadroEditor
            // 
            this.cuadroEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cuadroEditor.Lexer = ScintillaNET.Lexer.Cpp;
            this.cuadroEditor.Location = new System.Drawing.Point(0, 0);
            this.cuadroEditor.Name = "cuadroEditor";
            this.cuadroEditor.ScrollWidth = 1;
            this.cuadroEditor.Size = new System.Drawing.Size(1285, 655);
            this.cuadroEditor.TabIndex = 0;
            this.cuadroEditor.UpdateUI += new System.EventHandler<ScintillaNET.UpdateUIEventArgs>(this.cuadroEditor_UpdateUI);
            // 
            // barraEstado
            // 
            this.barraEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.barraEstado.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.barraEstado.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelLinea,
            this.labelColumna});
            this.barraEstado.Location = new System.Drawing.Point(0, 655);
            this.barraEstado.Name = "barraEstado";
            this.barraEstado.Size = new System.Drawing.Size(1285, 22);
            this.barraEstado.SizingGrip = false;
            this.barraEstado.TabIndex = 3;
            // 
            // labelLinea
            // 
            this.labelLinea.ForeColor = System.Drawing.Color.White;
            this.labelLinea.Name = "labelLinea";
            this.labelLinea.Size = new System.Drawing.Size(0, 17);
            // 
            // labelColumna
            // 
            this.labelColumna.ForeColor = System.Drawing.Color.White;
            this.labelColumna.Name = "labelColumna";
            this.labelColumna.Size = new System.Drawing.Size(0, 17);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.archivoToolStripMenuItem,
            this.editarToolStripMenuItem,
            this.compilarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip1.Size = new System.Drawing.Size(1285, 40);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // archivoToolStripMenuItem
            // 
            this.archivoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoToolStripMenuItem,
            this.abrirToolStripMenuItem,
            this.toolStripSeparator5,
            this.guardarToolStripMenuItem,
            this.guardarComoToolStripMenuItem,
            this.toolStripSeparator1,
            this.salirToolStripMenuItem});
            this.archivoToolStripMenuItem.Name = "archivoToolStripMenuItem";
            this.archivoToolStripMenuItem.Size = new System.Drawing.Size(107, 36);
            this.archivoToolStripMenuItem.Text = "Archivo";
            // 
            // nuevoToolStripMenuItem
            // 
            this.nuevoToolStripMenuItem.Name = "nuevoToolStripMenuItem";
            this.nuevoToolStripMenuItem.Size = new System.Drawing.Size(281, 38);
            this.nuevoToolStripMenuItem.Text = "Nuevo";
            this.nuevoToolStripMenuItem.Click += new System.EventHandler(this.nuevoToolStripMenuItem_Click);
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(281, 38);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(278, 6);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(281, 38);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // guardarComoToolStripMenuItem
            // 
            this.guardarComoToolStripMenuItem.Name = "guardarComoToolStripMenuItem";
            this.guardarComoToolStripMenuItem.Size = new System.Drawing.Size(281, 38);
            this.guardarComoToolStripMenuItem.Text = "Guardar como...";
            this.guardarComoToolStripMenuItem.Click += new System.EventHandler(this.guardarComoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(278, 6);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(281, 38);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // editarToolStripMenuItem
            // 
            this.editarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deshacerToolStripMenuItem,
            this.rehacerToolStripMenuItem,
            this.toolStripSeparator2,
            this.cortarToolStripMenuItem,
            this.copiarToolStripMenuItem,
            this.pegarToolStripMenuItem,
            this.toolStripSeparator3,
            this.seleccionarTodoToolStripMenuItem});
            this.editarToolStripMenuItem.Name = "editarToolStripMenuItem";
            this.editarToolStripMenuItem.Size = new System.Drawing.Size(87, 36);
            this.editarToolStripMenuItem.Text = "Editar";
            // 
            // deshacerToolStripMenuItem
            // 
            this.deshacerToolStripMenuItem.Name = "deshacerToolStripMenuItem";
            this.deshacerToolStripMenuItem.Size = new System.Drawing.Size(296, 38);
            this.deshacerToolStripMenuItem.Text = "Deshacer";
            // 
            // rehacerToolStripMenuItem
            // 
            this.rehacerToolStripMenuItem.Name = "rehacerToolStripMenuItem";
            this.rehacerToolStripMenuItem.Size = new System.Drawing.Size(296, 38);
            this.rehacerToolStripMenuItem.Text = "Rehacer";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(293, 6);
            // 
            // cortarToolStripMenuItem
            // 
            this.cortarToolStripMenuItem.Name = "cortarToolStripMenuItem";
            this.cortarToolStripMenuItem.Size = new System.Drawing.Size(296, 38);
            this.cortarToolStripMenuItem.Text = "Cortar";
            // 
            // copiarToolStripMenuItem
            // 
            this.copiarToolStripMenuItem.Name = "copiarToolStripMenuItem";
            this.copiarToolStripMenuItem.Size = new System.Drawing.Size(296, 38);
            this.copiarToolStripMenuItem.Text = "Copiar";
            // 
            // pegarToolStripMenuItem
            // 
            this.pegarToolStripMenuItem.Name = "pegarToolStripMenuItem";
            this.pegarToolStripMenuItem.Size = new System.Drawing.Size(296, 38);
            this.pegarToolStripMenuItem.Text = "Pegar";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(293, 6);
            // 
            // seleccionarTodoToolStripMenuItem
            // 
            this.seleccionarTodoToolStripMenuItem.Name = "seleccionarTodoToolStripMenuItem";
            this.seleccionarTodoToolStripMenuItem.Size = new System.Drawing.Size(296, 38);
            this.seleccionarTodoToolStripMenuItem.Text = "Seleccionar Todo";
            // 
            // compilarToolStripMenuItem
            // 
            this.compilarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.léxicoToolStripMenuItem,
            this.sintácticoToolStripMenuItem,
            this.semánticoToolStripMenuItem,
            this.toolStripSeparator4,
            this.compilarToolStripMenuItem1});
            this.compilarToolStripMenuItem.Name = "compilarToolStripMenuItem";
            this.compilarToolStripMenuItem.Size = new System.Drawing.Size(160, 36);
            this.compilarToolStripMenuItem.Text = "Compilación";
            // 
            // léxicoToolStripMenuItem
            // 
            this.léxicoToolStripMenuItem.Name = "léxicoToolStripMenuItem";
            this.léxicoToolStripMenuItem.Size = new System.Drawing.Size(269, 38);
            this.léxicoToolStripMenuItem.Text = "Léxico";
            // 
            // sintácticoToolStripMenuItem
            // 
            this.sintácticoToolStripMenuItem.Name = "sintácticoToolStripMenuItem";
            this.sintácticoToolStripMenuItem.Size = new System.Drawing.Size(269, 38);
            this.sintácticoToolStripMenuItem.Text = "Sintáctico";
            // 
            // semánticoToolStripMenuItem
            // 
            this.semánticoToolStripMenuItem.Name = "semánticoToolStripMenuItem";
            this.semánticoToolStripMenuItem.Size = new System.Drawing.Size(269, 38);
            this.semánticoToolStripMenuItem.Text = "Semántico";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(266, 6);
            // 
            // compilarToolStripMenuItem1
            // 
            this.compilarToolStripMenuItem1.Name = "compilarToolStripMenuItem1";
            this.compilarToolStripMenuItem1.Size = new System.Drawing.Size(269, 38);
            this.compilarToolStripMenuItem1.Text = "Compilar";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.botonNuevo,
            this.botonAbrir,
            this.botonGuardar,
            this.botonGuardarComo,
            this.toolStripSeparator6,
            this.botonDeshacer,
            this.botonRehacer,
            this.toolStripSeparator7,
            this.botonLexico,
            this.botonSintactico,
            this.botonSemantico,
            this.botonCompilar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 40);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(375, 39);
            this.toolStrip1.TabIndex = 3;
            // 
            // botonNuevo
            // 
            this.botonNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.botonNuevo.Image = ((System.Drawing.Image)(resources.GetObject("botonNuevo.Image")));
            this.botonNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonNuevo.Name = "botonNuevo";
            this.botonNuevo.Size = new System.Drawing.Size(36, 36);
            this.botonNuevo.Text = "botonNuevo";
            // 
            // botonAbrir
            // 
            this.botonAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.botonAbrir.Image = ((System.Drawing.Image)(resources.GetObject("botonAbrir.Image")));
            this.botonAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonAbrir.Name = "botonAbrir";
            this.botonAbrir.Size = new System.Drawing.Size(36, 36);
            this.botonAbrir.Text = "botonAbrir";
            // 
            // botonGuardar
            // 
            this.botonGuardar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.botonGuardar.Image = ((System.Drawing.Image)(resources.GetObject("botonGuardar.Image")));
            this.botonGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(36, 36);
            this.botonGuardar.Text = "botonGuardar";
            // 
            // botonGuardarComo
            // 
            this.botonGuardarComo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.botonGuardarComo.Image = ((System.Drawing.Image)(resources.GetObject("botonGuardarComo.Image")));
            this.botonGuardarComo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonGuardarComo.Name = "botonGuardarComo";
            this.botonGuardarComo.Size = new System.Drawing.Size(36, 36);
            this.botonGuardarComo.Text = "botonGuardarComo";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // botonDeshacer
            // 
            this.botonDeshacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.botonDeshacer.Image = ((System.Drawing.Image)(resources.GetObject("botonDeshacer.Image")));
            this.botonDeshacer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonDeshacer.Name = "botonDeshacer";
            this.botonDeshacer.Size = new System.Drawing.Size(36, 36);
            this.botonDeshacer.Text = "botonDeshacer";
            // 
            // botonRehacer
            // 
            this.botonRehacer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.botonRehacer.Image = ((System.Drawing.Image)(resources.GetObject("botonRehacer.Image")));
            this.botonRehacer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonRehacer.Name = "botonRehacer";
            this.botonRehacer.Size = new System.Drawing.Size(36, 36);
            this.botonRehacer.Text = "botonRehacer";
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 39);
            // 
            // botonLexico
            // 
            this.botonLexico.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.botonLexico.Image = ((System.Drawing.Image)(resources.GetObject("botonLexico.Image")));
            this.botonLexico.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonLexico.Name = "botonLexico";
            this.botonLexico.Size = new System.Drawing.Size(36, 36);
            this.botonLexico.Text = "botonLexico";
            // 
            // botonSintactico
            // 
            this.botonSintactico.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.botonSintactico.Image = ((System.Drawing.Image)(resources.GetObject("botonSintactico.Image")));
            this.botonSintactico.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonSintactico.Name = "botonSintactico";
            this.botonSintactico.Size = new System.Drawing.Size(36, 36);
            this.botonSintactico.Text = "botonSintactico";
            // 
            // botonSemantico
            // 
            this.botonSemantico.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.botonSemantico.Image = ((System.Drawing.Image)(resources.GetObject("botonSemantico.Image")));
            this.botonSemantico.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonSemantico.Name = "botonSemantico";
            this.botonSemantico.Size = new System.Drawing.Size(36, 36);
            this.botonSemantico.Text = "botonSemantico";
            // 
            // botonCompilar
            // 
            this.botonCompilar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.botonCompilar.Image = ((System.Drawing.Image)(resources.GetObject("botonCompilar.Image")));
            this.botonCompilar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.botonCompilar.Name = "botonCompilar";
            this.botonCompilar.Size = new System.Drawing.Size(36, 36);
            this.botonCompilar.Text = "botonCompilar";
            // 
            // Speck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1285, 756);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "Speck";
            this.Text = "Speck";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ContentPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.barraEstado.ResumeLayout(false);
            this.barraEstado.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.StatusStrip barraEstado;
        private System.Windows.Forms.ToolStripStatusLabel labelLinea;
        private System.Windows.Forms.ToolStripStatusLabel labelColumna;
        private ScintillaNET.Scintilla cuadroEditor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem archivoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarComoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deshacerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rehacerToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cortarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copiarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pegarToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem seleccionarTodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem compilarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem léxicoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sintácticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem semánticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem compilarToolStripMenuItem1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton botonNuevo;
        private System.Windows.Forms.ToolStripButton botonAbrir;
        private System.Windows.Forms.ToolStripButton botonGuardar;
        private System.Windows.Forms.ToolStripButton botonGuardarComo;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripButton botonDeshacer;
        private System.Windows.Forms.ToolStripButton botonRehacer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton botonLexico;
        private System.Windows.Forms.ToolStripButton botonSintactico;
        private System.Windows.Forms.ToolStripButton botonSemantico;
        private System.Windows.Forms.ToolStripButton botonCompilar;
    }
}

