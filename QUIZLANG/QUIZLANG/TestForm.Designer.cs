namespace QUIZLANG
{
    partial class TestForm
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
            this.grpbox_Require = new System.Windows.Forms.GroupBox();
            this.lbl_Information = new System.Windows.Forms.Label();
            this.lblTestingLan = new System.Windows.Forms.Label();
            this.cbTestingLan = new System.Windows.Forms.ComboBox();
            this.lblChooseQuiz = new System.Windows.Forms.Label();
            this.cbChooseQuiz = new System.Windows.Forms.ComboBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.grpbox_Require.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpbox_Require
            // 
            this.grpbox_Require.Controls.Add(this.lbl_Information);
            this.grpbox_Require.Location = new System.Drawing.Point(38, 253);
            this.grpbox_Require.Margin = new System.Windows.Forms.Padding(4);
            this.grpbox_Require.Name = "grpbox_Require";
            this.grpbox_Require.Padding = new System.Windows.Forms.Padding(4);
            this.grpbox_Require.Size = new System.Drawing.Size(711, 79);
            this.grpbox_Require.TabIndex = 8;
            this.grpbox_Require.TabStop = false;
            this.grpbox_Require.Text = "Testing Requirements";
            // 
            // lbl_Information
            // 
            this.lbl_Information.AutoSize = true;
            this.lbl_Information.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbl_Information.Location = new System.Drawing.Point(29, 28);
            this.lbl_Information.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Information.Name = "lbl_Information";
            this.lbl_Information.Size = new System.Drawing.Size(569, 40);
            this.lbl_Information.TabIndex = 0;
            this.lbl_Information.Text = "1. All the questions are single choice or text fill in !\r\n2. There are totally fi" +
    "ve questions in one testing !";
            // 
            // lblTestingLan
            // 
            this.lblTestingLan.AutoSize = true;
            this.lblTestingLan.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTestingLan.Location = new System.Drawing.Point(34, 175);
            this.lblTestingLan.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTestingLan.Name = "lblTestingLan";
            this.lblTestingLan.Size = new System.Drawing.Size(105, 19);
            this.lblTestingLan.TabIndex = 7;
            this.lblTestingLan.Text = "Test language:";
            // 
            // cbTestingLan
            // 
            this.cbTestingLan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTestingLan.FormattingEnabled = true;
            this.cbTestingLan.Location = new System.Drawing.Point(181, 173);
            this.cbTestingLan.Margin = new System.Windows.Forms.Padding(4);
            this.cbTestingLan.Name = "cbTestingLan";
            this.cbTestingLan.Size = new System.Drawing.Size(136, 23);
            this.cbTestingLan.TabIndex = 6;
            // 
            // lblChooseQuiz
            // 
            this.lblChooseQuiz.AutoSize = true;
            this.lblChooseQuiz.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblChooseQuiz.Location = new System.Drawing.Point(362, 175);
            this.lblChooseQuiz.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblChooseQuiz.Name = "lblChooseQuiz";
            this.lblChooseQuiz.Size = new System.Drawing.Size(97, 19);
            this.lblChooseQuiz.TabIndex = 11;
            this.lblChooseQuiz.Text = "Choose Quiz";
            // 
            // cbChooseQuiz
            // 
            this.cbChooseQuiz.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChooseQuiz.FormattingEnabled = true;
            this.cbChooseQuiz.Location = new System.Drawing.Point(472, 170);
            this.cbChooseQuiz.Margin = new System.Windows.Forms.Padding(4);
            this.cbChooseQuiz.Name = "cbChooseQuiz";
            this.cbChooseQuiz.Size = new System.Drawing.Size(136, 23);
            this.cbChooseQuiz.TabIndex = 10;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(181, 349);
            this.btn_start.Margin = new System.Windows.Forms.Padding(4);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(136, 45);
            this.btn_start.TabIndex = 9;
            this.btn_start.Text = "Start Test";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 553);
            this.Controls.Add(this.grpbox_Require);
            this.Controls.Add(this.lblTestingLan);
            this.Controls.Add(this.cbTestingLan);
            this.Controls.Add(this.lblChooseQuiz);
            this.Controls.Add(this.cbChooseQuiz);
            this.Controls.Add(this.btn_start);
            this.Name = "TestForm";
            this.Text = "TestForm";
            this.Load += new System.EventHandler(this.TestForm_Load);
            this.grpbox_Require.ResumeLayout(false);
            this.grpbox_Require.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grpbox_Require;
        private System.Windows.Forms.Label lbl_Information;
        private System.Windows.Forms.Label lblTestingLan;
        private System.Windows.Forms.ComboBox cbTestingLan;
        private System.Windows.Forms.Label lblChooseQuiz;
        private System.Windows.Forms.ComboBox cbChooseQuiz;
        private System.Windows.Forms.Button btn_start;
    }
}