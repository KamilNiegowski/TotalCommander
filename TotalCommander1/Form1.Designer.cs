namespace TotalCommander1
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewLeft = new System.Windows.Forms.ListView();
            this.NameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TypeColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbleft = new System.Windows.Forms.TextBox();
            this.tbright = new System.Windows.Forms.TextBox();
            this.cbright = new System.Windows.Forms.ComboBox();
            this.listViewRight = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbleft = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonRight = new System.Windows.Forms.Button();
            this.buttonLeft = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listViewLeft
            // 
            this.listViewLeft.AllowDrop = true;
            this.listViewLeft.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameColumn,
            this.TypeColumn,
            this.DateColumn});
            this.listViewLeft.HideSelection = false;
            this.listViewLeft.Location = new System.Drawing.Point(12, 79);
            this.listViewLeft.Name = "listViewLeft";
            this.listViewLeft.Size = new System.Drawing.Size(431, 376);
            this.listViewLeft.TabIndex = 9;
            this.listViewLeft.UseCompatibleStateImageBehavior = false;
            this.listViewLeft.View = System.Windows.Forms.View.Details;
            this.listViewLeft.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listViewLeft_AfterLabelEdit);
            this.listViewLeft.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewLeft_ColumnClick);
            this.listViewLeft.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewLeft_ItemDrag);
            this.listViewLeft.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewLeft_DragDrop);           
            this.listViewLeft.DragOver += new System.Windows.Forms.DragEventHandler(this.listViewLeft_DragOver);
            this.listViewLeft.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewLeft_KeyUp);
            this.listViewLeft.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewLeft_MouseDoubleClick);
            // 
            // NameColumn
            // 
            this.NameColumn.Text = "Nazwa";
            this.NameColumn.Width = 200;
            // 
            // TypeColumn
            // 
            this.TypeColumn.Text = "Typ";
            // 
            // DateColumn
            // 
            this.DateColumn.Text = "Data utworzenia";
            this.DateColumn.Width = 150;
            // 
            // tbleft
            // 
            this.tbleft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbleft.Location = new System.Drawing.Point(12, 53);
            this.tbleft.Name = "tbleft";
            this.tbleft.Size = new System.Drawing.Size(370, 20);
            this.tbleft.TabIndex = 6;
            this.tbleft.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbleft_KeyPress);
            // 
            // tbright
            // 
            this.tbright.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbright.Location = new System.Drawing.Point(459, 53);
            this.tbright.Name = "tbright";
            this.tbright.Size = new System.Drawing.Size(370, 20);
            this.tbright.TabIndex = 7;
            this.tbright.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbright_KeyPress);
            // 
            // cbright
            // 
            this.cbright.FormattingEnabled = true;
            this.cbright.Location = new System.Drawing.Point(558, 8);
            this.cbright.Name = "cbright";
            this.cbright.Size = new System.Drawing.Size(53, 21);
            this.cbright.TabIndex = 4;
            this.cbright.SelectedIndexChanged += new System.EventHandler(this.cbright_SelectedIndexChanged);
            // 
            // listViewRight
            // 
            this.listViewRight.AllowDrop = true;
            this.listViewRight.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewRight.HideSelection = false;
            this.listViewRight.Location = new System.Drawing.Point(459, 79);
            this.listViewRight.Name = "listViewRight";
            this.listViewRight.Size = new System.Drawing.Size(432, 376);
            this.listViewRight.TabIndex = 5;
            this.listViewRight.UseCompatibleStateImageBehavior = false;
            this.listViewRight.View = System.Windows.Forms.View.Details;
            this.listViewRight.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listViewRight_AfterLabelEdit);
            this.listViewRight.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewRight_ColumnClick);
            this.listViewRight.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.listViewRight_ItemDrag);
            this.listViewRight.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewRight_DragDrop);           
            this.listViewRight.DragOver += new System.Windows.Forms.DragEventHandler(this.listViewRight_DragOver);
            this.listViewRight.KeyUp += new System.Windows.Forms.KeyEventHandler(this.listViewRight_KeyUp);
            this.listViewRight.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewRight_MouseDoubleClick);
           
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Nazwa";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Typ";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Data utworzenia";
            this.columnHeader3.Width = 150;
            // 
            // cbleft
            // 
            this.cbleft.FormattingEnabled = true;
            this.cbleft.Location = new System.Drawing.Point(114, 8);
            this.cbleft.Name = "cbleft";
            this.cbleft.Size = new System.Drawing.Size(53, 21);
            this.cbleft.TabIndex = 0;
            this.cbleft.SelectedIndexChanged += new System.EventHandler(this.cbleft_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 17);
            this.label1.TabIndex = 10;
            this.label1.Text = "Wybierz dysk:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(456, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Wybierz dysk:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(12, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Aktualna ścieżka:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(456, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Aktualna ścieżka:";
            // 
            // buttonRight
            // 
            this.buttonRight.Location = new System.Drawing.Point(835, 52);
            this.buttonRight.Name = "buttonRight";
            this.buttonRight.Size = new System.Drawing.Size(56, 21);
            this.buttonRight.TabIndex = 14;
            this.buttonRight.Text = "Back";
            this.buttonRight.UseVisualStyleBackColor = true;
            this.buttonRight.Click += new System.EventHandler(this.buttonRight_Click);
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(387, 52);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(56, 21);
            this.buttonLeft.TabIndex = 15;
            this.buttonLeft.Text = "Back";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 470);
            this.Controls.Add(this.buttonLeft);
            this.Controls.Add(this.buttonRight);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listViewRight);
            this.Controls.Add(this.cbright);
            this.Controls.Add(this.cbleft);
            this.Controls.Add(this.tbright);
            this.Controls.Add(this.tbleft);
            this.Controls.Add(this.listViewLeft);
            this.Name = "Form1";
            this.Text = "TotalCommander";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listViewLeft;
        private System.Windows.Forms.ColumnHeader NameColumn;
        private System.Windows.Forms.ColumnHeader DateColumn;
        private System.Windows.Forms.TextBox tbleft;
        private System.Windows.Forms.TextBox tbright;
        private System.Windows.Forms.ComboBox cbright;
        private System.Windows.Forms.ColumnHeader TypeColumn;
        private System.Windows.Forms.ListView listViewRight;
        private System.Windows.Forms.ComboBox cbleft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Button buttonRight;
        private System.Windows.Forms.Button buttonLeft;
    }
}

