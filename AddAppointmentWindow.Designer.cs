namespace Calendar
{
    partial class AddAppointmentWindow
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.AppNameText = new System.Windows.Forms.TextBox();
            this.AppLocationText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.StartTime = new System.Windows.Forms.DateTimePicker();
            this.EndTime = new System.Windows.Forms.DateTimePicker();
            this.AddAppbut = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // AppNameText
            this.AppNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppNameText.Location = new System.Drawing.Point(192, 144);
            this.AppNameText.Name = "AppNameText";
            this.AppNameText.Size = new System.Drawing.Size(360, 22);
            this.AppNameText.TabIndex = 0;

            // AppLocationText
            this.AppLocationText.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AppLocationText.Location = new System.Drawing.Point(192, 214);
            this.AppLocationText.Name = "AppLocationText";
            this.AppLocationText.Size = new System.Drawing.Size(360, 22);
            this.AppLocationText.TabIndex = 1;

            // label1 - tiêu đề
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(776, 93);
            this.label1.TabIndex = 4;
            this.label1.Text = "Add Appointment";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // label2 - Name
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(55, 147);
            this.label2.Name = "label2";
            this.label2.TabIndex = 5;
            this.label2.Text = "Name";

            // label3 - Location
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 214);
            this.label3.Name = "label3";
            this.label3.TabIndex = 6;
            this.label3.Text = "Location";

            // label4 - Start time
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(55, 295);
            this.label4.Name = "label4";
            this.label4.TabIndex = 7;
            this.label4.Text = "Start time";

            // label5 - End time
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(55, 386);
            this.label5.Name = "label5";
            this.label5.TabIndex = 8;
            this.label5.Text = "End time";

            // StartTime
            this.StartTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.StartTime.Location = new System.Drawing.Point(192, 295);
            this.StartTime.Name = "StartTime";
            this.StartTime.Size = new System.Drawing.Size(200, 22);
            this.StartTime.TabIndex = 9;

            // EndTime
            this.EndTime.CustomFormat = "dd/MM/yyyy HH:mm";
            this.EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.EndTime.Location = new System.Drawing.Point(192, 379);
            this.EndTime.Name = "EndTime";
            this.EndTime.Size = new System.Drawing.Size(200, 22);
            this.EndTime.TabIndex = 10;

            // AddAppbut
            this.AddAppbut.Location = new System.Drawing.Point(531, 383);
            this.AddAppbut.Name = "AddAppbut";
            this.AddAppbut.Size = new System.Drawing.Size(97, 35);
            this.AddAppbut.TabIndex = 11;
            this.AddAppbut.Text = "Add";
            this.AddAppbut.UseVisualStyleBackColor = true;
            this.AddAppbut.Click += new System.EventHandler(this.AddAppbut_Click);

            // button2 - Exit
            this.button2.Location = new System.Drawing.Point(662, 384);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(97, 34);
            this.button2.TabIndex = 12;
            this.button2.Text = "Exit";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);

            // AddAppointmentWindow
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.AddAppbut);
            this.Controls.Add(this.EndTime);
            this.Controls.Add(this.StartTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AppLocationText);
            this.Controls.Add(this.AppNameText);
            this.Name = "AddAppointmentWindow";
            this.Text = "AddAppointmentWindow";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox AppNameText;
        private System.Windows.Forms.TextBox AppLocationText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker StartTime;
        private System.Windows.Forms.DateTimePicker EndTime;
        private System.Windows.Forms.Button AddAppbut;
        private System.Windows.Forms.Button button2;
    }
}