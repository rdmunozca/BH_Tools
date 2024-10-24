namespace GetObjDB
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblSource = new Label();
            ldlTarget = new Label();
            tbxSource = new TextBox();
            tbxTarget = new TextBox();
            button1 = new Button();
            btnExecuteScript = new Button();
            lblListSource = new Label();
            tbxListSource = new TextBox();
            lblschemaDb = new Label();
            cbxSchemaDb = new ComboBox();
            SuspendLayout();
            // 
            // lblSource
            // 
            lblSource.AutoSize = true;
            lblSource.Location = new Point(18, 196);
            lblSource.Name = "lblSource";
            lblSource.Size = new Size(46, 15);
            lblSource.TabIndex = 0;
            lblSource.Text = "Fuente:";
            // 
            // ldlTarget
            // 
            ldlTarget.AutoSize = true;
            ldlTarget.Location = new Point(18, 241);
            ldlTarget.Name = "ldlTarget";
            ldlTarget.Size = new Size(50, 15);
            ldlTarget.TabIndex = 1;
            ldlTarget.Text = "Destino:";
            // 
            // tbxSource
            // 
            tbxSource.Location = new Point(115, 193);
            tbxSource.Name = "tbxSource";
            tbxSource.Size = new Size(385, 23);
            tbxSource.TabIndex = 2;
            // 
            // tbxTarget
            // 
            tbxTarget.Location = new Point(115, 234);
            tbxTarget.Name = "tbxTarget";
            tbxTarget.Size = new Size(385, 23);
            tbxTarget.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(506, 193);
            button1.Name = "button1";
            button1.Size = new Size(85, 23);
            button1.TabIndex = 4;
            button1.Text = "Obtener";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // btnExecuteScript
            // 
            btnExecuteScript.Enabled = false;
            btnExecuteScript.Location = new Point(506, 234);
            btnExecuteScript.Name = "btnExecuteScript";
            btnExecuteScript.Size = new Size(85, 23);
            btnExecuteScript.TabIndex = 5;
            btnExecuteScript.Text = "Ejecutar";
            btnExecuteScript.UseVisualStyleBackColor = true;
            btnExecuteScript.Click += button2_Click;
            // 
            // lblListSource
            // 
            lblListSource.AutoSize = true;
            lblListSource.Location = new Point(18, 105);
            lblListSource.Name = "lblListSource";
            lblListSource.Size = new Size(91, 15);
            lblListSource.TabIndex = 6;
            lblListSource.Text = "Lista de Objetos";
            // 
            // tbxListSource
            // 
            tbxListSource.Enabled = false;
            tbxListSource.Location = new Point(115, 102);
            tbxListSource.Name = "tbxListSource";
            tbxListSource.Size = new Size(228, 23);
            tbxListSource.TabIndex = 7;
            tbxListSource.Text = "D:\\Versiones\\BD_Objects\\ListFiles.txt";
            // 
            // lblschemaDb
            // 
            lblschemaDb.AutoSize = true;
            lblschemaDb.ImageAlign = ContentAlignment.TopCenter;
            lblschemaDb.Location = new Point(18, 152);
            lblschemaDb.Name = "lblschemaDb";
            lblschemaDb.Size = new Size(82, 15);
            lblschemaDb.TabIndex = 8;
            lblschemaDb.Text = "Base de datos:";
            // 
            // cbxSchemaDb
            // 
            cbxSchemaDb.FormattingEnabled = true;
            cbxSchemaDb.Items.AddRange(new object[] { "Seleccione...", "BeyondHealth_Changes", "BHColpQA_Application", "BHColpUAT_Application", "BHColpPROD_Application", "BHColpSMT_Application", "BHColpTST_Application", "BHColpCCPA_Application", "BeyondHealth_VCAP" });
            cbxSchemaDb.Location = new Point(115, 149);
            cbxSchemaDb.Name = "cbxSchemaDb";
            cbxSchemaDb.Size = new Size(228, 23);
            cbxSchemaDb.TabIndex = 9;
            cbxSchemaDb.SelectedIndexChanged += cbxSchemaDb_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(667, 342);
            Controls.Add(cbxSchemaDb);
            Controls.Add(lblschemaDb);
            Controls.Add(tbxListSource);
            Controls.Add(lblListSource);
            Controls.Add(btnExecuteScript);
            Controls.Add(button1);
            Controls.Add(tbxTarget);
            Controls.Add(tbxSource);
            Controls.Add(ldlTarget);
            Controls.Add(lblSource);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSource;
        private Label ldlTarget;
        private TextBox tbxSource;
        private TextBox tbxTarget;
        private Button button1;
        private Button btnExecuteScript;
        private Label lblListSource;
        private TextBox tbxListSource;
        private Label lblschemaDb;
        private ComboBox cbxSchemaDb;
    }
}
