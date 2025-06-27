namespace ChatBotPoePart3Gui
{
    partial class Form1
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.ChatBotTab = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.ReminderUpDown = new System.Windows.Forms.NumericUpDown();
            this.reminderBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UserInputText = new System.Windows.Forms.TextBox();
            this.ChatResponse = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.QuizTab = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Option1 = new System.Windows.Forms.Label();
            this.rbtn4 = new System.Windows.Forms.RadioButton();
            this.rbtn3 = new System.Windows.Forms.RadioButton();
            this.rbtn2 = new System.Windows.Forms.RadioButton();
            this.rbtn1 = new System.Windows.Forms.RadioButton();
            this.ReminderListTab = new System.Windows.Forms.TabPage();
            this.DeleteBtn = new System.Windows.Forms.Button();
            this.ReminderDataGrid = new System.Windows.Forms.DataGridView();
            this.LogTab = new System.Windows.Forms.TabPage();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.QuestionNum = new System.Windows.Forms.Label();
            this.ScoreLabel = new System.Windows.Forms.Label();
            this.txtboxAnswer = new System.Windows.Forms.TextBox();
            this.btnEnterQuiz = new System.Windows.Forms.Button();
            this.nextbtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtbLog = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.ChatBotTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReminderUpDown)).BeginInit();
            this.QuizTab.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ReminderListTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReminderDataGrid)).BeginInit();
            this.LogTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.ChatBotTab);
            this.tabControl1.Controls.Add(this.QuizTab);
            this.tabControl1.Controls.Add(this.ReminderListTab);
            this.tabControl1.Controls.Add(this.LogTab);
            this.tabControl1.Location = new System.Drawing.Point(-1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1760, 941);
            this.tabControl1.TabIndex = 0;
            // 
            // ChatBotTab
            // 
            this.ChatBotTab.Controls.Add(this.label3);
            this.ChatBotTab.Controls.Add(this.ReminderUpDown);
            this.ChatBotTab.Controls.Add(this.reminderBtn);
            this.ChatBotTab.Controls.Add(this.label2);
            this.ChatBotTab.Controls.Add(this.label1);
            this.ChatBotTab.Controls.Add(this.UserInputText);
            this.ChatBotTab.Controls.Add(this.ChatResponse);
            this.ChatBotTab.Controls.Add(this.btnSend);
            this.ChatBotTab.Location = new System.Drawing.Point(8, 39);
            this.ChatBotTab.Name = "ChatBotTab";
            this.ChatBotTab.Padding = new System.Windows.Forms.Padding(3);
            this.ChatBotTab.Size = new System.Drawing.Size(1744, 894);
            this.ChatBotTab.TabIndex = 0;
            this.ChatBotTab.Text = "ChatBot";
            this.ChatBotTab.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1106, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(237, 25);
            this.label3.TabIndex = 8;
            this.label3.Text = "Reminder value in days";
            // 
            // ReminderUpDown
            // 
            this.ReminderUpDown.Location = new System.Drawing.Point(1111, 454);
            this.ReminderUpDown.Name = "ReminderUpDown";
            this.ReminderUpDown.Size = new System.Drawing.Size(339, 31);
            this.ReminderUpDown.TabIndex = 7;
            // 
            // reminderBtn
            // 
            this.reminderBtn.Location = new System.Drawing.Point(1111, 511);
            this.reminderBtn.Name = "reminderBtn";
            this.reminderBtn.Size = new System.Drawing.Size(270, 44);
            this.reminderBtn.TabIndex = 6;
            this.reminderBtn.Text = "Reminder Enter";
            this.reminderBtn.UseVisualStyleBackColor = true;
            this.reminderBtn.Click += new System.EventHandler(this.reminderBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Chat Bot Response :";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 378);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "User Input :";
            // 
            // UserInputText
            // 
            this.UserInputText.Location = new System.Drawing.Point(8, 417);
            this.UserInputText.Multiline = true;
            this.UserInputText.Name = "UserInputText";
            this.UserInputText.Size = new System.Drawing.Size(969, 230);
            this.UserInputText.TabIndex = 2;
            this.UserInputText.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // ChatResponse
            // 
            this.ChatResponse.Location = new System.Drawing.Point(11, 68);
            this.ChatResponse.Multiline = true;
            this.ChatResponse.Name = "ChatResponse";
            this.ChatResponse.ReadOnly = true;
            this.ChatResponse.Size = new System.Drawing.Size(1727, 299);
            this.ChatResponse.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(8, 718);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(262, 73);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "Enter";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.button1_Click);
            // 
            // QuizTab
            // 
            this.QuizTab.Controls.Add(this.label6);
            this.QuizTab.Controls.Add(this.nextbtn);
            this.QuizTab.Controls.Add(this.btnEnterQuiz);
            this.QuizTab.Controls.Add(this.txtboxAnswer);
            this.QuizTab.Controls.Add(this.ScoreLabel);
            this.QuizTab.Controls.Add(this.QuestionNum);
            this.QuizTab.Controls.Add(this.groupBox1);
            this.QuizTab.Location = new System.Drawing.Point(8, 39);
            this.QuizTab.Name = "QuizTab";
            this.QuizTab.Padding = new System.Windows.Forms.Padding(3);
            this.QuizTab.Size = new System.Drawing.Size(1744, 894);
            this.QuizTab.TabIndex = 1;
            this.QuizTab.Text = "Quiz";
            this.QuizTab.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Option1);
            this.groupBox1.Controls.Add(this.rbtn4);
            this.groupBox1.Controls.Add(this.rbtn3);
            this.groupBox1.Controls.Add(this.rbtn2);
            this.groupBox1.Controls.Add(this.rbtn1);
            this.groupBox1.Location = new System.Drawing.Point(6, 163);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(438, 302);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Muitiple Choice";
            // 
            // Option1
            // 
            this.Option1.AutoSize = true;
            this.Option1.Location = new System.Drawing.Point(144, 50);
            this.Option1.Name = "Option1";
            this.Option1.Size = new System.Drawing.Size(0, 25);
            this.Option1.TabIndex = 1;
            this.Option1.Click += new System.EventHandler(this.label4_Click);
            // 
            // rbtn4
            // 
            this.rbtn4.AutoSize = true;
            this.rbtn4.Location = new System.Drawing.Point(6, 192);
            this.rbtn4.Name = "rbtn4";
            this.rbtn4.Size = new System.Drawing.Size(133, 29);
            this.rbtn4.TabIndex = 4;
            this.rbtn4.TabStop = true;
            this.rbtn4.Text = "Option D:";
            this.rbtn4.UseVisualStyleBackColor = true;
            // 
            // rbtn3
            // 
            this.rbtn3.AutoSize = true;
            this.rbtn3.Location = new System.Drawing.Point(6, 146);
            this.rbtn3.Name = "rbtn3";
            this.rbtn3.Size = new System.Drawing.Size(133, 29);
            this.rbtn3.TabIndex = 3;
            this.rbtn3.TabStop = true;
            this.rbtn3.Text = "Option C:";
            this.rbtn3.UseVisualStyleBackColor = true;
            // 
            // rbtn2
            // 
            this.rbtn2.AutoSize = true;
            this.rbtn2.Location = new System.Drawing.Point(6, 99);
            this.rbtn2.Name = "rbtn2";
            this.rbtn2.Size = new System.Drawing.Size(132, 29);
            this.rbtn2.TabIndex = 2;
            this.rbtn2.TabStop = true;
            this.rbtn2.Text = "Option B:";
            this.rbtn2.UseVisualStyleBackColor = true;
            // 
            // rbtn1
            // 
            this.rbtn1.AutoSize = true;
            this.rbtn1.Location = new System.Drawing.Point(6, 48);
            this.rbtn1.Name = "rbtn1";
            this.rbtn1.Size = new System.Drawing.Size(132, 29);
            this.rbtn1.TabIndex = 1;
            this.rbtn1.TabStop = true;
            this.rbtn1.Text = "Option A:";
            this.rbtn1.UseVisualStyleBackColor = true;
            // 
            // ReminderListTab
            // 
            this.ReminderListTab.Controls.Add(this.DeleteBtn);
            this.ReminderListTab.Controls.Add(this.ReminderDataGrid);
            this.ReminderListTab.Location = new System.Drawing.Point(8, 39);
            this.ReminderListTab.Name = "ReminderListTab";
            this.ReminderListTab.Padding = new System.Windows.Forms.Padding(3);
            this.ReminderListTab.Size = new System.Drawing.Size(1744, 894);
            this.ReminderListTab.TabIndex = 2;
            this.ReminderListTab.Text = "ReminderList";
            this.ReminderListTab.UseVisualStyleBackColor = true;
            // 
            // DeleteBtn
            // 
            this.DeleteBtn.Location = new System.Drawing.Point(16, 554);
            this.DeleteBtn.Name = "DeleteBtn";
            this.DeleteBtn.Size = new System.Drawing.Size(266, 75);
            this.DeleteBtn.TabIndex = 1;
            this.DeleteBtn.Text = "Delete";
            this.DeleteBtn.UseVisualStyleBackColor = true;
            this.DeleteBtn.Click += new System.EventHandler(this.DeleteBtn_Click);
            // 
            // ReminderDataGrid
            // 
            this.ReminderDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ReminderDataGrid.Location = new System.Drawing.Point(5, 6);
            this.ReminderDataGrid.Name = "ReminderDataGrid";
            this.ReminderDataGrid.RowHeadersWidth = 82;
            this.ReminderDataGrid.RowTemplate.Height = 33;
            this.ReminderDataGrid.Size = new System.Drawing.Size(1739, 882);
            this.ReminderDataGrid.TabIndex = 0;
            // 
            // LogTab
            // 
            this.LogTab.Controls.Add(this.label4);
            this.LogTab.Controls.Add(this.txtbLog);
            this.LogTab.Location = new System.Drawing.Point(8, 39);
            this.LogTab.Name = "LogTab";
            this.LogTab.Padding = new System.Windows.Forms.Padding(3);
            this.LogTab.Size = new System.Drawing.Size(1744, 894);
            this.LogTab.TabIndex = 3;
            this.LogTab.Text = "Log";
            this.LogTab.UseVisualStyleBackColor = true;
            // 
            // QuestionNum
            // 
            this.QuestionNum.AutoSize = true;
            this.QuestionNum.Location = new System.Drawing.Point(17, 48);
            this.QuestionNum.Name = "QuestionNum";
            this.QuestionNum.Size = new System.Drawing.Size(98, 25);
            this.QuestionNum.TabIndex = 1;
            this.QuestionNum.Text = "Question";
            // 
            // ScoreLabel
            // 
            this.ScoreLabel.AutoSize = true;
            this.ScoreLabel.Location = new System.Drawing.Point(476, 127);
            this.ScoreLabel.Name = "ScoreLabel";
            this.ScoreLabel.Size = new System.Drawing.Size(68, 25);
            this.ScoreLabel.TabIndex = 2;
            this.ScoreLabel.Text = "Score";
            // 
            // txtboxAnswer
            // 
            this.txtboxAnswer.Location = new System.Drawing.Point(481, 262);
            this.txtboxAnswer.Multiline = true;
            this.txtboxAnswer.Name = "txtboxAnswer";
            this.txtboxAnswer.Size = new System.Drawing.Size(436, 203);
            this.txtboxAnswer.TabIndex = 3;
            // 
            // btnEnterQuiz
            // 
            this.btnEnterQuiz.Location = new System.Drawing.Point(12, 570);
            this.btnEnterQuiz.Name = "btnEnterQuiz";
            this.btnEnterQuiz.Size = new System.Drawing.Size(276, 85);
            this.btnEnterQuiz.TabIndex = 4;
            this.btnEnterQuiz.Text = "Enter";
            this.btnEnterQuiz.UseVisualStyleBackColor = true;
            this.btnEnterQuiz.Click += new System.EventHandler(this.btnEnterQuiz_Click);
            // 
            // nextbtn
            // 
            this.nextbtn.Location = new System.Drawing.Point(481, 471);
            this.nextbtn.Name = "nextbtn";
            this.nextbtn.Size = new System.Drawing.Size(167, 49);
            this.nextbtn.TabIndex = 5;
            this.nextbtn.Text = "NextQuestion";
            this.nextbtn.UseVisualStyleBackColor = true;
            this.nextbtn.Click += new System.EventHandler(this.nextbtn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(476, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 25);
            this.label6.TabIndex = 7;
            this.label6.Text = "Answers:";
            // 
            // txtbLog
            // 
            this.txtbLog.Location = new System.Drawing.Point(6, 119);
            this.txtbLog.Multiline = true;
            this.txtbLog.Name = "txtbLog";
            this.txtbLog.Size = new System.Drawing.Size(963, 769);
            this.txtbLog.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 25);
            this.label4.TabIndex = 1;
            this.label4.Text = "Log of all activities";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1771, 965);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.ChatBotTab.ResumeLayout(false);
            this.ChatBotTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReminderUpDown)).EndInit();
            this.QuizTab.ResumeLayout(false);
            this.QuizTab.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ReminderListTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReminderDataGrid)).EndInit();
            this.LogTab.ResumeLayout(false);
            this.LogTab.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage ChatBotTab;
        private System.Windows.Forms.TabPage QuizTab;
        private System.Windows.Forms.TabPage ReminderListTab;
        private System.Windows.Forms.TabPage LogTab;
        private System.Windows.Forms.TextBox ChatResponse;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserInputText;
        private System.Windows.Forms.Button reminderBtn;
        private System.Windows.Forms.NumericUpDown ReminderUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView ReminderDataGrid;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Button DeleteBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtn1;
        private System.Windows.Forms.RadioButton rbtn4;
        private System.Windows.Forms.RadioButton rbtn3;
        private System.Windows.Forms.RadioButton rbtn2;
        private System.Windows.Forms.Label Option1;
        private System.Windows.Forms.TextBox txtboxAnswer;
        private System.Windows.Forms.Label ScoreLabel;
        private System.Windows.Forms.Label QuestionNum;
        private System.Windows.Forms.Button btnEnterQuiz;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button nextbtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtbLog;
    }
}

