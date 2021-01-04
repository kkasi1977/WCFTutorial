namespace WindowsClient
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGetEvenNumbers = new System.Windows.Forms.Button();
            this.btnGetOddNumbers = new System.Windows.Forms.Button();
            this.btnClearResults = new System.Windows.Forms.Button();
            this.listBoxEvenNumbers = new System.Windows.Forms.ListBox();
            this.listBoxOddNumbers = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // btnGetEvenNumbers
            // 
            this.btnGetEvenNumbers.Location = new System.Drawing.Point(12, 9);
            this.btnGetEvenNumbers.Name = "btnGetEvenNumbers";
            this.btnGetEvenNumbers.Size = new System.Drawing.Size(124, 23);
            this.btnGetEvenNumbers.TabIndex = 0;
            this.btnGetEvenNumbers.Text = "Get Even Numbers";
            this.btnGetEvenNumbers.UseVisualStyleBackColor = true;
            this.btnGetEvenNumbers.Click += new System.EventHandler(this.btnGetEvenNumbers_Click);
            // 
            // btnGetOddNumbers
            // 
            this.btnGetOddNumbers.Location = new System.Drawing.Point(146, 9);
            this.btnGetOddNumbers.Name = "btnGetOddNumbers";
            this.btnGetOddNumbers.Size = new System.Drawing.Size(124, 23);
            this.btnGetOddNumbers.TabIndex = 1;
            this.btnGetOddNumbers.Text = "Get Odd Numbers";
            this.btnGetOddNumbers.UseVisualStyleBackColor = true;
            this.btnGetOddNumbers.Click += new System.EventHandler(this.btnGetOddNumbers_Click);
            // 
            // btnClearResults
            // 
            this.btnClearResults.Location = new System.Drawing.Point(12, 192);
            this.btnClearResults.Name = "btnClearResults";
            this.btnClearResults.Size = new System.Drawing.Size(258, 23);
            this.btnClearResults.TabIndex = 2;
            this.btnClearResults.Text = "Clear Results";
            this.btnClearResults.UseVisualStyleBackColor = true;
            this.btnClearResults.Click += new System.EventHandler(this.btnClearResults_Click);
            // 
            // listBoxEvenNumbers
            // 
            this.listBoxEvenNumbers.FormattingEnabled = true;
            this.listBoxEvenNumbers.ItemHeight = 12;
            this.listBoxEvenNumbers.Location = new System.Drawing.Point(12, 38);
            this.listBoxEvenNumbers.Name = "listBoxEvenNumbers";
            this.listBoxEvenNumbers.Size = new System.Drawing.Size(124, 148);
            this.listBoxEvenNumbers.TabIndex = 3;
            // 
            // listBoxOddNumbers
            // 
            this.listBoxOddNumbers.FormattingEnabled = true;
            this.listBoxOddNumbers.ItemHeight = 12;
            this.listBoxOddNumbers.Location = new System.Drawing.Point(146, 38);
            this.listBoxOddNumbers.Name = "listBoxOddNumbers";
            this.listBoxOddNumbers.Size = new System.Drawing.Size(124, 148);
            this.listBoxOddNumbers.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            this.backgroundWorker2.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker2_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 225);
            this.Controls.Add(this.listBoxOddNumbers);
            this.Controls.Add(this.listBoxEvenNumbers);
            this.Controls.Add(this.btnClearResults);
            this.Controls.Add(this.btnGetOddNumbers);
            this.Controls.Add(this.btnGetEvenNumbers);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetEvenNumbers;
        private System.Windows.Forms.Button btnGetOddNumbers;
        private System.Windows.Forms.Button btnClearResults;
        private System.Windows.Forms.ListBox listBoxEvenNumbers;
        private System.Windows.Forms.ListBox listBoxOddNumbers;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
    }
}

