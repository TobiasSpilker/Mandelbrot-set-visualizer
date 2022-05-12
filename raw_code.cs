using System;
using System.Windows;
using System.Drawing;
using System.Windows.Forms;

public class screen : Form
{
    public TextBox MidX;
    public TextBox MidY;
    public TextBox Scale;
    public TextBox MaxRep;

    public screen()
    {
        this.Text = "Tobias Spilker & Stijn van Huet - Mandelbrot";
        this.BackColor = Color.LightGoldenrodYellow;
        this.Size = new Size(600, 600);
        this.ClientSize = new Size(600, 650);
        this.CenterToScreen();

        this.StartButton();
        this.PresetButtons();
        this.UserInterface();
        this.UserInterfaceText();
        this.Refressh();
        this.Panel();

    }

    private void PresetButtons()
    {
        Button BasisKnop = new Button();
        BasisKnop.Text = "normal";
        BasisKnop.BackColor = Color.LightBlue;
        BasisKnop.Location = new Point(300, 20);
        this.Controls.Add(BasisKnop);
        BasisKnop.Click += this.ToBasis;

        Button ZuilenKnop = new Button();
        ZuilenKnop.Text = "blossom";
        ZuilenKnop.BackColor = Color.LightBlue;
        ZuilenKnop.Location = new Point(300, 45);
        this.Controls.Add(ZuilenKnop);
        ZuilenKnop.Click += this.ToBloesem;

        Button LavaKnop = new Button();
        LavaKnop.Text = "lava";
        LavaKnop.BackColor = Color.LightBlue;
        LavaKnop.Location = new Point(300, 70);
        this.Controls.Add(LavaKnop);
        LavaKnop.Click += this.ToLava;

        Button BlaadjesKnop = new Button();
        BlaadjesKnop.Text = "winter";
        BlaadjesKnop.BackColor= Color.LightBlue;
        BlaadjesKnop.Location = new Point(300, 95);
        this.Controls.Add(BlaadjesKnop);
        BlaadjesKnop.Click += this.ToWinter;
    }

    private void ToBasis(object sender, EventArgs e)
    {
        MaxRepOutput = 100;
        ScaleOutput = 0.008;
        MidXOutput = 0;
        MidYOutput = 0;
        p = 0;
        q = 0;
        MidPointCorrector = -250 * ScaleOutput + 2;

        string MaxRep_Temp = MaxRepOutput.ToString();   
        this.MaxRep.Text = MaxRep_Temp;                
        string Scale_Temp = ScaleOutput.ToString();
        this.Scale.Text = Scale_Temp;
        string MidX_Temp = MidXOutput.ToString();
        this.MidX.Text = MidX_Temp;
        string MidY_Temp = MidYOutput.ToString();
        this.MidY.Text = MidY_Temp;

        panel.Invalidate();
    }

    private void ToBloesem(object sender, EventArgs e)
    {
        MaxRepOutput = 400;
        ScaleOutput = 3.8147E-8;
        MidXOutput = -0.108625;
        MidYOutput = 0.9014428;
        p = 25;
        q = 100;
        MidPointCorrector = -250 * ScaleOutput + 2;

        string MaxRep_Temp = MaxRepOutput.ToString();  
        this.MaxRep.Text = MaxRep_Temp;                
        string Scale_Temp = ScaleOutput.ToString();
        this.Scale.Text = Scale_Temp;
        string MidX_Temp = MidXOutput.ToString();
        this.MidX.Text = MidX_Temp;
        string MidY_Temp = MidYOutput.ToString();
        this.MidY.Text = MidY_Temp;

        panel.Invalidate();
    }

    private void ToLava(object sender, EventArgs e)
    {
        MaxRepOutput = 100;
        ScaleOutput = 0.00000117;
        MidXOutput = 0.01;
        MidYOutput = 0.739;
        p = 25;
        q = 25;
        MidPointCorrector = -250 * ScaleOutput + 2;

        string MaxRep_Temp = MaxRepOutput.ToString(); 
        this.MaxRep.Text = MaxRep_Temp;                 
        string Scale_Temp = ScaleOutput.ToString();
        this.Scale.Text = Scale_Temp;
        string MidX_Temp = MidXOutput.ToString();
        this.MidX.Text = MidX_Temp;
        string MidY_Temp = MidYOutput.ToString();
        this.MidY.Text = MidY_Temp;

        panel.Invalidate();
    }

    private void ToWinter(object sender, EventArgs e)
    {
        MaxRepOutput = 50;
        ScaleOutput = 0.00001;
        MidXOutput = -0.052;
        MidYOutput = -0.832;
        p = 230;
        q = 230;
        MidPointCorrector = -250 * ScaleOutput + 2;

        string MaxRep_Temp = MaxRepOutput.ToString();
        this.MaxRep.Text = MaxRep_Temp;                
        string Scale_Temp = ScaleOutput.ToString(); 
        this.Scale.Text = Scale_Temp;
        string MidX_Temp = MidXOutput.ToString();
        this.MidX.Text = MidX_Temp;
        string MidY_Temp = MidYOutput.ToString();
        this.MidY.Text = MidY_Temp;

        panel.Invalidate();
    }

    private void StartButton()
    {
        Button knop = new Button();
        knop.Text = "START";
        knop.BackColor = Color.LightCoral;
        knop.Location = new Point(500, 80);
        this.Controls.Add(knop);
        knop.Click += this.knopklik;
    }

    private void knopklik(object sender, EventArgs e)
    {
        this.Refressh();
        panel.Invalidate();
    }

    Panel panel;

    private void Panel()
    {
        panel = new Panel();
        panel.Size        = new Size(500, 500);
        panel.Location    = new Point(50, 140);
        panel.BackColor   = Color.White;
        panel.BorderStyle = BorderStyle.FixedSingle;
        panel.Name        = "Mandelbrot";

        panel.Paint += this.DrawMandelbrot;
        Controls.Add(panel);

    }

    private void UserInterface()
    {

        this.MaxRep = new TextBox();
        this.MaxRep.Location = new Point(5, 30);
        this.MaxRep.Size = new Size(75, 5);
        this.MaxRep.Text = "100";
        this.MaxRep.BackColor = Color.LightBlue;
        this.Controls.Add(this.MaxRep);

        this.Scale = new TextBox();
        this.Scale.Location = new Point(5, 80);
        this.Scale.Size = new Size(75, 5);
        this.Scale.Text = "0,008";
        this.Scale.BackColor = Color.LightBlue;
        this.Controls.Add(this.Scale);

        this.MidX = new TextBox();
        this.MidX.Location = new Point(130, 30);
        this.MidX.Size = new Size(75, 5);
        this.MidX.Text = "0";
        this.MidX.BackColor = Color.LightBlue;
        this.Controls.Add(this.MidX);

        this.MidY = new TextBox();
        this.MidY.Location = new Point(130, 80);
        this.MidY.Size = new Size(75, 5);
        this.MidY.Text = "0";
        this.MidY.BackColor = Color.LightBlue;
        this.Controls.Add(this.MidY);

    }

    double MaxRepOutput;
    double ScaleOutput;
    double MidXOutput;
    double MidYOutput;
    double MidPointCorrector;

    private void Refressh()
    {
        string MaxRepString = this.MaxRep.Text;
        MaxRepOutput = double.Parse(MaxRepString);
        Console.WriteLine(MaxRepOutput);

        string ScaleString = Scale.Text;
        ScaleOutput = double.Parse(Scale.Text);

        string MidXString = this.MidX.Text;
        MidXOutput = double.Parse(MidXString);

        string MidYString = this.MidY.Text;
        MidYOutput = double.Parse(MidYString);

        MidPointCorrector = -250 * ScaleOutput + 2;
    }

    double MouseX;
    double MouseY;

    private void UserInterfaceText()
    {
        Label PresetLabel = new Label();
        PresetLabel.Text = "Examples:";
        PresetLabel.Location = new Point(300, 5);
        this.Controls.Add(PresetLabel);

        Label MaxRepText = new Label();
        MaxRepText.Text = "Repetitions:";
        MaxRepText.Location = new Point(5, 15);
        this.Controls.Add(MaxRepText);

        Label ScaleText = new Label();
        ScaleText.Text = "Scale:";
        ScaleText.Location = new Point(5, 65);
        this.Controls.Add(ScaleText);

        Label MidXText = new Label();
        MidXText.Text = "Middle X:";
        MidXText.Location = new Point(130, 15);
        this.Controls.Add(MidXText);

        Label MidYText = new Label();
        MidYText.Text = "Middle Y";
        MidYText.Location = new Point(130, 65);
        this.Controls.Add(MidYText);

    }

    int p;
    int q;

    public void DrawMandelbrot(object obj, PaintEventArgs pea)
    {
        float xloc = 0;
        float yloc = 0;

        Graphics Gpanel = panel.CreateGraphics();

        for (xloc = 0; xloc < 500; xloc++)
        {
            for (yloc = 0; yloc < 500; yloc++)
            {
                double mandel = Bereken
                    (
                    (((xloc * ScaleOutput - 2) + MidXOutput) + MidPointCorrector), 
                    (((2 - yloc * ScaleOutput) + MidYOutput) - MidPointCorrector), 
                    MaxRepOutput
                    );

                if (p == 0 && q == 0)
                {
                    if (mandel % 2 == 0 && mandel < MaxRepOutput)
                    {
                        Gpanel.FillRectangle(Brushes.White, xloc, yloc, 1, 1);
                    }

                    else if (mandel % 2 != 0 || mandel == MaxRepOutput)
                    {
                        Gpanel.FillRectangle(Brushes.Black, xloc, yloc, 1, 1);
                    }
                }

                else if (p != 0 && q != 0)
                {


                    if (mandel % 10 == 0 && mandel < MaxRepOutput)
                    {
                        Gpanel.FillRectangle(new SolidBrush(Color.FromArgb(0, p, q)), xloc, yloc, 1, 1);
                    }
                    else if (mandel % 10 == 1 && mandel < MaxRepOutput)
                    {
                        Gpanel.FillRectangle(new SolidBrush(Color.FromArgb(25, p, q)), xloc, yloc, 1, 1);
                    }

                    else if (mandel % 10 == 2 && mandel < MaxRepOutput)
                    {
                        Gpanel.FillRectangle(new SolidBrush(Color.FromArgb(50, p, q)), xloc, yloc, 1, 1);
                    }

                    else if (mandel % 10 == 3 && mandel < MaxRepOutput)
                    {
                        Gpanel.FillRectangle(new SolidBrush(Color.FromArgb(75, p, q)), xloc, yloc, 1, 1);
                    }
                    else if (mandel % 10 == 4 && mandel < MaxRepOutput)
                    {
                        Gpanel.FillRectangle(new SolidBrush(Color.FromArgb(100, p, q)), xloc, yloc, 1, 1);
                    }
                    else if (mandel % 10 == 5 && mandel < MaxRepOutput)
                    {
                        Gpanel.FillRectangle(new SolidBrush(Color.FromArgb(125, p, q)), xloc, yloc, 1, 1);
                    }
                    else if (mandel % 10 == 6 && mandel < MaxRepOutput)
                    {
                        Gpanel.FillRectangle(new SolidBrush(Color.FromArgb(150, p, q)), xloc, yloc, 1, 1);
                    }
                    else if (mandel % 10 == 7 && mandel < MaxRepOutput)
                    {
                        Gpanel.FillRectangle(new SolidBrush(Color.FromArgb(175, p, q)), xloc, yloc, 1, 1);
                    }
                    else if (mandel % 10 == 8 && mandel < MaxRepOutput)
                    {
                        Gpanel.FillRectangle(new SolidBrush(Color.FromArgb(200, p, q)), xloc, yloc, 1, 1);
                    }
                    else if (mandel % 10 == 9 && mandel < MaxRepOutput)
                    {
                        Gpanel.FillRectangle(new SolidBrush(Color.FromArgb(225, p, q)), xloc, yloc, 1, 1);
                    }
                    else
                    {
                        Gpanel.FillRectangle(Brushes.Black, xloc, yloc, 1, 1);
                    }
                }

            }
        }
        
    }

    public static double Bereken(double x, double y, double MaxRepOutput)

    {
        double a = 0;
        double b = 0;

        double afstand2 = 0;
        double afstand = 0;

        int mandel = 0;

        while (afstand < 2 && mandel < MaxRepOutput)
        {
            double a_temp = a;

            mandel++;
            a = (a * a) - (b * b) + x;      
            b = (2 * a_temp * b) + y;        

            afstand2 = (a * a) + (b * b);
            afstand = Math.Sqrt(afstand2);
        }

        return mandel;
    }

    static void Main()
    {
        screen scherm = new screen();
        Application.Run(scherm);
    }

}
