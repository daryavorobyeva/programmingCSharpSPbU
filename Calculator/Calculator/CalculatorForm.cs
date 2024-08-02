namespace Calculator;

public partial class CalculatorForm : Form
{
    private readonly Calculator calculator = new();

    public CalculatorForm()
    {
        InitializeComponent();

        var resultBinding = new Binding("Text", calculator, "Message", true, DataSourceUpdateMode.OnPropertyChanged);
        result.DataBindings.Add(resultBinding);
    }

    private void UpdateFontSize()
    {
        if (result.Text.Length == 0) 
	{
	    return;
	}

        Font font = result.Font;
        Size textSize = TextRenderer.MeasureText(result.Text, font);

        while (textSize.Width > result.ClientSize.Width && font.Size > 8)
        {
            font = new Font(font.FontFamily, font.Size - 1);
            textSize = TextRenderer.MeasureText(result.Text, font);
        }

        while (textSize.Width < result.ClientSize.Width && font.Size < 30)
        {
            font = new Font(font.FontFamily, font.Size + 1);
            textSize = TextRenderer.MeasureText(result.Text, font);
        }

        result.Font = font;
    }

    private void OnDigitButtonClick(object sender, EventArgs e)
    {
        var digit = ((Button)sender).Text[0];
        calculator.AddDigit(digit);

        UpdateFontSize();
    }

    private void OnOperationButtonClick(object sender, EventArgs e)
    {
        var operation = ((Button)sender).Text;
        calculator.AddOperation(operation);

        UpdateFontSize();
    }

    private void OnCalculateButtonClick(object sender, EventArgs e)
    {
        calculator.CalculateResult();
        UpdateFontSize();
    }

    private void OnClearButtonClick(object sender, EventArgs e)
    {
        calculator.Clear();
        UpdateFontSize();
    }
}
