namespace Chapter_7___Long_Exercise
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbxDescription = new System.Windows.Forms.TextBox();
            this.btnGoHere = new System.Windows.Forms.Button();
            this.cmbxExits = new System.Windows.Forms.ComboBox();
            this.btnThruDoor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbxDescription
            // 
            this.tbxDescription.Location = new System.Drawing.Point(3, 4);
            this.tbxDescription.Multiline = true;
            this.tbxDescription.Name = "tbxDescription";
            this.tbxDescription.Size = new System.Drawing.Size(384, 174);
            this.tbxDescription.TabIndex = 0;
            // 
            // btnGoHere
            // 
            this.btnGoHere.Location = new System.Drawing.Point(3, 185);
            this.btnGoHere.Name = "btnGoHere";
            this.btnGoHere.Size = new System.Drawing.Size(75, 23);
            this.btnGoHere.TabIndex = 1;
            this.btnGoHere.Text = "Go here:";
            this.btnGoHere.UseVisualStyleBackColor = true;
            this.btnGoHere.Click += new System.EventHandler(this.btnGoHere_Click);
            // 
            // cmbxExits
            // 
            this.cmbxExits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxExits.FormattingEnabled = true;
            this.cmbxExits.Location = new System.Drawing.Point(85, 185);
            this.cmbxExits.Name = "cmbxExits";
            this.cmbxExits.Size = new System.Drawing.Size(302, 21);
            this.cmbxExits.TabIndex = 2;
            // 
            // btnThruDoor
            // 
            this.btnThruDoor.Location = new System.Drawing.Point(3, 215);
            this.btnThruDoor.Name = "btnThruDoor";
            this.btnThruDoor.Size = new System.Drawing.Size(384, 23);
            this.btnThruDoor.TabIndex = 3;
            this.btnThruDoor.Text = "Go thru the door";
            this.btnThruDoor.UseVisualStyleBackColor = true;
            this.btnThruDoor.Visible = false;
            this.btnThruDoor.Click += new System.EventHandler(this.btnThruDoor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 262);
            this.Controls.Add(this.btnThruDoor);
            this.Controls.Add(this.cmbxExits);
            this.Controls.Add(this.btnGoHere);
            this.Controls.Add(this.tbxDescription);
            this.Name = "Form1";
            this.Text = "Explore the house";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbxDescription;
        private System.Windows.Forms.Button btnGoHere;
        private System.Windows.Forms.ComboBox cmbxExits;
        private System.Windows.Forms.Button btnThruDoor;
    }
}

