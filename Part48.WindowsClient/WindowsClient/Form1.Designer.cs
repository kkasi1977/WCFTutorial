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
            this.btnGetMessage = new System.Windows.Forms.Button();
            this.btnGetSignedMessage = new System.Windows.Forms.Button();
            this.btnGetSignedEncryptedMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetMessage
            // 
            this.btnGetMessage.Location = new System.Drawing.Point(17, 13);
            this.btnGetMessage.Name = "btnGetMessage";
            this.btnGetMessage.Size = new System.Drawing.Size(295, 27);
            this.btnGetMessage.TabIndex = 0;
            this.btnGetMessage.Text = "Get Message - Not Signed and Not Encrypted";
            this.btnGetMessage.UseVisualStyleBackColor = true;
            this.btnGetMessage.Click += new System.EventHandler(this.btnGetMessage_Click);
            // 
            // btnGetSignedMessage
            // 
            this.btnGetSignedMessage.Location = new System.Drawing.Point(17, 50);
            this.btnGetSignedMessage.Name = "btnGetSignedMessage";
            this.btnGetSignedMessage.Size = new System.Drawing.Size(295, 27);
            this.btnGetSignedMessage.TabIndex = 1;
            this.btnGetSignedMessage.Text = "Get Message Signed but Not Encrypted";
            this.btnGetSignedMessage.UseVisualStyleBackColor = true;
            this.btnGetSignedMessage.Click += new System.EventHandler(this.btnGetSignedMessage_Click);
            // 
            // btnGetSignedEncryptedMessage
            // 
            this.btnGetSignedEncryptedMessage.Location = new System.Drawing.Point(17, 88);
            this.btnGetSignedEncryptedMessage.Name = "btnGetSignedEncryptedMessage";
            this.btnGetSignedEncryptedMessage.Size = new System.Drawing.Size(295, 27);
            this.btnGetSignedEncryptedMessage.TabIndex = 2;
            this.btnGetSignedEncryptedMessage.Text = "Get Message - Signed and Encrypted";
            this.btnGetSignedEncryptedMessage.UseVisualStyleBackColor = true;
            this.btnGetSignedEncryptedMessage.Click += new System.EventHandler(this.btnGetSignedEncryptedMessage_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 131);
            this.Controls.Add(this.btnGetSignedEncryptedMessage);
            this.Controls.Add(this.btnGetSignedMessage);
            this.Controls.Add(this.btnGetMessage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetMessage;
        private System.Windows.Forms.Button btnGetSignedMessage;
        private System.Windows.Forms.Button btnGetSignedEncryptedMessage;
    }
}

