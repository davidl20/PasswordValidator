namespace PasswordValidator
{
    partial class MainForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.CheckBoxUpperCase = new System.Windows.Forms.CheckBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.CheckBoxSymbols = new System.Windows.Forms.CheckBox();
            this.CheckBoxDigits = new System.Windows.Forms.CheckBox();
            this.CheckBoxLowerCase = new System.Windows.Forms.CheckBox();
            this.CheckBoxMustStartWithUpper = new System.Windows.Forms.CheckBox();

            this.TrackBarLength = new System.Windows.Forms.TrackBar();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.lblCombinationsResult = new System.Windows.Forms.Label();
            this.CheckBoxMustStartWithLetter = new System.Windows.Forms.CheckBox();
            this.CheckBoxMustContainDigit = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarLength)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CheckBoxUpperCase);
            this.groupBox1.Controls.Add(this.CheckBoxSymbols);
            this.groupBox1.Controls.Add(this.CheckBoxDigits);
            this.groupBox1.Controls.Add(this.CheckBoxLowerCase);
            this.groupBox1.Controls.Add(this.CheckBoxMustStartWithLetter);
            this.groupBox1.Controls.Add(this.CheckBoxMustContainDigit);
            this.groupBox1.Controls.Add(this.CheckBoxMustStartWithUpper);

            this.groupBox1.Controls.Add(this.lblLength);
            this.groupBox1.Controls.Add(this.TrackBarLength);
            this.groupBox1.Location = new System.Drawing.Point(67, 81);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(680, 150);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // CheckBoxUpperCase
            // 
            this.CheckBoxUpperCase.AutoSize = true;
            this.CheckBoxUpperCase.Checked = true;
            this.CheckBoxUpperCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxUpperCase.Location = new System.Drawing.Point(220, 81);
            this.CheckBoxUpperCase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CheckBoxUpperCase.Name = "CheckBoxUpperCase";
            this.CheckBoxUpperCase.Size = new System.Drawing.Size(97, 20);
            this.CheckBoxUpperCase.TabIndex = 5;
            this.CheckBoxUpperCase.Text = "Uppercase";
            this.CheckBoxUpperCase.UseVisualStyleBackColor = true;
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLength.Location = new System.Drawing.Point(632, 21);
            this.lblLength.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(20, 24);
            this.lblLength.TabIndex = 4;
            this.lblLength.Text = "8";
            // 
            // CheckBoxSymbols
            // 
            this.CheckBoxSymbols.AutoSize = true;
            this.CheckBoxSymbols.Checked = true;
            this.CheckBoxSymbols.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxSymbols.Location = new System.Drawing.Point(504, 81);
            this.CheckBoxSymbols.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CheckBoxSymbols.Name = "CheckBoxSymbols";
            this.CheckBoxSymbols.Size = new System.Drawing.Size(82, 20);
            this.CheckBoxSymbols.TabIndex = 3;
            this.CheckBoxSymbols.Text = "Symbols";
            this.CheckBoxSymbols.UseVisualStyleBackColor = true;
            // 
            // CheckBoxDigits
            // 
            this.CheckBoxDigits.AutoSize = true;
            this.CheckBoxDigits.Checked = true;
            this.CheckBoxDigits.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxDigits.Location = new System.Drawing.Point(386, 81);
            this.CheckBoxDigits.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CheckBoxDigits.Name = "CheckBoxDigits";
            this.CheckBoxDigits.Size = new System.Drawing.Size(63, 20);
            this.CheckBoxDigits.TabIndex = 1;
            this.CheckBoxDigits.Text = "Digits";
            this.CheckBoxDigits.UseVisualStyleBackColor = true;
            // 
            // CheckBoxLowerCase
            // 
            this.CheckBoxLowerCase.AutoSize = true;
            this.CheckBoxLowerCase.Checked = true;
            this.CheckBoxLowerCase.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxLowerCase.Location = new System.Drawing.Point(65, 81);
            this.CheckBoxLowerCase.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CheckBoxLowerCase.Name = "CheckBoxLowerCase";
            this.CheckBoxLowerCase.Size = new System.Drawing.Size(95, 20);
            this.CheckBoxLowerCase.TabIndex = 0;
            this.CheckBoxLowerCase.Text = "Lowercase";
            this.CheckBoxLowerCase.UseVisualStyleBackColor = true;
            // 
            // CheckBoxMustStartWithLetter
            //
            this.CheckBoxMustStartWithLetter.AutoSize = true;
            this.CheckBoxMustStartWithLetter.Checked = true;
            this.CheckBoxMustStartWithLetter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxMustStartWithLetter.Location = new System.Drawing.Point(65, 115);
            this.CheckBoxMustStartWithLetter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CheckBoxMustStartWithLetter.Name = "CheckBoxStartWithLetter";
            this.CheckBoxMustStartWithLetter.Size = new System.Drawing.Size(125, 20);
            this.CheckBoxMustStartWithLetter.TabIndex = 6;
            this.CheckBoxMustStartWithLetter.Text = "Start With Letter";
            this.CheckBoxMustStartWithLetter.UseVisualStyleBackColor = true;
            // 
            // CheckBoxMustContainDigit
            //
            this.CheckBoxMustContainDigit.AutoSize = true;
            this.CheckBoxMustContainDigit.Checked = true;
            this.CheckBoxMustContainDigit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxMustContainDigit.Location = new System.Drawing.Point(220, 115);
            this.CheckBoxMustContainDigit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CheckBoxMustContainDigit.Name = "CheckBoxMustContainDigit";
            this.CheckBoxMustContainDigit.Size = new System.Drawing.Size(130, 20);
            this.CheckBoxMustContainDigit.TabIndex = 7;
            this.CheckBoxMustContainDigit.Text = "Must Contain Digit";
            this.CheckBoxMustContainDigit.UseVisualStyleBackColor = true;
            // 
            // CheckBoxMustStartWithUpper
            //
            this.CheckBoxMustStartWithUpper.AutoSize = true;
            this.CheckBoxMustStartWithUpper.Checked = true;
            this.CheckBoxMustStartWithUpper.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CheckBoxMustStartWithUpper.Location = new System.Drawing.Point(386, 115);
            this.CheckBoxMustStartWithUpper.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CheckBoxMustStartWithUpper.Name = "CheckBoxMustStartWithUpper";
            this.CheckBoxMustStartWithUpper.Size = new System.Drawing.Size(125, 20);
            this.CheckBoxMustStartWithUpper.TabIndex = 8;
            this.CheckBoxMustStartWithUpper.Text = "Start with Upper";
            this.CheckBoxMustStartWithUpper.UseVisualStyleBackColor = true;
            // 
            // TrackBarLength
            // 
            this.TrackBarLength.Location = new System.Drawing.Point(65, 21);
            this.TrackBarLength.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.TrackBarLength.Maximum = 64;
            this.TrackBarLength.Name = "TrackBarLength";
            this.TrackBarLength.Size = new System.Drawing.Size(567, 56);
            this.TrackBarLength.TabIndex = 2;
            this.TrackBarLength.Value = 8;
            this.TrackBarLength.Scroll += new System.EventHandler(this.TrackBarScroll);
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(556, 27);
            this.btnGenerate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(117, 34);
            this.btnGenerate.TabIndex = 1;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.BtnGenerateClick);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(679, 27);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(67, 34);
            this.btnCopy.TabIndex = 2;
            this.btnCopy.Text = "Copy";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.BtnCopyClick);
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(77, 28);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(473, 34);
            this.txtPassword.TabIndex = 3;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(67, 245);
            this.btnCalculate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(117, 34);
            this.btnCalculate.TabIndex = 4;
            this.btnCalculate.Text = "Calcular";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.BtnCalculateClick);
            // 
            // lblCombinationsResult
            // 
            this.lblCombinationsResult.AutoSize = true;
            this.lblCombinationsResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCombinationsResult.Location = new System.Drawing.Point(200, 252);
            this.lblCombinationsResult.Name = "lblCombinationsResult";
            this.lblCombinationsResult.Size = new System.Drawing.Size(164, 20);
            this.lblCombinationsResult.TabIndex = 5;
            this.lblCombinationsResult.Text = "Total de combinaciones: -";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 310);
            this.Controls.Add(this.lblCombinationsResult);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MainForm";
            this.Text = "PasswordValidator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrackBarLength)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox CheckBoxSymbols;
        private System.Windows.Forms.TrackBar TrackBarLength;
        private System.Windows.Forms.CheckBox CheckBoxDigits;
        private System.Windows.Forms.CheckBox CheckBoxLowerCase;
        private System.Windows.Forms.CheckBox CheckBoxMustStartWithLetter;
        private System.Windows.Forms.CheckBox CheckBoxMustContainDigit;
        private System.Windows.Forms.CheckBox CheckBoxMustStartWithUpper;

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.CheckBox CheckBoxUpperCase;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label lblCombinationsResult;
    }
}
