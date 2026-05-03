namespace Calendar
{
    partial class GroupMeetingsList
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
            this.dgvGroupMeetings = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnDetail = new System.Windows.Forms.Button();
            this.lblHint = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupMeetings)).BeginInit();
            this.SuspendLayout();

            // label1 - tiêu đề
            this.label1.BackColor = System.Drawing.SystemColors.Info;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(776, 74);
            this.label1.Text = "My Group Meetings";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            // lblHint
            this.lblHint.AutoSize = true;
            this.lblHint.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHint.Location = new System.Drawing.Point(12, 90);
            this.lblHint.Text = "Double-click vào dòng để xem chi tiết người tham gia";

            // dgvGroupMeetings
            this.dgvGroupMeetings.Location = new System.Drawing.Point(12, 110);
            this.dgvGroupMeetings.Name = "dgvGroupMeetings";
            this.dgvGroupMeetings.Size = new System.Drawing.Size(776, 290);
            this.dgvGroupMeetings.AllowUserToAddRows = false;
            this.dgvGroupMeetings.AllowUserToDeleteRows = false;
            this.dgvGroupMeetings.TabIndex = 0;

            // btnDetail
            this.btnDetail.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetail.Location = new System.Drawing.Point(12, 415);
            this.btnDetail.Name = "btnDetail";
            this.btnDetail.Size = new System.Drawing.Size(150, 35);
            this.btnDetail.Text = "Xem chi tiết";
            this.btnDetail.UseVisualStyleBackColor = true;
            this.btnDetail.Click += new System.EventHandler(this.btnDetail_Click);

            // GroupMeetingsList
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 465);
            this.Controls.Add(this.btnDetail);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.dgvGroupMeetings);
            this.Controls.Add(this.label1);
            this.Name = "GroupMeetingsList";
            this.Text = "Group Meetings";
            this.Load += new System.EventHandler(this.GroupMeetingsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvGroupMeetings)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvGroupMeetings;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDetail;
        private System.Windows.Forms.Label lblHint;
    }
}