using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace Calculator
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        //Calculator's buffer contains temporary number that will be applied by some action to result
        private double _Buffer;
        public double Buffer
        {
            get
            {
                return _Buffer;
            }
            set
            {
                _Buffer = value;
                BufferLabel.Text = _Buffer.ToString();
            }
        }

        //Contains result of calculating
        private double _Result;
        public double Result
        {
            get
            {
                return _Result;
            }
            set
            {
                _Result = value;
                ResultLabel.Text = _Result.ToString();
            }
        }

        //Operation buttons
        Button Plus, Minus, Divide, Multiply;

        //Number's buttons
        Button[] KeyPad;

        Label ResultLabel;

        Label BufferLabel;

        public MainPage()
        {
            InitializeComponent();

            //Setup result and operation labels
            ResultLabel = new Label();
            ResultLabel.VerticalTextAlignment = TextAlignment.Center;
            ResultLabel.HorizontalTextAlignment = TextAlignment.Center;
            ResultLabel.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
            BufferLabel = new Label();
            BufferLabel.VerticalTextAlignment = TextAlignment.Center;
            BufferLabel.HorizontalTextAlignment = TextAlignment.Center;

            //Operation buttons
            Plus = new Button() { Text = "Plus", BorderWidth = 0 };
            Minus = new Button() { Text = "Minus", BorderWidth = 0 };
            Divide = new Button() { Text = "Divide", BorderWidth = 0 };
            Multiply = new Button() { Text = "Multiply", BorderWidth = 0 };

            Plus.Pressed += Plus_Pressed;
            Minus.Pressed += Minus_Pressed;
            Divide.Pressed += Divide_Pressed;
            Multiply.Pressed += Multiply_Pressed;

            //Keypad buttons
            KeyPad = new Button[10];
            for (uint index = 0; index < KeyPad.Length; ++index)
            {
                ref var button = ref KeyPad[index];
                button = new Button() { Text = index.ToString() };
                button.BorderWidth = 0;
                uint i = index;
                button.Pressed += (o, e) => { KeyPadButton_Pressed(i); };
            }

            //Setup the grid
            var grid = new AutoGrid();
            grid.ColumnSpacing = 0;
            grid.RowSpacing = 0;
            int[] index_remapper = { 0, 3, 2, 1, 6, 5, 4, 9, 8, 7 };

            grid.DefineGrid(3, 6);

            grid.AutoAdd(BufferLabel);
            grid.AutoAdd(ResultLabel, 2);

            for (var index = KeyPad.Length-1; index >= 0; index--)
            {
                ref var button = ref KeyPad[index_remapper[index]];

                if (index != 0)
                    grid.AutoAdd(button);
                else
                    grid.AutoAdd(button, 2);
            }

            //Setup the buttons
            grid.AutoAdd(Plus);
            grid.AutoAdd(Minus);
            grid.AutoAdd(Divide);
            grid.AutoAdd(Multiply);

            //Show content
            Content = grid;
        }

        #region Keypad buttons
        private void KeyPadButton_Pressed(uint index)
        {
            Buffer *= 10.0;
            Buffer += index;
        }
        #endregion

        #region Operation buttons
        //////////////////////////////////////////////////////
        //Operations buttons
        private void Multiply_Pressed(object sender, EventArgs e)
        {
            Result *= Buffer;
            Buffer = 0.0;
        }

        private void Divide_Pressed(object sender, EventArgs e)
        {
            Result /= Buffer;
            Buffer = 0.0;
        }

        private void Minus_Pressed(object sender, EventArgs e)
        {
            Result -= Buffer;
            Buffer = 0.0;
        }

        private void Plus_Pressed(object sender, EventArgs e)
        {
            Result += Buffer;
            Buffer = 0.0;
        }
        //////////////////////////////////////////////////////
        #endregion
    }
}
