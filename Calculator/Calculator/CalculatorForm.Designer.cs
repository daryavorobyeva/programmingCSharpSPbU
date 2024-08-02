namespace Calculator;

partial class CalculatorForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        InputTable = new TableLayoutPanel();
        divideButton = new Button();
        calculateButton = new Button();
        changeSignButton = new Button();
        multiplyButton = new Button();
        minusButton = new Button();
        zeroButton = new Button();
        oneButton = new Button();
        twoButton = new Button();
        threeButton = new Button();
        sixButton = new Button();
        fiveButton = new Button();
        fourButton = new Button();
        nineButton = new Button();
        eightButton = new Button();
        sevenButton = new Button();
        plusButton = new Button();
        ClearButton = new Button();
        result = new TextBox();
        InputTable.SuspendLayout();
        SuspendLayout();

        InputTable.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        InputTable.ColumnCount = 4;
        InputTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        InputTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        InputTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        InputTable.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        InputTable.Controls.Add(divideButton, 3, 3);
        InputTable.Controls.Add(calculateButton, 2, 3);
        InputTable.Controls.Add(changeSignButton, 1, 3);
        InputTable.Controls.Add(multiplyButton, 3, 2);
        InputTable.Controls.Add(minusButton, 3, 1);
        InputTable.Controls.Add(zeroButton, 0, 3);
        InputTable.Controls.Add(oneButton, 0, 2);
        InputTable.Controls.Add(twoButton, 0, 2);
        InputTable.Controls.Add(threeButton, 1, 2);
        InputTable.Controls.Add(sixButton, 1, 1);
        InputTable.Controls.Add(fiveButton, 1, 1);
        InputTable.Controls.Add(fourButton, 0, 1);
        InputTable.Controls.Add(nineButton, 2, 0);
        InputTable.Controls.Add(eightButton, 1, 0);
        InputTable.Controls.Add(sevenButton, 0, 0);
        InputTable.Controls.Add(plusButton, 3, 0);
        InputTable.Location = new Point(12, 290);
        InputTable.Name = "InputTable";
        InputTable.RowCount = 4;
        InputTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        InputTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        InputTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        InputTable.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
        InputTable.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
        InputTable.Size = new Size(408, 256);
        InputTable.TabIndex = 2;
  
        divideButton.BackColor = SystemColors.ButtonFace;
        divideButton.Dock = DockStyle.Fill;
        divideButton.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
        divideButton.ForeColor = Color.Navy;
        divideButton.Location = new Point(309, 195);
        divideButton.Name = "divideButton";
        divideButton.Size = new Size(96, 58);
        divideButton.TabIndex = 13;
        divideButton.Text = "/";
        divideButton.UseVisualStyleBackColor = false;
        divideButton.Click += OnOperationButtonClick;

        calculateButton.BackColor = SystemColors.ButtonFace;
        calculateButton.Dock = DockStyle.Fill;
        calculateButton.Font = new Font("Microsoft Sans Serif", 25.8000011F, FontStyle.Bold);
        calculateButton.ForeColor = Color.Navy;
        calculateButton.Location = new Point(207, 195);
        calculateButton.Name = "calculateButton";
        calculateButton.Size = new Size(96, 58);
        calculateButton.TabIndex = 14;
        calculateButton.Text = "=";
        calculateButton.UseVisualStyleBackColor = false;
        calculateButton.Click += OnCalculateButtonClick;
 
        changeSignButton.BackColor = SystemColors.ButtonFace;
        changeSignButton.Dock = DockStyle.Fill;
        changeSignButton.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold);
        changeSignButton.ForeColor = Color.Navy;
        changeSignButton.Location = new Point(105, 195);
        changeSignButton.Name = "changeSignButton";
        changeSignButton.Size = new Size(96, 58);
        changeSignButton.TabIndex = 0;
        changeSignButton.Text = "+/-";
        changeSignButton.UseVisualStyleBackColor = false;
        changeSignButton.Click += OnOperationButtonClick;
 
        multiplyButton.BackColor = SystemColors.ButtonFace;
        multiplyButton.Dock = DockStyle.Fill;
        multiplyButton.Font = new Font("Microsoft Sans Serif", 28.2F, FontStyle.Bold);
        multiplyButton.ForeColor = Color.Navy;
        multiplyButton.Location = new Point(309, 131);
        multiplyButton.Name = "multiplyButton";
        multiplyButton.Size = new Size(96, 58);
        multiplyButton.TabIndex = 12;
        multiplyButton.Text = "*";
        multiplyButton.UseVisualStyleBackColor = false;
        multiplyButton.Click += OnOperationButtonClick;
 
        minusButton.BackColor = SystemColors.ButtonFace;
        minusButton.Dock = DockStyle.Fill;
        minusButton.Font = new Font("Microsoft Sans Serif", 28.8000011F, FontStyle.Bold);
        minusButton.ForeColor = Color.Navy;
        minusButton.Location = new Point(309, 67);
        minusButton.Name = "minusButton";
        minusButton.Size = new Size(96, 58);
        minusButton.TabIndex = 11;
        minusButton.Text = "-";
        minusButton.UseVisualStyleBackColor = false;
        minusButton.Click += OnOperationButtonClick;

        zeroButton.BackColor = Color.RoyalBlue;
        zeroButton.Dock = DockStyle.Fill;
        zeroButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold);
        zeroButton.ForeColor = SystemColors.Info;
        zeroButton.Location = new Point(3, 195);
        zeroButton.Name = "zeroButton";
        zeroButton.Size = new Size(96, 58);
        zeroButton.TabIndex = 1;
        zeroButton.Text = "0";
        zeroButton.UseVisualStyleBackColor = false;
        zeroButton.Click += OnDigitButtonClick;

        oneButton.BackColor = Color.RoyalBlue;
        oneButton.Dock = DockStyle.Fill;
        oneButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold);
        oneButton.ForeColor = SystemColors.Info;
        oneButton.Location = new Point(3, 131);
        oneButton.Name = "oneButton";
        oneButton.Size = new Size(96, 58);
        oneButton.TabIndex = 2;
        oneButton.Text = "1";
        oneButton.UseVisualStyleBackColor = false;
        oneButton.Click += OnDigitButtonClick;
   
        twoButton.BackColor = Color.RoyalBlue;
        twoButton.Dock = DockStyle.Fill;
        twoButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold);
        twoButton.ForeColor = SystemColors.Info;
        twoButton.Location = new Point(105, 131);
        twoButton.Name = "twoButton";
        twoButton.Size = new Size(96, 58);
        twoButton.TabIndex = 2;
        twoButton.Text = "2";
        twoButton.UseVisualStyleBackColor = false;
        twoButton.Click += OnDigitButtonClick;

        threeButton.BackColor = Color.RoyalBlue;
        threeButton.Dock = DockStyle.Fill;
        threeButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold);
        threeButton.ForeColor = SystemColors.Info;
        threeButton.Location = new Point(207, 131);
        threeButton.Name = "threeButton";
        threeButton.Size = new Size(96, 58);
        threeButton.TabIndex = 3;
        threeButton.Text = "3";
        threeButton.UseVisualStyleBackColor = false;
        threeButton.Click += OnDigitButtonClick;

        sixButton.BackColor = Color.RoyalBlue;
        sixButton.Dock = DockStyle.Fill;
        sixButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold);
        sixButton.ForeColor = SystemColors.Info;
        sixButton.Location = new Point(207, 67);
        sixButton.Name = "sixButton";
        sixButton.Size = new Size(96, 58);
        sixButton.TabIndex = 6;
        sixButton.Text = "6";
        sixButton.UseVisualStyleBackColor = false;
        sixButton.Click += OnDigitButtonClick;

        fiveButton.BackColor = Color.RoyalBlue;
        fiveButton.Dock = DockStyle.Fill;
        fiveButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold);
        fiveButton.ForeColor = SystemColors.Info;
        fiveButton.Location = new Point(105, 67);
        fiveButton.Name = "fiveButton";
        fiveButton.Size = new Size(96, 58);
        fiveButton.TabIndex = 5;
        fiveButton.Text = "5";
        fiveButton.UseVisualStyleBackColor = false;
        fiveButton.Click += OnDigitButtonClick;

        fourButton.BackColor = Color.RoyalBlue;
        fourButton.Dock = DockStyle.Fill;
        fourButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold);
        fourButton.ForeColor = SystemColors.Info;
        fourButton.Location = new Point(3, 67);
        fourButton.Name = "fourButton";
        fourButton.Size = new Size(96, 58);
        fourButton.TabIndex = 4;
        fourButton.Text = "4";
        fourButton.UseVisualStyleBackColor = false;
        fourButton.Click += OnDigitButtonClick;

        nineButton.BackColor = Color.RoyalBlue;
        nineButton.Dock = DockStyle.Fill;
        nineButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold);
        nineButton.ForeColor = SystemColors.Info;
        nineButton.Location = new Point(207, 3);
        nineButton.Name = "nineButton";
        nineButton.Size = new Size(96, 58);
        nineButton.TabIndex = 9;
        nineButton.Text = "9";
        nineButton.UseVisualStyleBackColor = false;
        nineButton.Click += OnDigitButtonClick;

        eightButton.BackColor = Color.RoyalBlue;
        eightButton.Dock = DockStyle.Fill;
        eightButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold);
        eightButton.ForeColor = SystemColors.Info;
        eightButton.Location = new Point(105, 3);
        eightButton.Name = "eightButton";
        eightButton.Size = new Size(96, 58);
        eightButton.TabIndex = 8;
        eightButton.Text = "8";
        eightButton.UseVisualStyleBackColor = false;
        eightButton.Click += OnDigitButtonClick;

        sevenButton.BackColor = Color.RoyalBlue;
        sevenButton.Dock = DockStyle.Fill;
        sevenButton.Font = new Font("Calibri", 22.2F, FontStyle.Bold);
        sevenButton.ForeColor = SystemColors.Info;
        sevenButton.Location = new Point(3, 3);
        sevenButton.Name = "sevenButton";
        sevenButton.Size = new Size(96, 58);
        sevenButton.TabIndex = 7;
        sevenButton.Text = "7";
        sevenButton.UseVisualStyleBackColor = false;
        sevenButton.Click += OnDigitButtonClick;

        plusButton.BackColor = SystemColors.ButtonFace;
        plusButton.Dock = DockStyle.Fill;
        plusButton.Font = new Font("Microsoft Sans Serif", 28.2F, FontStyle.Bold);
        plusButton.ForeColor = Color.Navy;
        plusButton.Location = new Point(309, 3);
        plusButton.Name = "plusButton";
        plusButton.Size = new Size(96, 58);
        plusButton.TabIndex = 10;
        plusButton.Text = "+";
        plusButton.UseVisualStyleBackColor = false;
        plusButton.Click += OnOperationButtonClick;

        ClearButton.BackColor = SystemColors.ButtonFace;
        ClearButton.Font = new Font("Calibri", 24F, FontStyle.Bold);
        ClearButton.ForeColor = Color.Navy;
        ClearButton.Location = new Point(12, 12);
        ClearButton.Name = "ClearButton";
        ClearButton.Size = new Size(96, 58);
        ClearButton.TabIndex = 15;
        ClearButton.Text = "C";
        ClearButton.UseVisualStyleBackColor = false;
        ClearButton.Click += OnClearButtonClick;

        result.BackColor = SystemColors.GradientActiveCaption;
        result.BorderStyle = BorderStyle.None;
        result.Font = new Font("Gadugi", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
        result.ForeColor = Color.Navy;
        result.Location = new Point(15, 118);
        result.Name = "result";
        result.Size = new Size(405, 67);
        result.TabIndex = 16;
        result.TextAlign = HorizontalAlignment.Right;

        AutoScaleDimensions = new SizeF(9F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = SystemColors.GradientActiveCaption;
        ClientSize = new Size(432, 558);
        Controls.Add(result);
        Controls.Add(ClearButton);
        Controls.Add(InputTable);
        Font = new Font("Cascadia Code SemiBold", 9F);
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        MinimumSize = new Size(450, 605);
        Name = "CalculatorForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Calculator";
        InputTable.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private TextBox chain;
    private TableLayoutPanel InputTable;
    private Button sevenButton;
    private Button nineButton;
    private Button eightButton;
    private Button zeroButton;
    private Button oneButton;
    private Button twoButton;
    private Button threeButton;
    private Button sixButton;
    private Button fiveButton;
    private Button fourButton;
    private Button plusButton;
    private Button divideButton;
    private Button calculateButton;
    private Button changeSignButton;
    private Button multiplyButton;
    private Button minusButton;
    private Button ClearButton;
    private TextBox result;
}