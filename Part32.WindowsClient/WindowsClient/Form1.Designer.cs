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
            this.btnRequestReplyOperation = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnRequestReplyOperation_ThrowsException = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnRequestReplyOperation
            // 
            this.btnRequestReplyOperation.Location = new System.Drawing.Point(12, 177);
            this.btnRequestReplyOperation.Name = "btnRequestReplyOperation";
            this.btnRequestReplyOperation.Size = new System.Drawing.Size(452, 23);
            this.btnRequestReplyOperation.TabIndex = 0;
            this.btnRequestReplyOperation.Text = "Request Reply Operation";
            this.btnRequestReplyOperation.UseVisualStyleBackColor = true;
            this.btnRequestReplyOperation.Click += new System.EventHandler(this.btnRequestReplyOperation_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(12, 11);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(453, 160);
            this.listBox1.TabIndex = 1;
            // 
            // btnRequestReplyOperation_ThrowsException
            // 
            this.btnRequestReplyOperation_ThrowsException.Location = new System.Drawing.Point(12, 203);
            this.btnRequestReplyOperation_ThrowsException.Name = "btnRequestReplyOperation_ThrowsException";
            this.btnRequestReplyOperation_ThrowsException.Size = new System.Drawing.Size(452, 23);
            this.btnRequestReplyOperation_ThrowsException.TabIndex = 2;
            this.btnRequestReplyOperation_ThrowsException.Text = "Request Reply Operation - ThrowsException";
            this.btnRequestReplyOperation_ThrowsException.UseVisualStyleBackColor = true;
            this.btnRequestReplyOperation_ThrowsException.Click += new System.EventHandler(this.btnRequestReplyOperation_ThrowsException_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 229);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(452, 23);
            this.btnClear.TabIndex = 3;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 262);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnRequestReplyOperation_ThrowsException);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnRequestReplyOperation);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRequestReplyOperation;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnRequestReplyOperation_ThrowsException;
        private System.Windows.Forms.Button btnClear;
    }
}

