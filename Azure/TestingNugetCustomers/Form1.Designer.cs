namespace TestingNugetCustomers
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
            lblCustomersNuget = new Label();
            button1 = new Button();
            lstCustomers = new ListBox();
            btnReadCars = new Button();
            btnLeerAeropuertos = new Button();
            SuspendLayout();
            // 
            // lblCustomersNuget
            // 
            lblCustomersNuget.AutoSize = true;
            lblCustomersNuget.Font = new Font("Segoe UI", 15F);
            lblCustomersNuget.Location = new Point(278, 52);
            lblCustomersNuget.Margin = new Padding(5, 0, 5, 0);
            lblCustomersNuget.Name = "lblCustomersNuget";
            lblCustomersNuget.Size = new Size(209, 35);
            lblCustomersNuget.TabIndex = 0;
            lblCustomersNuget.Text = "Customers Nuget";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 15F);
            button1.Location = new Point(50, 120);
            button1.Margin = new Padding(5);
            button1.Name = "button1";
            button1.Size = new Size(165, 88);
            button1.TabIndex = 1;
            button1.Text = "Read Customers";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lstCustomers
            // 
            lstCustomers.FormattingEnabled = true;
            lstCustomers.Location = new Point(278, 120);
            lstCustomers.Name = "lstCustomers";
            lstCustomers.Size = new Size(358, 319);
            lstCustomers.TabIndex = 2;
            // 
            // btnReadCars
            // 
            btnReadCars.Location = new Point(50, 254);
            btnReadCars.Name = "btnReadCars";
            btnReadCars.Size = new Size(165, 77);
            btnReadCars.TabIndex = 3;
            btnReadCars.Text = "Read cars";
            btnReadCars.UseVisualStyleBackColor = true;
            btnReadCars.Click += btnReadCars_Click;
            // 
            // btnLeerAeropuertos
            // 
            btnLeerAeropuertos.Location = new Point(50, 368);
            btnLeerAeropuertos.Name = "btnLeerAeropuertos";
            btnLeerAeropuertos.Size = new Size(180, 81);
            btnLeerAeropuertos.TabIndex = 4;
            btnLeerAeropuertos.Text = "Leer aeropuertos";
            btnLeerAeropuertos.UseVisualStyleBackColor = true;
            btnLeerAeropuertos.Click += btnLeerAeropuertos_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 788);
            Controls.Add(btnLeerAeropuertos);
            Controls.Add(btnReadCars);
            Controls.Add(lstCustomers);
            Controls.Add(button1);
            Controls.Add(lblCustomersNuget);
            Font = new Font("Segoe UI", 15F);
            Margin = new Padding(5);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCustomersNuget;
        private Button button1;
        private ListBox lstCustomers;
        private Button btnReadCars;
        private Button btnLeerAeropuertos;
    }
}
